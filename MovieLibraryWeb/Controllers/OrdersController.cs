using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Models.Models;
using MovieLibrary.Models.Static;
using MovieLibrary.Models.ViewModels;
using MovieLibrary.Services.Interfaces;
using Services.Interfaces;
using System.Data;
using System.Security.Claims;

namespace MovieLibraryWeb.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IOrderService _orderService;
        private readonly string clientId;

        public OrdersController(ICartService cartService, IOrderService orderService)
        {
            _cartService = cartService;
            _orderService = orderService;
        }
        public async Task<IActionResult> List()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var orders = await _orderService.
                GetUserOrdersAsync(userId, userEmail);

            return View(orders == null ? new List<Order>() : orders);
        }
        [Authorize(Roles = UserRolesValues.Admin)]
        public async Task<IActionResult> ListAll()
        {
            var orders = await _orderService.
                GetOrdersWithUsersAsync();

            return View(orders == null ? new List<Order>() : orders);
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.GetUserCartAsync(userId, userEmail);
            if (cart == null)
            {
                cart = new Cart();
            }
            CartVM cartVM = new CartVM()
            {
                Cart = cart,
                Total = cart.GetTotalPrice()
            };
            return View((cartVM, clientId));
        }
        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.AddMovieToCartAsync(id, userId, userEmail);
            if (cart == null)
            {
                return View("NotFound");
            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> RemoveItemFromCart(int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;

            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.RemoveMovieFromCartAsync(id, userId, userEmail);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Success()
        {
            return View("OrderCompleted");
        }
        [HttpPost]
        public async Task<IActionResult> MarkDone(int id)
        {
            try
            {
                await _orderService.MarkAsDone(id);
            }
            catch (Exception ex)
            {
                return View("NotFound");
            }
            return RedirectToAction("ListAll");
        }
        [HttpPost]
        public async Task<IActionResult> Order(CancellationToken cancellationToken)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
            if (userId == null || userEmail == null)
            {
                return View("NotFound");
            }
            var cart = await _cartService.GetUserCartAsync(userId, userEmail);
            if (cart == null)
            {
                cart = new Cart();
            }
            try
            {
                // set the transaction price and currency
                var price = cart.GetTotalPrice().ToString();
                var currency = "RUB";

                // "reference" is the transaction key
                var reference = cart.Id.ToString();


                return Ok(reference);
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Capture(string orderId, CancellationToken cancellationToken)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var userEmail = User.FindFirst(ClaimTypes.Email)!.Value;
                if (userId == null || userEmail == null)
                {
                    return View("NotFound");
                }
                var cart = await _cartService.GetUserCartAsync(userId, userEmail);
                if (cart == null)
                {
                    cart = new Cart();
                }
                orderId = cart.Id.ToString();
                var order = await _orderService.OrderAsync(cart, orderId);

                return RedirectToAction("Success", "Orders");
            }
            catch (Exception e)
            {
                var error = new
                {
                    e.GetBaseException().Message
                };

                return BadRequest(error);
            }
        }
    }
}

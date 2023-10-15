using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace MovieLibraryWeb.Controllers
{
    public class ErrorHandlingController : Controller
    {
        [HttpGet("/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ViewBag.ErrorMessage = statusCode switch
            {
                404 => "Запрашиваемая Вами страница не найдена",
                500 => "Произошла ошибка при обработке Вашего запроса, наша команда уже работает над устранением ошибки.",
                _ => "Произошла непредвиденная ошибка.",
            };
            return View("HttpStatusCodeHandler");
        }

        [HttpGet("/Error")]
        public IActionResult Error()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewBag.ExceptionMessage = exceptionFeature?.Error.Message;
            return View("Error");
        }
    }
}

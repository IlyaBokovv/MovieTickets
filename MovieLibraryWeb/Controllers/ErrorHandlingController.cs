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
                500 => "Произошла ошибка при обработке Вашего запроса, наша команда уже работает над ее устранением.",
                _ => "Произошла непредвиденная ошибка.",
            };
            return View("HttpStatusCodeHandler");
        }
    }
}

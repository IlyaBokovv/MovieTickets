using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Controller;
using Serilog;
using ILogger = Serilog.ILogger;

namespace MovieLibraryWeb.Controllers
{
    public class ErrorHandlingController : Controller
    {
        private readonly ILogger<ErrorHandlingController> _logger;

        public ErrorHandlingController(ILogger<ErrorHandlingController> logger)
        {
            _logger = logger;
        }
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

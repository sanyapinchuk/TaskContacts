using Microsoft.AspNetCore.Mvc;

namespace AppClient.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger= logger;
        }

        [HttpGet("/error")]
        public IActionResult Index(int? statusCode = null)
        {
                if (statusCode.HasValue)
            {
                this.HttpContext.Response.StatusCode = statusCode.Value;
            }
            _logger.LogWarning($"Handle http error, status code= {statusCode}");

            ViewData["Error"] = statusCode;
            switch (statusCode)
            {
                case 400:
                    ViewData["Message"] = "Проверьте корректность запроса";
                    break;
                case 403:
                    ViewData["Message"] = "Доступ запрещён!";
                    break;
                case 404:
                    ViewData["Message"] = "Ресурс не найден!";
                    break;
                case 405:
                    ViewData["Message"] = "Метод Htpp не разрешен";
                    break;
                case 500:
                    ViewData["Message"] = "Ошибка сервера";
                    break;
                default:
                    ViewData["Message"] = "Неизвестная ошибка, попробуйте позже";
                    break;
            }
            return View();
        }

    }
    
}

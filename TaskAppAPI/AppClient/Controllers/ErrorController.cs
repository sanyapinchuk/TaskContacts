using Microsoft.AspNetCore.Mvc;

namespace AppClient.Controllers
{
    public class ErrorController : Controller
    {

        [HttpGet("/error")]
        public IActionResult Index(int? statusCode = null)
        {
                if (statusCode.HasValue)
            {
                this.HttpContext.Response.StatusCode = statusCode.Value;
            }

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

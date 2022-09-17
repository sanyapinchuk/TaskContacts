using AppClient.Models;
using ClientWeb;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Diagnostics;

namespace AppClient.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var response = await GlobalVariables.WebApiClient.GetAsync("Contact/getAll");
            if(response.IsSuccessStatusCode)
            {
                var contacts = response.Content.ReadFromJsonAsync<IEnumerable<Contact>>().Result;
                return View(contacts);
            }
            else
                return StatusCode((int)response.StatusCode);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var response = await GlobalVariables.WebApiClient.GetAsync($"Contact/get/{id}");
            if (response.IsSuccessStatusCode)
            {
                var contacts = response.Content.ReadFromJsonAsync<Contact>().Result;
                return View(contacts);
            }
            else
                return StatusCode((int)response.StatusCode);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
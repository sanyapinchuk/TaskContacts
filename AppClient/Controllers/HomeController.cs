using ClientWeb;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace AppClient.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await GlobalVariables.WebApiClient.GetAsync("Contact/getAll");
            if(response.IsSuccessStatusCode)
            {
                var contacts = response.Content.ReadFromJsonAsync<IEnumerable<Contact>>().Result;
                ViewData["apiEditUrl"] = GlobalVariables.WebApiClient.BaseAddress+ "Contact/edit";
                return View(contacts);
            }
            else
                return StatusCode((int)response.StatusCode);
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website_Http.Models;

namespace Website_Http.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult UserDocumtation()
        {
            return View();
        }

        public IActionResult Single(string id)
        {
            var model = Church.GetChurch(Int32.Parse(id));
            model.dates = Dates.GetDates(model.id.ToString());
            return PartialView("Single", model);
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
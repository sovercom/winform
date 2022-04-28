using project02.Models;
using project02;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace project02.Controllers
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
            string query = "select managerName,machineName,Temperature,power,runtime from tbl_machine";
            List<MachineCensor> list = DBmanager.SelectDB(query);
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AidaCarParts.Models;

namespace AidaCarParts.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Page(int sectionAndSubsectionId, int page = 1)
        {
            var model = PageData.GetPageData(sectionAndSubsectionId, page);
            return View(model);
        }
        public IActionResult NextPage(int sectionAndSubsectionId, int page)
        {
            return RedirectToAction("Page", new { sectionAndSubsectionId= sectionAndSubsectionId, page=page });
        }
        public IActionResult PreviousPage(int sectionAndSubsectionId, int page)
        {
            return RedirectToAction("Page", new { sectionAndSubsectionId = sectionAndSubsectionId, page = page });
        }
    }
}

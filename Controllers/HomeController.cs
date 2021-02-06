using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PetClinic.Data;
using PetClinic.Models;

namespace PetClinic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Veterinary> veterinaries = _dbContext.Veterinaries.ToList();
            ViewBag.Veterinaries = veterinaries;
            return View();
        }

        [HttpPost]
        public IActionResult SearchResult(String search)
        {
            List<Veterinary> veterinaries = _dbContext.Veterinaries.Where(v => v.city.Equals(search)).ToList();
            ViewBag.Veterinaries = veterinaries;
            ViewBag.city = search;
            return View();
        }

        public IActionResult Veterinary(int id)
        {
            Veterinary vet = _dbContext.Veterinaries.FirstOrDefault(v => v.Id == id);
            // ViewBag.vet = vet;
            var model = vet;
            return View(model);
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

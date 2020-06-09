using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dalal.Models;
using Dalal.Repositories;
using Dalal.Data;
using Microsoft.EntityFrameworkCore;
using Dalal.ViewModels;

namespace Dalal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger,
                              ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var productsondiscount = _db.Products.Include(c => c.productCatagory).Include(c => c.supplyer).Where(a => a.IsOnSale).ToList();
            var viewmodel = new HomePageViewModel
            {
                 products = productsondiscount,
                  SearchedProduct =null
            };
            return View(viewmodel);
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

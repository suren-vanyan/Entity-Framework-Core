using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExistingDb.Models.Scaffold;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExistingDb.Controllers
{
    public class HomeController : Controller
    {
        private ZoomShoesDbContext context;
        public HomeController(ZoomShoesDbContext ctx) => context = ctx;
        public IActionResult Index()
        {
            return View(context.Shoes
            .Include(s => s.Color)
            .Include(s => s.SalesCampaigns)
            .Include(s => s.ShoeCategoryJunction)
            .ThenInclude(junct => junct.Category)
            .Include(s => s.Fitting));
        }
    }
}
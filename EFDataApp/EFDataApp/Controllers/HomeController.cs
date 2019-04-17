using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFDataApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataApp.Controllers
{
    public class HomeController : Controller
    {
        private MobileContext db;
        public HomeController(MobileContext mobileContext)
        {
            this.db = mobileContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Phones.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Phone phone)
        {
            db.Phones.Add(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Phone phone)
        {
            db.Phones.Update(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = new Phone { Id = id.Value };
                db.Entry(phone).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

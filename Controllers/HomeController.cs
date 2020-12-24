using Korelskiy.TheWitcherProject.Infrastructure;
using Korelskiy.TheWitcherProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.TheWitcherProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext context;
        public HomeController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult> Index()
        {
            IQueryable<WitcherItem> items = from i in context.ItemList orderby i.Id select i;

            List<WitcherItem> WitcherItemList = await items.ToListAsync();

            return View(WitcherItemList);
        }
    }
}

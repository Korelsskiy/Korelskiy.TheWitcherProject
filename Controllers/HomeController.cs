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
        private static Random rnd = new Random();
        public HomeController(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<ActionResult> Index()
        {
            IQueryable<Beast> beasts = from i in context.BeastsList orderby i.Id select i;
            IQueryable<Person> persons = from i in context.PersonsList orderby i.Id select i;

            List<Beast> beastsList = await beasts.ToListAsync();
            List<Person> personsList = await persons.ToListAsync();



            List<WitcherItem> witcherItems = new List<WitcherItem>
            {
                personsList[rnd.Next(0, personsList.Count)],
                beastsList[rnd.Next(0, beastsList.Count)]
            };

            return View(witcherItems);
        }
    }
}

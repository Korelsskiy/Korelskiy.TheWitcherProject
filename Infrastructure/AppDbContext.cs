﻿using Korelskiy.TheWitcherProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korelskiy.TheWitcherProject.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Beast> BeastsList { get; set; }

        public DbSet<Person> PersonsList { get; set; }
    }
}

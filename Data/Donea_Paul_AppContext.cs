using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Donea_Paul_App.Models;

namespace Donea_Paul_App.Data
{
    public class Donea_Paul_AppContext : DbContext
    {
        public Donea_Paul_AppContext (DbContextOptions<Donea_Paul_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Donea_Paul_App.Models.Truck> Truck { get; set; }

        public DbSet<Donea_Paul_App.Models.Maker> Maker { get; set; }

        public DbSet<Donea_Paul_App.Models.Category> Category { get; set; }
    }
}

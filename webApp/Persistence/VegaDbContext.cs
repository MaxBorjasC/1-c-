using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webApp.Core.Models;

namespace webApp.Persistence
{
    public class VegaDbContext : DbContext
    {

        public DbSet<Make> Makes { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Model> Models { get; set; }

        public VegaDbContext(DbContextOptions<VegaDbContext> options)
         : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // llave de dos columnas (rekacion de muchos a muchos)
            modelBuilder.Entity<VehicleFeature>().HasKey(vf =>
             new { vf.VehicleId, vf.FeatureId });
        }


     }
}

using Microsoft.EntityFrameworkCore;
using PersonelBirim.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PersonelBirim.DAL.Context
{
    public class PersonelBirimDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-1KD6P84\\SQLEXPRESS;Database=PersonelBirimDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Birim> Birimler { get; set; }
    }
}

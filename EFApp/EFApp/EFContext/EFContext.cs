using EFApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFApp
{
    public class EFContext : DbContext
    {
        public DbSet<Kullanici> Kullanicis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
    => options.UseSqlite("Data Source=db/EFApp.db");
    }
}

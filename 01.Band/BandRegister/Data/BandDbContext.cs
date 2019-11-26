using BandRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BandRegister.Data
{
    public class BandDbContext : DbContext
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=BandDb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder OptionBuilder)
        {
            OptionBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Band> Bands { get; set; }

        public object Band { get; internal set; }
    }
}

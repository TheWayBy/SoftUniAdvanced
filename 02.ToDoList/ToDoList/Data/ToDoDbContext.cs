using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoDbContext:DbContext
    {
        private const string ConnectionString = @"Server=.\SQLEXPRESS;Database=BandDb;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder OptionBuilder)
        {
            OptionBuilder.UseSqlServer(ConnectionString);
        }

        public DbSet<Task> Tasks { get; set; }

        public object Task { get; internal set; }
    }
}

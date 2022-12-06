﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Model
{
    public class DatabaseContext : DbContext
    {
        //public DbSet<Bar> Bars { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Match> Matchs { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<User> Users { get; set; }

        private string _connectionString;

        public DatabaseContext() {
            _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=zuypr";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);
    }
}

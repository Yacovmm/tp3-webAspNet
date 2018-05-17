using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Api.Models;

namespace Api.Data
{
    public class AppDbContext :DbContext 
    {
        public DbSet<Amigo> Amigos { get; set; }

        public AppDbContext()
            : base("Amigos")
        {
        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}
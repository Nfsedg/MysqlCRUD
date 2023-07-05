using Diesño.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diesño.Context
{
    public class AppDBCContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySQL("server=localhost; database=empleados; user=root; password=");

        }

        public DbSet<Empleados> Empleados { get; set; }
    }
}

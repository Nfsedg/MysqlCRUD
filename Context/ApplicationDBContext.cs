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

            optionsBuilder.UseMySQL("server=localhost; Port=3307;database=empleados; user=root; password=edgar;CharSet=utf8;");

        }

        public DbSet<Empleados> Empleados { get; set; }
    }
}

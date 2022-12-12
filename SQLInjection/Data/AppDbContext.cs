using Microsoft.EntityFrameworkCore;
using SQLInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLInjection.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
           
        }
        public DbSet<Product> Products { get; set; }
    }
}

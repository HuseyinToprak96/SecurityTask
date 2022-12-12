using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLInjection.APIServices;
using SQLInjection.Data;
using SQLInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SQLInjection.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> list = new List<Product>();
                list = await _context.Products.ToListAsync();

            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string search)
        {
            //' or '1'='1' -- getall..
            List<Product> list = new List<Product>();
            //list = await _context.Products.FromSqlRaw("select * from Products where Name='" + search + "'").ToListAsync(); *Don't(Warning)
            //list = await _context.Products.FromSqlRaw($"select * from Products where Name='{search}'").ToListAsync(); *Don't(Warning)
            //list = await _context.Products.FromSqlInterpolated($"select * from Products where Name={search}").ToListAsync();//Do(Success)
            //list = await _context.Products.FromSqlRaw("select * from Products where Name={0}", search).ToListAsync();//Do(Success)
            list = await _context.Products.Where(x => x.Name == search).ToListAsync();//Do(Success)
            return View(list);
        }

    }
}

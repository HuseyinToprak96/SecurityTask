using CORS.Dtos;
using CORS.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductAPI _productAPI;

        public ProductController(IProductAPI productAPI)
        {
            _productAPI = productAPI;
        }

        public async Task<IActionResult> Create()
        {
            CreateProductDto product = new CreateProductDto
            {
                Name = "Product 1",
                Price = 100,
                Barkod = "12345678",
                Count = 1000,
                MarketId = 1,
            };
            await _productAPI.Add(product);
            return View();
        }
        public async Task<IActionResult> GetAll()
        {
            var datas = await _productAPI.List();
            return View();
        }
        public  async Task<IActionResult> Update()
        {
            var data = await _productAPI.Find(1);
            data.Name = "Product";
            data.Barkod = "987455621";
            data.Count = 1100;
            await _productAPI.Update(data);
            return View();
        }
        public  async Task<IActionResult> Get()
        {
            var data = await _productAPI.Find(1);
            return View();
        }
        public  async Task<IActionResult> Remove()
        {
            await _productAPI.Delete(1);
            return View();
        }
    }
}

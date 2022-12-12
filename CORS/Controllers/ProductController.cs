using CORS.Data;
using CORS.Dtos;
using CORS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _context.Products.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _context.Products.FindAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult>Create(CreateProductDto createProductDto)
        {
            Product product = new Product
            {
                Barkod = createProductDto.Barkod,
                Name = createProductDto.Name,
                Price = createProductDto.Price,
            };
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            Stok stok = new Stok
            {
                ProductId = product.Id,
                Count = createProductDto.Count,
                MarketId = createProductDto.MarketId,
                Price = createProductDto.Price,
            };
            await _context.Stoks.AddAsync(stok);
            await _context.SaveChangesAsync();
            return Ok(createProductDto);
        }
        [HttpPut]
        public IActionResult Update(CreateProductDto createProductDto)
        {

            return Ok("");
        }
        [HttpDelete]
        public IActionResult Remove(int id)
        {
            return Ok("");
        }
    }
}

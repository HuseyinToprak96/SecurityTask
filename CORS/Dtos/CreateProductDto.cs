using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Dtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Barkod { get; set; }
        public int MarketId { get; set; }
        public int Count { get; set; }
    }
}

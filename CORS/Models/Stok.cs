using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Models
{
    public class Stok
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MarketId { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
        public Market Market { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Barkod { get; set; }
        public IEnumerable<Stok> Stoks { get; set; }
    }
}

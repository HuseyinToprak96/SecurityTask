using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CORS.Models
{
    public class Market
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adres { get; set; }
        public IEnumerable<Stok> Stoks { get; set; }
    }
}

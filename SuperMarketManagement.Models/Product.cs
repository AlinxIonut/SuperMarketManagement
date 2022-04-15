using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Models
{
   public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public DateTime FabricationDate { get; set; }
        public string Brand { get; set; }
        public string ProductStatus { get; set;}
        public string Category { get; set; }
    }
}

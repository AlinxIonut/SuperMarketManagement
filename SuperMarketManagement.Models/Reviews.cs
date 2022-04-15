using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Models
{
   public class Reviews
    {
        public string Username { get; set; }
        public string NameOfProduct { get; set; }
        public string Description { get; set; }

        public int Rating { get; set; }
   
    }
}

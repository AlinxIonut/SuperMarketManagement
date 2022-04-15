using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketManagement.Models
{
  public class ProductEvaluation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}

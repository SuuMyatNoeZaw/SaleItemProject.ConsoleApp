using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleProject.ConsloeApp.Model
{
    public class SaleModel
    {
        public int SaleId { get; set; }
        public string Item { get; set; }
        public int CustomerId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal TotalPrice { get; set; }

    }
}

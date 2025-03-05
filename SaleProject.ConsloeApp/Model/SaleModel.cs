using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

    [Table("Tbl_Sale")]
    public class SaleEFCoreModel
    {
        [Key]
        [Column("SaleID")]
        public int SaleId { get; set; }
        [Column("Item")]
        public string Item { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("Price")]
        public decimal Price { get; set; }
        [Column("Qty")]
        public int Qty { get; set; }
        [Column("TotalPrice")]
        public decimal TotalPrice { get; set; }

    }
}

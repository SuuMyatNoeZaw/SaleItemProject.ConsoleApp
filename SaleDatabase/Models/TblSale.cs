using System;
using System.Collections.Generic;

namespace SaleDatabase.Models;

public partial class TblSale
{
    public int SaleId { get; set; }

    public string Item { get; set; } = null!;

    public int CustomerId { get; set; }

    public decimal Price { get; set; }

    public int Qty { get; set; }

    public decimal TotalPrice { get; set; }
}

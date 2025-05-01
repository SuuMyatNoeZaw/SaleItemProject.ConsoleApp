using System;
using System.Collections.Generic;

namespace SaleDatabase.Models;

public partial class TblCustomer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public int SaleId { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public bool DeleteFlag { get; set; }
}

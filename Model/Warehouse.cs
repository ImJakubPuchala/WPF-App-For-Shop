using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App_For_Shop.Model;

public class Warehouse
{
    public string EANCode { get; set; }
    public int Quantity { get; set; }
    public string WarehouseNumber { get; set; }
}

public class WarehouseResponse
{
    public int WarehouseItemId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string WarehouseNumber { get; set; }
}

public class WarehouseProduct
{
    public int WarehouseItemId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public string EANCode { get; set; }
    public int Quantity { get; set; }
    public string WarehouseNumber { get; set; }
}

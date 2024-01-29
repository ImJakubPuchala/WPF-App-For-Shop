using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App_For_Shop.Model;

public class ProductInformation
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public string EAN { get; set; }
    public double NewPrice { get; set; }
}

public class ProductNewPrice
{
    public string EAN { get; set; }
    public double NewPrice { get; set; }
}
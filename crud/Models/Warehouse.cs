using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public enum TypeOfWarehouse
{
    ECOMMERCE,
    PHYSICAL_STORE
}

namespace crudrn.NET_WebApp.Models
{
    public class Warehouse
    {
        public string locality { get; set; }
        public int quantity { get; set; }
        public TypeOfWarehouse type { get; set; }
    }
}
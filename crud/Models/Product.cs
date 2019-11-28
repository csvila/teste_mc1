using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crudrn.NET_WebApp.Models
{
    public class Product
    {
        public string SKU { get; set; }
        public string Name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get { return (this.inventory.quantity > 0); } }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace crudrn.NET_WebApp.Models
{
    public class Inventory
    {
        public int quantity { get { return this.warehouses.Sum(w => w.quantity); } }
        public List<Warehouse> warehouses { get; set; }
    }
}
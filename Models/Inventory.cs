using System;
using System.Collections.Generic;

namespace ProductCatalog.Models{

    public class Inventory
    {
        public int quantity { get; set; }
        public IEnumerable<Warehouse> warehouses { get; set; }
    }
        

}

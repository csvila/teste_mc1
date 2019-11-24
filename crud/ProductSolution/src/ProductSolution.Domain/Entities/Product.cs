using System;
using System.Collections.Generic;
using System.Text;

namespace ProductSolution.Domain.Entities
{
    public class Product
    {
        public string Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }
        public override bool Equals(object obj)
        {
            return this.Sku.Equals(((Product)obj).Sku);
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace crud.Models
{
    /// <summary>
    /// Inventory Class
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Quantity
        /// </summary>
        public int Quantity { get { return this.Warehouses.Sum(w => w.quantity); } }

        /// <summary>
        /// Warehouses
        /// </summary>
        public List<Warehouse> Warehouses { get; set; }
    }
}
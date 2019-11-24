using System.Collections.Generic;

namespace ProductSolution.Domain.Entities
{
    public class Inventory
    {
        public int Quantity { get; set; }
        public ICollection<WhareHouse> WareHouses { get; set; }
        public Inventory()
        {
            WareHouses = new List<WhareHouse>();
        }
    }
}
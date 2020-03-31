using System.Collections.Generic;
using Newtonsoft.Json;

namespace mc1_api.Models
{
    public class Inventory
    {
        [JsonIgnore]
        public int Quantity { get; set; }
        public IList<Warehouse> Warehouses { get; set; }
    }
}
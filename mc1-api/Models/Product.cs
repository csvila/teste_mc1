
using Newtonsoft.Json;

namespace mc1_api.Models
{
    public class Product
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        [JsonIgnore]
        public bool isMarketable { get; set; }
    }
}
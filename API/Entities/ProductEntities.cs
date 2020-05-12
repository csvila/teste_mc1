namespace API.Entities
{
    public class Product
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool isMarketable { get; set; }
    }

    public class Inventory
    {
        public Inventory()
        {
            warehouses = new Warehouse();
        }

        public int quantity { get; set; }
        public Warehouse warehouses { get; set; }
    }

    public class Warehouse
    {
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }
}
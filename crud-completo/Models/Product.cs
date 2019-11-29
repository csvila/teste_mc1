namespace crud.Models
{
    /// <summary>
    /// Product Class
    /// </summary>
    public class Product
    {
        /// <summary>
        /// SKU
        /// </summary>
        public string SKU { get; set; }
        
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Inventory
        /// </summary>
        public Inventory inventory { get; set; }

        /// <summary>
        /// IsMarketable
        /// </summary>
        public bool IsMarketable { get { return this.inventory.Quantity > 0; } }
        
        
    }
}
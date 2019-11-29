/// <summary>
/// Enum TypeOfWarehouse
/// </summary>
public enum TypeOfWarehouse
{
    /// <summary>
    /// ECOMMERCE
    /// </summary>
    ECOMMERCE,
    /// <summary>
    /// PHYSICAL_STORE
    /// </summary>
    PHYSICAL_STORE
}

namespace crud.Models
{
    /// <summary>
    /// Warehouse Class
    /// </summary>
    public class Warehouse
    {
        /// <summary>
        /// Locality
        /// </summary>
        public string locality { get; set; }

        /// <summary>
        /// Quantity
        /// </summary>
        public int quantity { get; set; }

        private TypeOfWarehouse typeOfWarehouse = new TypeOfWarehouse();
        /// <summary>
        /// Type
        /// </summary>
        public string type
        {
            get { return typeOfWarehouse.ToString(); }
            set {
                string tpOfWareHouse = value;
                if (tpOfWareHouse == TypeOfWarehouse.ECOMMERCE.ToString())
                    typeOfWarehouse = TypeOfWarehouse.ECOMMERCE;
                else if (tpOfWareHouse == TypeOfWarehouse.PHYSICAL_STORE.ToString())
                    typeOfWarehouse = TypeOfWarehouse.PHYSICAL_STORE;
            }
        }
    }
}
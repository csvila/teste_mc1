using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud.Entitys
{
    public class Inventory
    {
        public Inventory()
        {
            Warehouses = new List<Warehouses>();
        }

        [Key]
        public int IdInventory { get; set; }
        public int IdProduto { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("IdInventory")]
        public List<Warehouses> Warehouses { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Entitys
{
    public class Warehouses
    {
        [Key]
        public int IdWarehouses { get; set; }
        public int IdInventory { get; set; }
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }
    }
}

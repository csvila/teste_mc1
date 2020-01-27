using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud.Entitys
{
    public class Produto
    {
        [Key]
        public int IdProduto { get; set; }
        public int Sku { get; set; }
        public string Name { get; set; }
        public bool isMarketable { get; set; }

        [ForeignKey("IdProduto")]
        public Inventory Inventory { get; set; }
    }
}

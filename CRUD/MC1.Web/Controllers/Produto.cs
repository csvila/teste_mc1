using System.Collections.Generic;

namespace Teste_MC1.Controllers
{
    public class Produto
    {
        public Produto()
        { }
        public Produto(string sku, string nome, Inventory inventory, bool isMarketable)
        {
            Sku = sku;
            Nome = nome;
            Inventory = inventory;
            IsMarketable = isMarketable;
        }

        public string Sku { get; set; }
        public string Nome { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable { get; set; }


        public void AlterarProduto(Produto prod)
        {
            Nome = prod.Nome;
            Inventory = prod.Inventory;
            IsMarketable = prod.IsMarketable;
        }
    }

    public class Inventory
    {
        public int Quantity { get; set; }
        public IEnumerable<Warehouses> Warehouses { get; set; }

    }

    public class Warehouses
    {
        public string locality { get; set; }
        public int Quantity { get; set; }
        public Type Type { get; set; }
    }

    public enum Type
    {
        ECOMMERCE,
        PHYSICAL_STORE
    }


}

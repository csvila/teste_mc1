using crudrn.NET_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudrn.NET_WebApp.Interfaces
{
    public interface IProductRepository
    {
        List<Product> ListaProdutos();
        Product BuscaProduto(string sku);
        Product Inserir(Product product);
        Product Atualizar(string sku, Product product);
        bool Excluir(string sku);

        
    }
}

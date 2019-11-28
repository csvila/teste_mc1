using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using crudrn.NET_WebApp.Models;

namespace crudrn.NET_WebApp.Interfaces
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> ListaProdutos()
        {
            //AQUI A LISTA VIRIA DO BANCO DE DADOS
            List<Product> products = new List<Product>();
            return products;
        }

        public Product BuscaProduto(string sku)
        {
            //BUSCA PRODUTO DO BANCO DE DADOS PELO SKU
            return new Product();
        }

        public Product Inserir(Product product)
        {
            if (this.BuscaProduto(product.SKU) != null)
                throw new Exception();
            else
            {
                //INSERE NO BANCO DE DADOS
            }
            return product;
        }

        public Product Atualizar(string sku, Product product)
        {
            //ATUALIZA NO BANCO DE DADOS
            return product;
        }

        public bool Excluir(string sku)
        {
            //EXCLUI NO BANCO DE DADOS
            return true;
        }

        
    }
}
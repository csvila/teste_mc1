using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Teste_MC1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        [Route("[action]")]
        [HttpPost]
        public IActionResult CriarProduto([FromBody]Produto prod)
        {
            try
            {
                var product = GetProd(prod.Sku);
                if (product == null)
                    throw new Exception("Produto já existe!");

                var dados = Criar(prod);
                return Ok();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpGet]
        [Route("[action]/{sku:long}")]
        public IActionResult GetBySku(long sku)
        {
            var product = GetProd(sku.ToString());
            string json = JsonConvert.SerializeObject(product);
            return Ok(json);
        }

        [HttpDelete]
        [Route("[action]/{sku:long}")]
        public IActionResult Delete(long sku)
        {
            var product = GetProd(sku.ToString());
            if (product == null)
                throw new Exception("produto não localizado");

            return Ok("produto excluído com sucesso");
        }

        [Route("[action]")]
        [HttpPut]
        public IActionResult AlterarProduto([FromBody]Produto prod)
        {
            try
            {
                var product = GetProd(prod.Sku);
                if (product == null)
                    throw new Exception("produto não localizado");

                product.AlterarProduto(prod);

                return Ok("produto atualizado com sucesso");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private Produto GetProd(string sku)
        {
            List<Produto> lProd = new List<Produto>();

            var prod1 = new Produto()
            {
                Inventory = new Inventory()
                {
                    Warehouses = new List<Warehouses>
                   {
                       new Warehouses{locality = "SP", Quantity=12,Type=Type.ECOMMERCE},
                       new Warehouses{locality = "MOEMA", Quantity=3,Type=Type.PHYSICAL_STORE}
                   }
                },
                IsMarketable = true,
                Nome = "Batata frita Ruffles Cebola & Salsa",
                Sku = "43264"
            };

            var prod2 = new Produto()
            {
                Inventory = new Inventory()
                {
                    Warehouses = new List<Warehouses>
                   {
                       new Warehouses{locality = "RJ", Quantity=6,Type=Type.ECOMMERCE}
                   }
                },
                IsMarketable = true,
                Nome = "Cebola & Salsa",
                Sku = "43265"
            };

            lProd.Add(prod1);
            lProd.Add(prod2);


            var resut = (from p in lProd
                         where p.Sku == sku
                         select new Produto
                         {
                             Sku = p.Sku,
                             Nome = p.Nome,
                             IsMarketable = p.Inventory.Warehouses.Sum(x => x.Quantity) > 0,
                             Inventory = new Inventory
                             {
                                 Quantity = p.Inventory.Warehouses.Sum(x => x.Quantity),
                                 Warehouses = p.Inventory.Warehouses
                             }
                         }
                        ).FirstOrDefault();


            return resut;
        }

        private Produto Criar(Produto prod)
        {
            return new Produto(prod.Sku, prod.Nome, prod.Inventory, prod.IsMarketable);
        }

    }
}

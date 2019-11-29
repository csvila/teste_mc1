# Teste - Desenvolvimento de Software #

1. Crie um fork desse repositório, faça os testes, responda as perguntas e depois submeta um pull request.
2. Os testes envolvendo código devem ser feitos em **C#, Java ou Swift**. Cada codificação deve estar em uma pasta com o nome que está entre perênteses nas questões. As questões teóricas devem ser respondidas em um **pdf** que também será adicionado ao GIT.
3. Como você se atualiza tecnicamente?
4. Crie uma função para calcular o _n-ésimo_ elemento da Sequência de Fibonacci (fibonacci).
	1. Qual solução é mais performática, iterativa ou recursiva? Por que?
	2. _Opcional:_ Qual é o 5287º elemento da sequência?
5. O que significa SOLID?
6. O que são design patterns?
	1. Quais são os tipos de design patterns?
	2. Com quais você está familiarizado? Qual é a função deles?
	3. _Opcional:_ Qual é sua opinião quanto ao uso de design patterns?
7. Qual foi o último livro técnico que você leu? Quando foi isso?
 	1. _Observação: se já tivermos lido e você for chamado para uma entrevista, perguntas poderão ser feitas a respeito do mesmo._
8. Cite 3 maneiras diferentes de implementar Dependency Inversion.
9. O que são ORMs?
	1. Quais você conhece bem?
	2. _Opcional:_ Cite pelo menos 2 vantagens e 2 desvantagens de seu uso.
10. O que são microsserviços?
 	1. Quais são suas vantagens e desvantagens?
11. Com a seguinte representação de produto (crud):
```
{
    "sku": 43264,
    "name": "Batata frita Ruffles Cebola & Salsa",
    "inventory": {
        "quantity": 15,
        "warehouses": [
            {
                "locality": "SP",
                "quantity": 12,
                "type": "ECOMMERCE"
            },
            {
                "locality": "MOEMA",
                "quantity": 3,
                "type": "PHYSICAL_STORE"
            }
        ]
    },
    "isMarketable": true
}
```
Crie endpoints para as seguintes ações:
- Criação de produto onde o payload será o json informado acima (exceto as propriedades isMarketable e inventory.quantity)
- Edição de produto por sku
- Recuperação de produto por sku
- Deleção de produto por sku

Requisitos:
- Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: inventory.quantity
- A propriedade inventory.quantity é a soma da quantity dos warehouses
- Toda vez que um produto for recuperado por sku deverá ser calculado a propriedade: isMarketable
- Um produto é marketable sempre que seu inventory.quantity for maior que 0
- Caso um produto já existente em memória tente ser criado com o mesmo sku uma exceção deverá ser lançada
- Dois produtos são considerados iguais se os seus skus forem iguais
- Ao atualizar um produto, o antigo deve ser sobrescrito com o que esta sendo enviado na requisição
- A requisição deve receber o sku e atualizar com o produto que tbm esta vindo na requisição

### Não é necessário o uso de bancos de dados. ###
### Testes são bem vindos. ###
### Você não deve levar mais do que 4 horas para o teste todo. ###


/*sequência de Fibpnatti*/
using System;

public static class Fibonatti
{
    public static void Fibo(int n)
    {
        int a = 0;
        int b = 1;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(a);
            int temp = a;
            a = b;
            b = temp + b;
        }
    }
}


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonatti.Fibo(3);
        }
    }
}


/*API*/

/*Classe Produto*/

using System;
using System.Collections.Generic;

namespace Teste_MC1.Controllers
{
    public class Produto
    {
        public Produto()
        {

        }
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

/*Controllers*/

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
                if (product.Count > 0)
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
        public IActionResult Get()
        {
            var product = GetProd();
            string json = JsonConvert.SerializeObject(product);
            return Ok(json);
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
            string json = JsonConvert.SerializeObject(product);
            return Ok(json);
        }
        private List<Produto> GetProd(string sku = "")
        {
            List<Produto> lProd = new List<Produto>();

            var prod1 = new Produto()
            {
                Inventory = new Inventory()
                {
                    Quantity = 15,
                    Warehouses = new List<Warehouses>
                   {
                       new Warehouses{locality = "SP", Quantity=12,Type=Type.ECOMMERCE}
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
                    Quantity = 15,
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

            if (sku != string.Empty)
            {
                return (from p in lProd
                        where p.Sku == sku
                        select p).ToList();
            }

            return lProd;
        }

        private Produto Criar(Produto prod)
        {
            return new Produto(prod.Sku, prod.Nome, prod.Inventory, prod.IsMarketable);
        }

    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using crud.Entitys;
using crud.Entitys.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crud.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        protected DataBaseContext _context;
        private string _mensagem = "";

        public ProdutoController(DataBaseContext context)
        {
            _context = context;
        }

        // POST api/produtos
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] Produto produto)
        {
            if (_context.Produto.Where(p => p.Sku == produto.Sku).Any())
            {
                return StatusCode((int)HttpStatusCode.BadRequest, $"Já existe um produto cadatrado com este mesmo SKU: {produto.Sku}");
            }

            _context.Produto.Add(produto);
            _context.SaveChanges();

            return StatusCode((int)HttpStatusCode.Created);
        }

        // GET api/produtos/5
        [HttpGet("{sku}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<string> Get(int sku)
        {
            var produto = _context.Produto
                .Include(p => p.Inventory)
                .Include(p => p.Inventory.Warehouses)
                .FirstOrDefault(p => p.Sku == sku);

            if (produto != null)
            {
                produto.Inventory.Quantity = produto.Inventory.Warehouses.Count;
                if (produto.Inventory.Quantity > 0)
                {
                    produto.isMarketable = true;
                }
                else
                {
                    produto.isMarketable = false;
                }
            }

            return Ok(produto);
        }

        // PUT api/produtos/5
        [HttpPut("{sku}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put(int sku, [FromBody] Produto produtoUpdate)
        {
            var produto = _context.Produto
                .Include(p => p.Inventory)
                .Include(p => p.Inventory.Warehouses)
                .FirstOrDefault(p => p.Sku == sku);

            if(produto != null)
            {
                var retorno = Update(produtoUpdate, produto);
                if (!retorno)
                {
                    _mensagem = "Ocorreu um erro na atualização!!!";
                    return StatusCode((int)HttpStatusCode.InternalServerError, _mensagem);
                }
                _mensagem = "Atualização realizada com sucesso!!!";
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NoContent);
            }

            return Ok(_mensagem);
        }

        // DELETE api/produtos/5
        [HttpDelete("{sku}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete(int sku)
        {
            var produto = _context.Produto
                .Include(p => p.Inventory)
                .Include(p => p.Inventory.Warehouses)
                .FirstOrDefault(p => p.Sku == sku);

            if (produto != null)
            {
                foreach (var Warehouse in produto.Inventory.Warehouses)
                {
                    _context.Warehouses.Remove(Warehouse);
                }
                _context.Inventory.Remove(produto.Inventory);
                _context.Produto.Remove(produto);
                _context.SaveChanges();

                _mensagem = "Prudoto deletado com sucesso!!!";
            }
            else
            {
                return StatusCode((int)HttpStatusCode.NoContent);
            }

            return Ok(_mensagem);
        }

        private bool Update(Produto produtoUpdate, Produto produto)
        {
            produto.Sku = produtoUpdate.Sku;
            produto.Name = produtoUpdate.Name;

            foreach (var Whouse in produto.Inventory.Warehouses)
            {
                var warehouseUpdate = produtoUpdate.Inventory.Warehouses.FirstOrDefault(w => w.Locality.ToUpper() == Whouse.Locality.ToUpper());
                if (warehouseUpdate != null)
                {
                    Whouse.Quantity = warehouseUpdate.Quantity;
                    Whouse.Locality = warehouseUpdate.Locality;
                    Whouse.Type = warehouseUpdate.Type;

                    _context.Warehouses.Update(Whouse);
                    produtoUpdate.Inventory.Warehouses.Remove(warehouseUpdate);
                }
                else
                {
                    _context.Warehouses.Remove(Whouse);
                }
            }

            foreach (var Warehouse in produtoUpdate.Inventory.Warehouses)
            {
                Warehouse.IdInventory = produto.Inventory.IdInventory;
                _context.Warehouses.Add(Warehouse);
            }

            _context.Produto.Update(produto);
            _context.SaveChanges();

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Repositories;
using ProductCatalog.ViewModels.ProductViewModels;


namespace ProductCatalog.Controllers
{

    public class ProductController : Controller {

        private readonly ProductRepository _repository;

        public ProductController(ProductRepository repository){

            _repository = repository;
        }

        [Route("v1/products")]
        [HttpGet]

        public IEnumerable<ListProductViewModel> Get(){

            return _repository.Get();
        }

        [Route("v1/products{sku}")]
        [HttpGet]

        public Product Get(int sku){

            return _repository.Get(sku);
        }


        [Route("v1/products")]
        [HttpPost]

        public ResultViewModel Post([FromBody]EditorProductViewModel model){

            model.Validate();

            if (model.Invalid) 
                return new ResultViewModel
            {
                Success = false,
                Message = "Não foi possível cadastrar o produto",
                Data = model.Notifications
            };

            var product = new Product();
            product.name = model.name;
            product.sku = model.sku;
            product.inventory = model.inventory;
            

            _repository.Save(product);

            //Se der tudo certo retorna esse ResultViewModel
            return new ResultViewModel {

                Success = true,
                Message = "Produto cadastrado com sucesso",
                Data = product
            };
            
        }

        [Route("v1/products")]
        [HttpPut]

        public ResultViewModel Put([FromBody]EditorProductViewModel model){

            model.Validate();

            if(model.Invalid)
                return new ResultViewModel
                {
                    Success = false,
                    Message = "Não foi possível alterar o produto",
                    Data = model.Notifications
                };

            var product = _repository.Get(model.Sku);
            product.name = model.name;
            product.sku = model.sku;
            product.inventory = model.inventory;

            _repository.Update(product);


            return new ResultViewModel
            {
                Success = true,
                Message = "Produto alterado com sucesso!",
                Data = product

            };


        }

        [HttpDelete("{sku}")]
        public void Delete(int sku)
        {

            var product = _repository.Get(model.Sku);
            product.name = model.name;
            product.sku = model.sku;
            product.inventory = model.inventory;

            _repository.Delete(product);
        }
    

    }



}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductSolution.Domain.Entities;
using ProductSolution.Domain.Interfaces;

namespace ProductSolution.WebApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly IService _service;
        public ProductController(IService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([FromBody] Product product)
        {
            var result = _service.Create(product);
            bool validReturn = true;//Call some validation method or property from  result
            if (validReturn)
                return Ok();
            else
                return NotFound();
        }
        [HttpPut]
        public IActionResult Update(string sku ,[FromBody] Product product)
        {
            var result = _service.Update(sku,product);
            bool validReturn = true;//Call some validation method or property from  result
            if (validReturn)
                return Ok();
            else
                return NotFound();
        }
        [HttpGet]
        public IActionResult Get(string sku)
        {
            var result = _service.Get(sku);
            return Json(result);
        }
        [HttpDelete]
        public IActionResult Delete(string sku)
        {
             _service.Delete(sku);
            bool validReturn = true;//Call some validation method or property from  result
            if (validReturn)
                return Ok();
            else
                return NotFound();
        }
    }
}
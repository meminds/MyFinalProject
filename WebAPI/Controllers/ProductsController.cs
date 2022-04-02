using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   // ATTRIBUTE
    public class ProductsController : ControllerBase
    {
        //Loosely coupled
        //naming convention
        // IoC container  --- Inversion of Control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            // Dependency chain
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result); // result.Data vs. Ok();
            }
            return BadRequest(result); // result.message de yazılablir
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            // Dependency chain
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result); // result.Data vs. Ok();
            }
            return BadRequest(result); // result.message de yazılablir
        }

        [HttpPost("Add")]
        public IActionResult Add(Product product)
        {
            // Dependency chain
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result); // result.Data vs. Ok();
            }
            return BadRequest(result); // result.message de yazılablir
        }

    }
}

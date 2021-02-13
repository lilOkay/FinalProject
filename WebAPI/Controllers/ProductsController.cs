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
    [ApiController] //buna attribute nedir (bir class la ilgili bilgi verme imzalama demekmiş)
    public class ProductsController : ControllerBase
    {
        //loosely coupled 
        //naming convention
        //IoC container --- inversion of control
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _productService.GetAll();
            if (result.Succes)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
            
        [HttpPost]
        public IActionResult Post(Product product)//controlerın bildiği yer burası
        {
            var result = _productService.Add(product);
            if (result.Succes) //==işlem doğruysa
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Succes)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)//controlerın bildiği yer burası
        {
            var result = _productService.Add(product);
            if (result.Succes) //==işlem doğruysa
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}

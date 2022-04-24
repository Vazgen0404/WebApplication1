﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models.Products;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IRepository<Product> _productsContext;

        public ProductsController(IRepository<Product> repository)
        {
            _productsContext = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return await _productsContext.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var user = await _productsContext.Get(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product Product)
        {
            await _productsContext.Add(Product);

            return CreatedAtAction("Get", new { id = Product.Id }, Product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Product Product)
        {
            if (id != Product.Id)
            {
                return BadRequest();
            }

            try
            {
                await _productsContext.Update(Product);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Product = await _productsContext.Get(id);
            if (Product == null)
            {
                return NotFound();
            }

            await _productsContext.Delete(id);

            return NoContent();
        }

        private bool Exists(int id)
        {
            return _productsContext.Exists(id);
        }
    }
}

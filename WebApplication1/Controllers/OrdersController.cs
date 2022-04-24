using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models.Orders;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepository<Order> _ordersContext;

        public OrdersController(IRepository<Order> repository)
        {
            _ordersContext = repository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return await _ordersContext.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var Order = await _ordersContext.Get(id);

            if (Order == null)
            {
                return NotFound();
            }

            return Order;
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order user)
        {
            await _ordersContext.Add(user);

            return CreatedAtAction("Get", new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Order user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                await _ordersContext.Update(user);
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
            var Order = await _ordersContext.Get(id);
            if (Order == null)
            {
                return NotFound();
            }

            await _ordersContext.Delete(id);

            return NoContent();
        }

        private bool Exists(int id)
        {
            return _ordersContext.Exists(id);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;

        public OrdersController(IRepository<Order> repository, IMapper mapper)
        {
            _ordersContext = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            var orders = await _ordersContext.GetAll();
            var ordersDetailsDTOs = _mapper.Map<IEnumerable<Order>>(orders);

            return ordersDetailsDTOs;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var Order = await _ordersContext.Get(id);

            if (Order == null)
            {
                return NotFound();
            }
            var orderDto = _mapper.Map<Order>(Order);

            return orderDto;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);
            order.Date = DateTime.Now;
            
            await _ordersContext.Add(order);

            return CreatedAtAction("Get", new { id = order.Id }, orderDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderDTO orderDto)
        {
            if (id != orderDto.Id)
            {
                return BadRequest();
            }
            var order = _mapper.Map<Order>(orderDto);

            try
            {
                await _ordersContext.Update(order);
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

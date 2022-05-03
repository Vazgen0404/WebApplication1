using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models.Users;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository<User> _usersContext;
        private readonly ILogger<UsersController> _logger;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository<User> repository, ILogger<UsersController> logger, IMapper mapper)
        {
            _usersContext = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            var users = await _usersContext.GetAll();
            var usersDto = _mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(usersDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get(int id)
        {
            var user = await _usersContext.Get(id);

            if (user == null)
            {
                _logger.LogError("User Not Found");
                return NotFound();
            }
            var userDto = _mapper.Map<UserDTO>(user);

            return Ok(userDto);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _usersContext.Add(user);

            _logger.LogInformation("User created");
            return CreatedAtAction("Get", new { id = user.Id }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserDTO userDto)
        {
            if (id != userDto.Id)
            {
                _logger.LogError("Ids dont match ");

                return BadRequest();
            }
            var user = _mapper.Map<User>(userDto);
            try
            {
                await _usersContext.Update(user);
                _logger.LogInformation("User updated");

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    _logger.LogError("Id does not exist");
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
            var user = await _usersContext.Get(id);
            if (user == null)
            {
                _logger.LogError("Id does not exist");
                return NotFound();
            }

            await _usersContext.Delete(id);
            _logger.LogInformation("User deleted");

            return NoContent();
        }

        [HttpGet("maxOrder")]
        public async Task<UserDTO> UserWithMaxOrders()
        {
            var user = await _usersContext.UserWithMaxOrders();
            var userDto = _mapper.Map<UserDTO>(user);
            return userDto;
        }
        private bool Exists(int id)
        {
            return _usersContext.Exists(id);
        }
    }
}

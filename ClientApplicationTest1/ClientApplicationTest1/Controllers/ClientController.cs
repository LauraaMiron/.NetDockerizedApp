using ClientApplicationTest1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientApplicationTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientDbContext _clientDbContext;

        public ClientController(ClientDbContext clientDbContext)
        {
            _clientDbContext = clientDbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return _clientDbContext.Clients.ToList();
        }

        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Client>> GetById(int id)
        {
            var client = await _clientDbContext.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound(); // 404 Not Found if client is not found
            }

            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Client client)
        {
            if (client == null)
            {
                return BadRequest(); // 400 Bad Request if client is null
            }

            await _clientDbContext.Clients.AddAsync(client);
            await _clientDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateById(Client client)
        {
            if (client == null)
            {
                return BadRequest(); // 400 Bad Request if client is null
            }

            _clientDbContext.Clients.Update(client);
            await _clientDbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("Delete/{id}")]
        public async Task<ActionResult> DeleteById(int id)
        {
            var client = await _clientDbContext.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound(); // 404 Not Found if client is not found
            }

            _clientDbContext.Clients.Remove(client);
            await _clientDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}

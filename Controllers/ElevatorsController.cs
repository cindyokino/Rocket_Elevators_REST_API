using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rocket_Elevator_RESTApi.Models;
using Pomelo.EntityFrameworkCore.MySql;

namespace Rocket_Elevator_RESTApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Elevators")]
    [ApiController]
    public class ElevatorsController : ControllerBase
    {
        private readonly InformationContext _context;

        public ElevatorsController(InformationContext context)
        {
            _context = context;
        }

        // GET: api/Elevators
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Elevator>>> Getelevators()
        {
            return await _context.elevators.ToListAsync();
        }

        // GET: api/Elevators/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Elevator>> GetElevator(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);

            if (elevator == null)
            {
                return NotFound();
            }

            return elevator;
        }

        // PUT: api/Elevators/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElevator(long id, Elevator elevator)
        {
            if (id != elevator.id)
            {
                return BadRequest();
            }

            _context.Entry(elevator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElevatorExists(id))
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

        // POST: api/Elevators
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Elevator>> PostElevator(Elevator elevator)
        {
            _context.elevators.Add(elevator);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElevator", new { id = elevator.id }, elevator);
        }

        // DELETE: api/Elevators/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Elevator>> DeleteElevator(long id)
        {
            var elevator = await _context.elevators.FindAsync(id);
            if (elevator == null)
            {
                return NotFound();
            }

            _context.elevators.Remove(elevator);
            await _context.SaveChangesAsync();

            return elevator;
        }

        private bool ElevatorExists(long id)
        {
            return _context.elevators.Any(e => e.id == id);
        }
    }
}

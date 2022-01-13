#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commerce.Server.Data;
using Commerce.Shared.Models;

namespace Commerce.Server.Controllers.Setup
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly CommerceContext _context;

        public UnitOfMeasuresController(CommerceContext context)
        {
            _context = context;
        }

        // GET: api/UnitOfMeasures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnitOfMeasure>>> GetUnitOfMeasure([FromQuery] string companyId)
        {
            return await _context.UnitOfMeasure.Where(u => u.CompanyId == companyId).ToListAsync();
        }

        // GET: api/UnitOfMeasures/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnitOfMeasure>> GetUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _context.UnitOfMeasure.FindAsync(id);

            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            return unitOfMeasure;
        }

        // PUT: api/UnitOfMeasures/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnitOfMeasure(int id, UnitOfMeasure unitOfMeasure)
        {
            if (id != unitOfMeasure.UnitOfMeasureId)
            {
                return BadRequest();
            }

            _context.Entry(unitOfMeasure).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnitOfMeasureExists(id))
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

        // POST: api/UnitOfMeasures
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnitOfMeasure>> PostUnitOfMeasure(UnitOfMeasure unitOfMeasure)
        {
            _context.UnitOfMeasure.Add(unitOfMeasure);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnitOfMeasure", new { id = unitOfMeasure.UnitOfMeasureId }, unitOfMeasure);
        }

        // DELETE: api/UnitOfMeasures/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitOfMeasure(int id)
        {
            var unitOfMeasure = await _context.UnitOfMeasure.FindAsync(id);
            if (unitOfMeasure == null)
            {
                return NotFound();
            }

            _context.UnitOfMeasure.Remove(unitOfMeasure);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnitOfMeasureExists(int id)
        {
            return _context.UnitOfMeasure.Any(e => e.UnitOfMeasureId == id);
        }
    }
}

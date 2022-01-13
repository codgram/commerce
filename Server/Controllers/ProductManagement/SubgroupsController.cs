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

namespace Commerce.Server.Controllers.ProductManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubgroupsController : ControllerBase
    {
        private readonly CommerceContext _context;

        public SubgroupsController(CommerceContext context)
        {
            _context = context;
        }

        // GET: api/Subgroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubGroup>>> GetSubGroup([FromQuery] string companyId)
        {
            return await _context.SubGroup.Include(s => s.Group).ThenInclude(g => g.Category).Where(g => g.Group.Category.CompanyId == companyId).ToListAsync();
        }

        // GET: api/Subgroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubGroup>> GetSubGroup(int id)
        {
            var subGroup = await _context.SubGroup.FindAsync(id);

            if (subGroup == null)
            {
                return NotFound();
            }

            return subGroup;
        }

        // PUT: api/Subgroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubGroup(int id, SubGroup subGroup)
        {
            if (id != subGroup.SubGroupId)
            {
                return BadRequest();
            }

            _context.Entry(subGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubGroupExists(id))
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

        // POST: api/Subgroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubGroup>> PostSubGroup(SubGroup subGroup)
        {
            _context.SubGroup.Add(subGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubGroup", new { id = subGroup.SubGroupId }, subGroup);
        }

        // DELETE: api/Subgroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubGroup(int id)
        {
            var subGroup = await _context.SubGroup.FindAsync(id);
            if (subGroup == null)
            {
                return NotFound();
            }

            _context.SubGroup.Remove(subGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubGroupExists(int id)
        {
            return _context.SubGroup.Any(e => e.SubGroupId == id);
        }
    }
}

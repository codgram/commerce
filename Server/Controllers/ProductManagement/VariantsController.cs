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
    public class VariantsController : ControllerBase
    {
        private readonly CommerceContext _context;

        public VariantsController(CommerceContext context)
        {
            _context = context;
        }

        // GET: api/Variants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Variant>>> GetVariantByProduct([FromQuery] int productId)
        {
            return await _context.Variant.Include(v => v.Product).Where(v => v.ProductId == productId).ToListAsync();
        }

        // GET: api/Variants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Variant>> GetVariant(int id)
        {
            var variant = await _context.Variant.FindAsync(id);

            if (variant == null)
            {
                return NotFound();
            }

            return variant;
        }

        // PUT: api/Variants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVariant(int id, Variant variant)
        {
            if (id != variant.VariantId)
            {
                return BadRequest();
            }

            _context.Entry(variant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VariantExists(id))
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

        // POST: api/Variants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Variant>> PostVariant(Variant variant)
        {
            _context.Variant.Add(variant);
            await _context.SaveChangesAsync();
            var p = await _context.Product.FindAsync(variant.ProductId);
            return CreatedAtAction("GetVariant", new { id = variant.VariantId, product = p }, variant);
        }

        // DELETE: api/Variants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVariant(int id)
        {
            var variant = await _context.Variant.FindAsync(id);
            if (variant == null)
            {
                return NotFound();
            }

            _context.Variant.Remove(variant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VariantExists(int id)
        {
            return _context.Variant.Any(e => e.VariantId == id);
        }
    }
}

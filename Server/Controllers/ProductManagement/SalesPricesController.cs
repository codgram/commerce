using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Commerce.Server.Data;
using Commerce.Shared.Models.ProductManagement;

namespace Commerce.Server.Controllers.ProductManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPricesController : ControllerBase
    {
        private readonly CommerceContext _context;

        public SalesPricesController(CommerceContext context)
        {
            _context = context;
        }

        // GET: api/SalesPrices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesPrice>>> GetSalesPriceByVariant([FromQuery] int variantId)
        {
            return await _context.SalesPrice.Where(s => s.VariantId == variantId).ToListAsync();
        }

        // GET: api/SalesPrices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalesPrice>> GetSalesPrice(int id)
        {
            var salesPrice = await _context.SalesPrice.FindAsync(id);

            if (salesPrice == null)
            {
                return NotFound();
            }

            return salesPrice;
        }

        // PUT: api/SalesPrices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesPrice(int id, SalesPrice salesPrice)
        {
            if (id != salesPrice.SalesPriceId)
            {
                return BadRequest();
            }

            _context.Entry(salesPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesPriceExists(id))
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

        // POST: api/SalesPrices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SalesPrice>> PostSalesPrice(SalesPrice salesPrice)
        {
            _context.SalesPrice.Add(salesPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSalesPrice", new { id = salesPrice.SalesPriceId }, salesPrice);
        }

        // DELETE: api/SalesPrices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesPrice(int id)
        {
            var salesPrice = await _context.SalesPrice.FindAsync(id);
            if (salesPrice == null)
            {
                return NotFound();
            }

            _context.SalesPrice.Remove(salesPrice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalesPriceExists(int id)
        {
            return _context.SalesPrice.Any(e => e.SalesPriceId == id);
        }
    }
}

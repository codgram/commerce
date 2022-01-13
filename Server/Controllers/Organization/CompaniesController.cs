#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Commerce.Server.Controllers.Organization
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CommerceContext _context;
        private readonly UserManager<CommerceUser> _userManager;

        public CompaniesController(CommerceContext context, UserManager<CommerceUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var companyIds = await _context.Member.Where(m => m.CommerceUserId == userId).Select(m => m.CompanyId).ToArrayAsync();
            var companies = await _context.Company.Where(c => companyIds.Contains(c.CompanyId)).ToListAsync();

            return companies;
        }

        // GET: api/Companies
        [HttpGet("slugs/all")]
        public async Task<string[]> GetCompanySlugs()
        {
            return await _context.Company.Select(c => c.Slug).ToArrayAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{slug}")]
        public async Task<ActionResult<Company>> GetCompany(string slug)
        {
            return await _context.Company.FirstOrDefaultAsync(c => c.Slug == slug);
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(string id, Company company)
        {
            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(company).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
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

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company[]>> PostCompany(Company company)
        {
            if (!CompanySlugExists(company.Slug.Replace(" ", "")))
            {
                var user = await _userManager.GetUserAsync(User);
                var userId = user.Id;

                company.Slug = company.Slug.Replace(" ", "");
                _context.Company.Add(company);
                await _context.SaveChangesAsync();

                var member = new Member()
                {
                    CompanyId = company.CompanyId,
                    CommerceUserId = userId,
                    Type = MemberType.Owner
                };
                _context.Member.Add(member);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
            }
            else
            {
                return StatusCode(406, $"The Company {company.Name} already exists. Please try a new name");
            }
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(string id)
        {
            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Company.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(string id)
        {
            return _context.Company.Any(e => e.CompanyId == id);
        }

        private bool CompanySlugExists(string slug)
        {
            var company = _context.Company.FirstOrDefault(c => c.Slug.ToLower() == slug.ToLower());
            if (company == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

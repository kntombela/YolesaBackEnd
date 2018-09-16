 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YolesaBackend.Models;

namespace YolesaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariesController : ControllerBase
    {
        private readonly YolesaContext _context;

        public BeneficiariesController(YolesaContext context)
        {
            _context = context;
        }

        // GET: api/Beneficiaries
        [HttpGet]
        public IEnumerable<Beneficiary> GetBeneficiary()
        {
            return _context.Beneficiary;
        }

        // GET: api/Beneficiaries/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeneficiary([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var beneficiary = await _context.Beneficiary.FindAsync(id);

            if (beneficiary == null)
            {
                return NotFound();
            }

            return Ok(beneficiary);
        }

        // PUT: api/Beneficiaries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBeneficiary([FromRoute] int id, [FromBody] Beneficiary beneficiary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beneficiary.Id)
            {
                return BadRequest();
            }

            _context.Entry(beneficiary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeneficiaryExists(id))
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

        // POST: api/Beneficiaries
        [HttpPost]
        public async Task<IActionResult> PostBeneficiary([FromBody] Beneficiary beneficiary)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Beneficiary.Add(beneficiary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBeneficiary", new { id = beneficiary.Id }, beneficiary);
        }

        // DELETE: api/Beneficiaries/delete
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteBeneficiary(int[] ids)
        {
            foreach (int i in ids)
            {
                var beneficiary = await _context.Beneficiary.FindAsync(i);
                if (beneficiary == null)
                {
                    return NotFound();
                }
                _context.Beneficiary.Remove(beneficiary);
            }
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool BeneficiaryExists(int id)
        {
            return _context.Beneficiary.Any(e => e.Id == id);
        }
    }
}
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
    public class LeadsController : ControllerBase
    {
        private readonly YolesaContext _context;

        public LeadsController(YolesaContext context)
        {
            _context = context;
        }

        // GET: api/Leads
        [HttpGet]
        public IEnumerable<Lead> GetLead()
        {
            return _context.Lead;
        }

        // GET: api/Leads/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLead([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lead = await _context.Lead.FindAsync(id);

            if (lead == null)
            {
                return NotFound();
            }

            return Ok(lead);
        }

        // PUT: api/Leads/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead([FromRoute] int id, [FromBody] Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lead.LeadID)
            {
                return BadRequest();
            }

            _context.Entry(lead).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadExists(id))
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

        // POST: api/Leads
        [HttpPost]
        public async Task<IActionResult> PostLead([FromBody] Lead lead)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lead.Add(lead);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLead", new { id = lead.LeadID }, lead);
        }

        // DELETE: api/Leads/delete
        [HttpPost("delete")]
        public async Task<IActionResult> DeleteLead(int[] ids)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (int i in ids)
            {
                var lead = await _context.Lead.FindAsync(i);
                if (lead == null)
                {
                    return NotFound();
                }
                _context.Lead.Remove(lead);
            }
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool LeadExists(int id)
        {
            return _context.Lead.Any(e => e.LeadID == id);
        }
    }
}
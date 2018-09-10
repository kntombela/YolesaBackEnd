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
    public class GroupUsersController : ControllerBase
    {
        private readonly YolesaContext _context;

        public GroupUsersController(YolesaContext context)
        {
            _context = context;
        }

        // GET: api/GroupUsers
        [HttpGet]
        public IEnumerable<GroupUser> GetGroupUser()
        {
            return _context.GroupUser;
        }

        // GET: api/GroupUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupUser = await _context.GroupUser.FindAsync(id);

            if (groupUser == null)
            {
                return NotFound();
            }

            return Ok(groupUser);
        }

        // PUT: api/GroupUsers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupUser([FromRoute] int id, [FromBody] GroupUser groupUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != groupUser.GroupUserID)
            {
                return BadRequest();
            }

            _context.Entry(groupUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupUserExists(id))
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

        // POST: api/GroupUsers
        [HttpPost]
        public async Task<IActionResult> PostGroupUser([FromBody] GroupUser groupUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.GroupUser.Add(groupUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroupUser", new { id = groupUser.GroupUserID }, groupUser);
        }

        // DELETE: api/GroupUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var groupUser = await _context.GroupUser.FindAsync(id);
            if (groupUser == null)
            {
                return NotFound();
            }

            _context.GroupUser.Remove(groupUser);
            await _context.SaveChangesAsync();

            return Ok(groupUser);
        }

        private bool GroupUserExists(int id)
        {
            return _context.GroupUser.Any(e => e.GroupUserID == id);
        }
    }
}
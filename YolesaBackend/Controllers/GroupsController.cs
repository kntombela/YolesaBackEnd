using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YolesaBackend.Models;
using YolesaBackend.ViewModels;

namespace YolesaBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly YolesaContext _context;

        public GroupsController(YolesaContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public IEnumerable<GroupViewModel> GetGroup()
        {
            //return _context.Group;
            return GetGroupsViewModel();
        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @group = await _context.Group.FindAsync(id);

            if (@group == null)
            {
                return NotFound();
            }

            return Ok(@group);
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup([FromRoute] int id, [FromBody] Group @group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @group.Id)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        [HttpPost]
        public async Task<IActionResult> PostGroup([FromBody] Group @group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Group.Add(@group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.Id }, @group);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @group = await _context.Group.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Group.Remove(@group);
            await _context.SaveChangesAsync();

            return Ok(@group);
        }

        private bool GroupExists(int id)
        {
            return _context.Group.Any(e => e.Id == id);
        }

        private IEnumerable<GroupViewModel> GetGroupsViewModel()
        {
            //return (from g in _context.Group
            //        join m in _context.Member on g.Id equals m.GroupID
            //        group m by new
            //        {
            //            g.Id,
            //            g.Name,
            //            g.Industry,
            //            g.Type,
            //            g.PolicyNumber,
            //            g.DateModified

            //        } into x
            //        select new GroupViewModel
            //        {
            //            Id = x.Key.Id,
            //            Name = x.Key.Name,
            //            Industry = x.Key.Industry,
            //            Type = x.Key.Type,
            //            PolicyNumber = x.Key.PolicyNumber,
            //            DateModified = x.Key.DateModified,
            //            MemberCount = x.Count()
            //        }).ToList();
            //TODO:  Review performance implications
            return _context.Group.Select(
                g => new GroupViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Industry = g.Industry,
                    Type = g.Type,
                    PolicyNumber = g.PolicyNumber,
                    DateModified = g.DateModified,
                    MemberCount = _context.Member.Count(m => m.Id == g.Id)
                }).ToList();

        }
    }
}


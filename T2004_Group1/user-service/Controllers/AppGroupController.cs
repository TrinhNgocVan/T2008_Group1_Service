using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_service.Models;

namespace user_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppGroupController : ControllerBase
    {
        private readonly T2004_Group_1Context _context;

        public AppGroupController(T2004_Group_1Context context)
        {
            _context = context;
        }

        // GET: api/AppGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppGroup>>> GetAppGroups()
        {
            return await _context.AppGroups.ToListAsync();
        }

        // GET: api/AppGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppGroup>> GetAppGroup(long id)
        {
            var appGroup = await _context.AppGroups.FindAsync(id);

            if (appGroup == null)
            {
                return NotFound();
            }

            return appGroup;
        }

        // PUT: api/AppGroup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppGroup(long id, AppGroup appGroup)
        {
            if (id != appGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(appGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppGroupExists(id))
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

        // POST: api/AppGroup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppGroup>> PostAppGroup(AppGroup appGroup)
        {
            _context.AppGroups.Add(appGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppGroup", new { id = appGroup.Id }, appGroup);
        }

        // DELETE: api/AppGroup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppGroup(long id)
        {
            var appGroup = await _context.AppGroups.FindAsync(id);
            if (appGroup == null)
            {
                return NotFound();
            }

            _context.AppGroups.Remove(appGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppGroupExists(long id)
        {
            return _context.AppGroups.Any(e => e.Id == id);
        }
    }
}

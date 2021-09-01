using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_service.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using user_service.Dto;
namespace user_service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly T2004_Group_1Context _context;
        private readonly IMapper _mapper;
        public ProfileController(T2004_Group_1Context context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Profile
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileDto>>> GetProfiles()
        {

            var lsProfile = await _context.Profiles.ToListAsync();
            List<ProfileDto> lsProfileDto = new List<ProfileDto>() ;
            foreach(var p in lsProfile)
            {
                var pDto = _mapper.Map<ProfileDto>(p);
                pDto.FullSalary = p.Salary;
                lsProfileDto.Add(pDto);
            }
            return lsProfileDto;
        }
      

        // GET: api/Profile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<user_service.Models.Profile>> GetProfile(long id)
        {
            var profile = await _context.Profiles.FindAsync(id);

            if (profile == null)
            {
                return NotFound();
            }

            return profile;
        }

        // PUT: api/Profile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfile(long id, user_service.Models.Profile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            _context.Entry(profile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfileExists(id))
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

        // POST: api/Profile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<user_service.Models.Profile>> PostProfile(user_service.Models.Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfile", new { id = profile.Id }, profile);
        }

        // DELETE: api/Profile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(long id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfileExists(long id)
        {
            return _context.Profiles.Any(e => e.Id == id);
        }
    }
}

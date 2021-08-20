using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using user_service.Models;
using AutoMapper;
using user_service.Dto;
using user_service.Services.Implement;
using user_service.Repository;

namespace user_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly T2004_Group_1Context _context;
        private readonly IMapper _mapper;
        private readonly AppUserRepository _userRepo;
         // private readonly AppUserServiceImpl _userService;

        public AppUserController(T2004_Group_1Context context , IMapper mapper ,AppUserRepository userRepo )
        {
            _mapper = mapper;

            _context = context;
            _userRepo = userRepo;
           
         
            
        }

        // GET: api/AppUser
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserDto>>> GetAppUsers()
        {
            var users = await  _context.AppUsers.ToListAsync();
            if(users == null)
            {
                return NotFound();
            }
            List<AppUserDto> appUserDto = new List<AppUserDto>();
            foreach(var u in users)
            {
                appUserDto.Add(_mapper.Map<AppUserDto>(u));
            }
            foreach(var userDto in appUserDto)
            {
                // set groups and roles for Dto entity
                userDto.group = _userRepo.getListAppGroupsByUserId(userDto.Id);
                userDto.role = _userRepo.getListRolesByUserId(userDto.Id);
            }
            return appUserDto;
        }

        // GET: api/AppUser/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUserDto>> GetAppUser(long id)
        {
            var appUserDto = _mapper.Map<AppUserDto>(_userRepo.findById(id));
            appUserDto.group = _userRepo.getListAppGroupsByUserId(id);
            appUserDto.role = _userRepo.getListRolesByUserId(id);
            return (appUserDto == null) ? NotFound()
                                        : appUserDto;
        }

        // PUT: api/AppUser/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppUser(long id, AppUserDto appUserDto)
        {
            var appUser = _mapper.Map<AppUser>(appUserDto);
            if (id != appUser.Id)
            {
                return BadRequest();
            }

            _context.Entry(appUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(id))
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

        // POST: api/AppUser
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AppUser>> PostAppUser(AppUserDto appUserDto)
        {
            var appUser = _mapper.Map<AppUser>(appUserDto);
            _context.AppUsers.Add(appUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAppUser", new { id = appUser.Id }, appUser);
        }

        // DELETE: api/AppUser/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(long id)
        {
            var appUser = await _context.AppUsers.FindAsync(id);
            if (appUser == null)
            {
                return NotFound();
            }

            _context.AppUsers.Remove(appUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AppUserExists(long id)
        {
            return _context.AppUsers.Any(e => e.Id == id);
        }
    }
}

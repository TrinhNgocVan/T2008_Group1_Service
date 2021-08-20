using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_service.Models;
using user_service.Dto;
using AutoMapper;


namespace user_service.Services.Implement
{
    public class AppUserServiceImpl
    {
        private readonly T2004_Group_1Context _context;
        private readonly IMapper _mapper;
        public AppUserServiceImpl(T2004_Group_1Context context, IMapper mapper)
        {
            _mapper = mapper;

            _context = context;
        }
        public  AppUser findById(long id)
        {
            return _context.AppUsers.Where(user => user.Id == id).FirstOrDefault();
        }
        public  AppUserDto getUserById(long userId)
        {

            // get appUser and map to Dto
            var appUser = _context.AppUsers.FindAsync(userId);
            var appUserDto = _mapper.Map<AppUserDto>(appUser);
            // set groups in Dto 
            IEnumerable<GroupUser> groupUsers = _context.GroupUsers.Where(gu => gu.UserId == userId);
            List<AppGroup> groups = new List<AppGroup>();
            foreach (var g in groupUsers)
            {
                groups.Add(_context.AppGroups.Find(g.GroupId));
            }
            appUserDto.group = groups;
            // set Role
            IEnumerable<UserRole> userRoles = _context.UserRoles.Where(u => u.UserId == userId);
            List<Role> roles = new List<Role>();
            foreach(var u in userRoles)
            {
                roles.Add(_context.Roles.Find(u.RoleId));
            }
            appUserDto.role = roles;
            return appUserDto;
        }
    }
}

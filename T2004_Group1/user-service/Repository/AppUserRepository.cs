using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using user_service.Models;
using user_service.Dto;


namespace user_service.Repository 
{
    public class AppUserRepository : BaseRepository
    {
        private readonly T2004_Group_1Context _context;
        public AppUserRepository(T2004_Group_1Context context )
        {
            _context = context;
        }

        public AppUser findById(long id)
        {
            return _context.AppUsers.Where(user => user.Id == id).FirstOrDefault();
        }

        public AppUser findByName(string username)
        {
            return  _context.AppUsers.Where(u => u.Username == username).FirstOrDefault();
        }
        public user_service.Models.Profile  getProfileByUsername(string username)
        {

            return _context.Profiles.Where(p => p.Email == username ).FirstOrDefault();
        }

        public bool isExisted(long id)
        {
            throw new NotImplementedException();
        }
        public List<AppGroup> getListAppGroupsByUserId(long userId)
        {
            IEnumerable<GroupUser> groupUsers = _context.GroupUsers.Where(gu => gu.UserId == userId);
            List<AppGroup> groups = new List<AppGroup>();
            foreach (var g in groupUsers)
            {
                groups.Add(_context.AppGroups.Find(g.GroupId));
            }
            return groups;
        }
        public List<Role> getListRolesByUserId(long userId)
        {
            IEnumerable<UserRole> userRoles = _context.UserRoles.Where(u => u.UserId == userId);
            List<Role> roles = new List<Role>();
            foreach (var u in userRoles)
            {
                roles.Add(_context.Roles.Find(u.RoleId));
            }
            return roles ;
        }
    }
}

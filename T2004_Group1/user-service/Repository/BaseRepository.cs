using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using user_service.Models;
namespace user_service.Repository
{
    interface BaseRepository
    {
        AppUser findById(long id);
        AppUser findByName(string username);
        Boolean isExisted(long id);

    }
}

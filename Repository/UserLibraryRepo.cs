using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLibraryAPI.Models;

namespace UserLibraryAPI.Repository
{
    public class UserLibraryRepo : IUserLibraryRepo
    {
        private readonly SpotifyDemoDbContext _context;

        public UserLibraryRepo(SpotifyDemoDbContext context)
        {
            _context = context;
        }

        public Task<UserLibrary> DeleteUserLibrary(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserLibrary> GetUserLibraryDetails()
        {
            return _context.UserLibrary.ToList();
        }

        public UserLibrary GetUserLibraryDetailsById(int id)
        {
            UserLibrary userlibdata = _context.UserLibrary.Find(id);
            return userlibdata;
        }

        public async Task<UserLibrary> PostUserLibrary(UserLibrary userlib)
        {
            UserLibrary userlibdata = null;
            if (userlib == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                userlibdata = new UserLibrary() {Userid=userlib.Userid,Playlist=userlib.Playlist};
                await _context.UserLibrary.AddAsync(userlibdata);
                await _context.SaveChangesAsync();

            }
            return userlibdata;
        }

      


    }
}

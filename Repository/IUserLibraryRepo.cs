using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLibraryAPI.Models;

namespace UserLibraryAPI.Repository
{
    public interface IUserLibraryRepo
    {
        IEnumerable<UserLibrary> GetUserLibraryDetails();

        UserLibrary GetUserLibraryDetailsById(int id);


        Task<UserLibrary> PostUserLibrary(UserLibrary userlib);

        Task<UserLibrary> DeleteUserLibrary(int id);
    }
}

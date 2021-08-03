using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLibraryAPI.Models;
using UserLibraryAPI.Repository;

namespace UserLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLibraryController : ControllerBase
    {
        private readonly IUserLibraryRepo _userlibraryrepo;

        public UserLibraryController(IUserLibraryRepo userlibrarytrepo)
        {
            _userlibraryrepo = userlibrarytrepo;
        }

        [HttpGet]
        public IEnumerable<UserLibrary> GetAllPlaylistDetails()
        {
            return _userlibraryrepo.GetUserLibraryDetails();
        }

        [HttpGet("{id}")]
        public IActionResult GetUserLibraryById(int id)
        {
            try
            {
                var userlib = _userlibraryrepo.GetUserLibraryDetailsById(id);
                if (userlib == null)
                {
                    return NotFound();
                }
                return Ok(userlib);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostUserlibarary(UserLibrary userlib)
        {
            try
            {
                var adduserlib = await _userlibraryrepo.PostUserLibrary(userlib);
                return Ok(adduserlib);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserLibrary(int id)
        {
            try
            {
                var deleteuserlib = await _userlibraryrepo.DeleteUserLibrary(id);
                return Ok(deleteuserlib);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

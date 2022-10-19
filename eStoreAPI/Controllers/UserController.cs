using BusinessObject;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository repository = new UserRepository();
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IEnumerable<User> Get() => repository.GetUsers();

        [HttpPost]


        public async Task<IActionResult> PostUser(AddUserRequest request)
        {

            User newUser = new()
            {
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber

            };

            var rs = await _userManager.CreateAsync(newUser, request.Password);
            if (rs.Succeeded)
            {
                return Ok();
            }

            return NoContent();


         
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Login(string email, string password)
        {
            var rs = await _signInManager.PasswordSignInAsync(email, password, false, true);
            if (rs.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    var userName = await _userManager.FindByNameAsync(email);
                    return Ok(userName);
                }

                return Ok(user);
            }
            return NoContent();
        }

        [HttpPost("auth/register")]


        public async Task<IActionResult> Register(string email, string username, string password)
        {
            var user = new User
            {
                Email = email,
                UserName = username,
            };
            var rs = await _userManager.CreateAsync(user, password);

            if (rs.Succeeded)
            {
                return Ok();
            }
            
            return Ok();
        }

        [Route("{id}")]
        [HttpGet]


        public IActionResult Get([FromRoute] string id)
        {
            var mem = repository.UserById(id);
            if (mem == null)
            {
                return NotFound();
            }
            return Ok(mem);
        }

        [HttpDelete("{key}")]
        public IActionResult Delete([FromRoute] string key)
        {
            var rs = repository.DeleteUser(key);
            if (rs)
            {
                return Ok();
            }
            return NoContent();
        }

        [HttpPut]
        [Route("{key}")]


        public IActionResult Put([FromRoute] string key, UpdateUserRequest request)
        {

            var rs = repository.UpdateUser(key,request);
            if (rs)
            {
                return Ok();
            }
            return NoContent();
        }
    }
}

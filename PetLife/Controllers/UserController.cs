using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models.User;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using Azure.Core;

namespace PetLife.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;
        

        public UserController(DataContext context  )
        {
            _context = context;

            
        }

        [HttpGet("get-user-by-id")]
        public  IActionResult GetUserById([FromQuery] String email)
        {
            var user =  _context.Users.Where(u => u.Email == email);
            if(user == null )
            {
                return NotFound();
            }
            else
            {
                return Ok(user.First().UserId);
            }
            
        }

        [HttpGet("get-user-info")]
        public IActionResult GetUserInfo([FromQuery] String email)
        {
            var user = _context.Users.Where(u => u.Email == email);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }

        }




        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUser request)
        {
            if (_context.Users.Any(u => u.Email == request.Email))
            {
                return BadRequest("User already exists.");
            }



            var user = new User
            {
                UserId = CreateRandomToken(8),
                ProfileUrl = request.ProfileUrl,
                FullName = request.FullName,
                Email = request.Email,
                Password = request.Password,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User successfully created!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUser request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            if (user.Password != request.Password)
            {
                return BadRequest("Password is incorrect.");
            }

            return Ok("Welcome");
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> DeleteUser(DeleteUser request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok("User Deleted");
        }
        private string CreateRandomToken(int lenght)
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(lenght));
        }


    }
}

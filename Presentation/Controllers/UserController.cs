using Application;
using Application.Interfaces;
using Azure.Identity;
using Domain.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDo.DTOs;

namespace Presentation.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        Behaviour behaviours;
        public UserController(IDb dbFuncts) 
        {
            behaviours = new(dbFuncts);
        }

        [Route("/signup")]
        [HttpPost]
        public ActionResult signup(UserDTO usr)
        {

            if(behaviours.UserExists(usr.Username))
                return BadRequest();

            User user = new User
            {
                Name = usr.Name,
                Username = usr.Username,
                Password = usr.Password
            };
            
            behaviours.AddUser(user);
            return Ok(user);
        }
        
        [Route("/login")]
        [HttpPost]
        public async Task<ActionResult> login([FromForm] string username, [FromForm] string password)
        {
            User user = behaviours.GetUser(username, password);
            
            if (user is null) return NotFound();
            
            var claims = new[] { 
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.Name),
                new Claim("username", user.Username), 
            };

            await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "user")));
            return Ok($"logged in as {user.Username}");
        }
        
        [HttpGet]
        [Route("/logout")]
        public async Task<ActionResult> logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }
    }
}
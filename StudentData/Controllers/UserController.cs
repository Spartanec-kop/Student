using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentData.Domain.Core;
using StudentData.Infrastructure.Data;
using StudentData.Services.Interfaces;

namespace StudentData.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly StudentContext db;
        private readonly ITokenService _tokenService;

        public UserController(StudentContext context, ITokenService tokenService)
        {
            db = context;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpGet("auth")]
        public async Task<string> AuthUser(string login, string password)
        {
            var user = db.Users.FirstOrDefault(r => r.Login == login && r.Password == password);
            if (user == null)
            {
                return null;
            }
            return _tokenService.Generate(user.Login);
        }

        // GET: api/User/all
        [HttpGet("all")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await db.Users.ToListAsync();
        }

        // GET: api/User
        [HttpGet]
        public async Task<Object> GetUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                List<Claim> claims = identity.Claims.ToList();

                User user = db.Users.FirstOrDefault(f => f.Login == claims[0].Value);
                return new {
                    id = user.Id,
                    login = user.Login,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    middleName = user.MiddleName
                };
            }
            else
            {
                throw new Exception("Токен не определен");
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await db.Users.FindAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (!UserExists(user.Login))
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        private bool UserExists(string login)
        {
            return db.Users.Any(e => e.Login == login);
        }
    }
}

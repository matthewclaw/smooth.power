using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Attributes;
using Server.Middleware.Attributes;
using Smooth.Power.Data.Entities;
using Smooth.Power.Data.Models;
using Smooth.Power.Logic;
using Smooth.Power.Logic.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smooth.power.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        private readonly SmoothPowerContext _context;
        public UserController(ILogger<UserController> logger,
            SmoothPowerContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpPost("login")]
        public async Task<User> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToUpper() == request.Email.ToUpper() 
            && u.Password == request.Password.Hash());

            if (user == null)
            {
                Response.StatusCode = StatusCodes.Status401Unauthorized;
                return null;
            }
            else
            {
                var response = (User)user;
                response.Token = user.GenerateJwtToken();
                return response;
            }
        }
        [Authorize]
        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            return Ok();
        }
    }
}

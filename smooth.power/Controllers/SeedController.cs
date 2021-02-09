using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server.Attributes;
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
    public class SeedController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SeedController> _logger;

        private readonly SmoothPowerContext _context;
        public SeedController(ILogger<SeedController> logger,
            SmoothPowerContext context)
        {
            _logger = logger;
            _context = context;
        }

        [SeedKeyRequired]
        [HttpDelete("purge")]
        public async Task<IActionResult> Purge()
        {
            {
                try
                {
                    _logger.LogInformation("Purging Database");
                    
                    if(await _context.Database.EnsureDeletedAsync())
                    {
                        _logger.LogInformation("Database Deleted");
                    }
                    if (await _context.Database.EnsureCreatedAsync())
                    {
                        _logger.LogInformation("Database Created");
                    }
                    return Ok();
                }
                catch(Exception e)
                {
                    _logger.LogError(e,"Purge failed");
                    return BadRequest(e.Message);
                }
            }
        }
        [SeedKeyRequired]
        [HttpPost("user")]
        public IActionResult newUser([FromBody] User user)
        {
            user.Password = user.Password.Hash();
            user.IsAdmin = true;
            _context.Users.Add((UserEntity)user);
            _context.SaveChanges();
            return Ok();
        }
    }
}

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smooth.Power.Logic
{
    public class Settings
    {
        public static string SeedKey { get; set; } 
        public static string DefaultConnectionString { get; set; }
        public static string JwtSecret { get; set; }
        public static string JwtLifetime { get; set; }
        public Settings()
        {
            SeedKey = string.Empty;
            DefaultConnectionString = string.Empty;
            JwtSecret = string.Empty;
            JwtLifetime = "5days";
        }
    }
}

using Smooth.Power.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace Smooth.Power.Data.Models
{
    public class User
    {
        public static explicit operator User(UserEntity ue)
        {
            return new User
            {
                Name = ue.Name,
                Email = ue.Email,
                LastName = ue.LastName,
                Password = ue.Password,
                IsAdmin = ue.IsAdmin,
                IsClientAdmin = ue.IsClientAdmin
            };
        }
        public static explicit operator UserEntity(User ue)
        {
            return new UserEntity
            {
                Name = ue.Name,
                Email = ue.Email,
                LastName = ue.LastName,
                Password = ue.Password,
                IsAdmin = ue.IsAdmin,
                IsClientAdmin = ue.IsClientAdmin
            };
        }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsClientAdmin { get; set; }
        public string Token { get; set; }
    }
}

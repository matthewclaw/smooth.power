using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Smooth.Power.Data.Entities;
using Smooth.Power.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Middleware.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserEntity)context.HttpContext.Items["User"];
            if (user == null)
            {
                object msg = "";
                if (!context.HttpContext.Items.TryGetValue("JwtError", out msg))
                {
                    msg = "Unauthorized";
                }
                context.Result = new JsonResult(new { message = (string)msg }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Smooth.Power.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Attributes
{
    public class SeedKeyRequiredAttribute : Attribute, IAuthorizationFilter
    {
        public SeedKeyRequiredAttribute()
        {

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.ContainsKey("x-sp-seedkey") || string.IsNullOrEmpty(context.HttpContext.Request.Headers["x-sp-seedkey"])
                || context.HttpContext.Request.Headers["x-sp-seedkey"] != Settings.SeedKey)
            {
                context.Result = new UnauthorizedObjectResult("Invalid Seed");
            }
        }
    }
}

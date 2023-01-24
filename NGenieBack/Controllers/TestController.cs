using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.OAuth;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace NGenieBack.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {

        [Authorize]
        [HttpGet("test")]
        public IActionResult Test()
        {
            Claim? value = HttpContext.User.Claims
                            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
            return base.Ok(value.Value);

        }

    }
}

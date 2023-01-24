using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using NGenieBack.Auth;
using NGenieBack.Database;
using NGenieBack.Database.Models;
using Microsoft.AspNetCore.OData.Routing.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : Controller
{
    [AllowAnonymous]
    [HttpPost]
    public ActionResult<string> Post (
        AuthenticationRequest authRequest,
        [FromServices] IJwtSigningEncodingKey signingEncodingKey,
        [FromServices] Context context
    )
    {
        var u = context.Users.Find(authRequest.Name);
        if (u is not User user) 
            return Unauthorized();

        var hash = PasswordHashing.HashString(authRequest.Password, user.PasswordSalt);

        if (hash != user.PasswordHash) 
            return Unauthorized();

        // Генерируем JWT.
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, authRequest.Name)
        };
        var token = new JwtSecurityToken(
            issuer: "DemoApp",
            audience: "DemoAppClient",
            claims: claims,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: new SigningCredentials(
                    signingEncodingKey.GetKey(),
                    signingEncodingKey.SigningAlgorithm)
        );

        string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return jwtToken;
    }

}

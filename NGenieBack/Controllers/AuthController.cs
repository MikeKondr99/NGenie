using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using NGenieBack.Auth;
using NGenieBack.Database;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using NGenieBack.Database.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NGenieBack.Repositories;

namespace NGenieBack.Controllers;

[Route("api/auth")]
public class AuthController : Controller
{
    private readonly UserRepository _users;
    public AuthController(UserRepository users)
    {
        _users = users;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<User>> GetUserAsync()
    {
        var name = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        return Ok(await _users.GetAsync(name));
    }

    [HttpPost]
    [AllowAnonymous]
    public ActionResult<string> CreateToken(
        [FromBody] AuthenticationRequest authRequest,
        [FromServices] IJwtSigningEncodingKey signingEncodingKey,
        [FromServices] Context context
    )
    {
        var u = context.Users.Find(authRequest.Username);
        if (u is not User user)
            return Unauthorized();

        var hash = PasswordHashing.HashString(authRequest.Password, user.PasswordSalt);

        if (hash != user.PasswordHash)
            return Unauthorized();

        // Генерируем JWT.
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.NameIdentifier, authRequest.Username)
        };
        var token = new JwtSecurityToken(
            issuer: "DemoApp",
            audience: "DemoAppClient",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: new SigningCredentials(
                    signingEncodingKey.GetKey(),
                    signingEncodingKey.SigningAlgorithm)
        );

        string jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
        return jwtToken;
    }


}

public interface IHasKey<T>
{
    public T Id { get; set; }
}



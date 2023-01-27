using Microsoft.IdentityModel.Tokens;

namespace NGenieBack.Auth;

public static class AuthHelper
{
    public static void AddJwtAuth(this IServiceCollection services)
    {
        // TODO: Security risk
        const string signingSecurityKey = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234n1k41230";
        var signingKey = new SigningSymmetricKey(signingSecurityKey);
        services.AddSingleton<IJwtSigningEncodingKey>(signingKey);
        const string jwtSchemeName = "JwtBearer";
        var signingDecodingKey = (IJwtSigningDecodingKey)signingKey;
        services
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = jwtSchemeName;
                options.DefaultChallengeScheme = jwtSchemeName;
            })
            .AddJwtBearer(jwtSchemeName, jwtBearerOptions =>
            {
                jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingDecodingKey.GetKey(),

                    ValidateIssuer = true,
                    ValidIssuer = "DemoApp",

                    ValidateAudience = true,
                    ValidAudience = "DemoAppClient",

                    ValidateLifetime = true,

                    ClockSkew = TimeSpan.FromSeconds(5)
                };
            });
    }
}

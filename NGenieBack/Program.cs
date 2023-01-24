using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.Runtime.Intrinsics.X86;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using NGenieBack.Database;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using NGenieBack.OData;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NGenieBack.Auth;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.AddDbContext<Context>(options => {
    options.UseSqlite("Data Source=db.sqlite;");
});

//Auth
const string signingSecurityKey = "0d5b3235a8b403c3dab9c3f4f65c07fcalskd234n1k41230";
var signingKey = new SigningSymmetricKey(signingSecurityKey);
services.AddSingleton<IJwtSigningEncodingKey>(signingKey);

services.AddControllers();

const string jwtSchemeName = "JwtBearer";
var signingDecodingKey = (IJwtSigningDecodingKey)signingKey;
services
    .AddAuthentication(options => {
        options.DefaultAuthenticateScheme = jwtSchemeName;
        options.DefaultChallengeScheme = jwtSchemeName;
    })
    .AddJwtBearer(jwtSchemeName, jwtBearerOptions => {
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


services.AddControllers()
    .AddOData(options => {
        options.Select().Filter().OrderBy().Count().SetMaxTop(null);
        options.AddRouteComponents("api/odata", Edm.Model());
    });

// Подключаем Swagger
services.AddSwaggerGen();

// Работа с файлами
services.AddSingleton<IFileProvider>(
       new PhysicalFileProvider(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)));

// Validation
services.AddFluentValidationAutoValidation();
//services.AddValidatorsFromAssemblyContaining<UsernameValidator>();


// !Build
var app = builder.Build();


// Auth
app.UseAuthentication();
app.UseAuthorization();

// Контроллеры
app.MapControllers();

// TODO: Используем CORS (правда настроен ужасно)
app.UseCors(builder =>
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);


// Используем Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}



app.Run();
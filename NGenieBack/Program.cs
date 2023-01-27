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


services.AddDbContext<Context>(options =>
{
    options.UseSqlite("Data Source=db.sqlite;");
});


services.AddJwtAuth();

services.AddControllers()
    .AddOData(options =>
    {
        options.Select().Filter().OrderBy().Count().SetMaxTop(null);
        options.AddRouteComponents("api/odata", Edm.Model());
    });

// Подключаем Swagger
services.AddSwaggerGen();

// Validation
services.AddFluentValidationAutoValidation();
//services.AddValidatorsFromAssemblyContaining<UsernameValidator>();

// !Build
// ----------------------------
var app = builder.Build();
// ----------------------------


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
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}



app.Run();

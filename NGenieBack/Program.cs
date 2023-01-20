using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.Runtime.Intrinsics.X86;
using System.Reflection;
using System.IO;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddSingleton<IFileProvider>(
       new PhysicalFileProvider(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName)));

var app = builder.Build();

app.MapControllers();
app.UseCors(builder =>
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
); ;

app.Run();


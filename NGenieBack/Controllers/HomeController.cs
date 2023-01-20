using Microsoft.AspNetCore.Mvc;
using System.IO;
using NGenieBack.Models;
using System.Net.Mime;
using System.Diagnostics;

namespace NGenieBack.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet("/{id}")]
        public string Get([FromRoute] string id)
        {
            var path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + $"/Articles/{id}.md";
            using var sr = new StreamReader(path);
            return sr.ReadToEnd();
        }

    }
}

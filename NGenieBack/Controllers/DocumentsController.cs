using NGenieBack.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using FluentValidation.AspNetCore;
using NGenieBack.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text;
using NGenieBack.Database.Requests;
using NGenieBack.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace NGenieBack.Controllers;

[Route("api/docs")]
public class DocumentsController : Controller
{
    readonly DocumentRepository _repos;
    public DocumentsController(DocumentRepository repos)
    {
        _repos = repos;
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(Guid id)
    {
        return Ok(await _repos.GetAsync(id, t => t.Include(d => d.Owner))).Or(NotFound());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] object o)
    {
        throw new NotImplementedException();
        //return Ok(await _repos.CreateAsync(o.Create())).Or(BadRequest());
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync([FromRoute] Guid id, [FromBody] UpdateDocument o)
    {
        return Ok(await _repos.UpdateAsync(id,o)).Or(NotFound());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        return Ok(await _repos.DeleteAsync(id)).Or(NotFound());
    }


}


public static class OkExtentions
{
    public static IActionResult Or(this OkObjectResult ok, IActionResult alt)
    {
        return ok.Value is null ? alt : ok;
    }
}
using NGenieBack.Database;
using NGenieBack.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using FluentValidation.AspNetCore;
using NGenieBack.Repositories;
using NGenieBack.Dto;
using Microsoft.AspNetCore.Mvc.Infrastructure;

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
        return Ok(await _repos.GetAsync(id)).Or(NotFound());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] DocumentPostDto o)
    {
        return Ok(await _repos.CreateAsync(o.Create())).Or(BadRequest());
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync([FromRoute] Guid id, [FromBody] DocumentPatchDto o)
    {
        if(await _repos.GetAsync(id) is Document doc)
        {
            return Ok(await _repos.UpdateAsync(o.Patch(doc))).Or(NotFound());
        }
        return NotFound();

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
        if (ok.Value is null)
            return alt;
        else
            return ok;
    }
}
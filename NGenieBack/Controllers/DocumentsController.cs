﻿using NGenieBack.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using FluentValidation.AspNetCore;
using NGenieBack.Repositories;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text;

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
    public async Task<IActionResult> PostAsync([FromBody] object o)
    {
        throw new NotImplementedException();
        //return Ok(await _repos.CreateAsync(o.Create())).Or(BadRequest());
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchAsync([FromRoute] Guid id, [FromBody] object o)
    {
        throw new NotImplementedException();
        //if(await _repos.GetAsync(id) is Document doc)
        //{
        //    return Ok(await _repos.UpdateAsync(o.Patch(doc))).Or(NotFound());
        //}
        //return NotFound();

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
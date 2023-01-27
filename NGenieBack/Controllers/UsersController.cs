using NGenieBack.Database;
using NGenieBack.Database.Models;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Authorization;
using SQLitePCL;

namespace NGenieBack.Controllers;

public class UsersController : DefaultRepositoryController<User, string>
{
    public UsersController(Context db) : base(db, db.Users)
    {
    }



   [EnableQuery]
    public IQueryable<User> Get() =>
        DefaultGet();

    [EnableQuery]
    public SingleResult<User> Get(string key) =>
        DefaultGet(key);

    //[EnableQuery]
    //public async Task<IActionResult> PostAsync([FromBody] UserPostDto postDto) =>
    //    await DefaultPostAsync(postDto);

    //[EnableQuery]
    //public async Task<IActionResult> PatchAsync(Guid key, [FromBody] UserPatchDto postDto) =>
    //    await DefaultPatchAsync(key, postDto);

    [EnableQuery]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(string key) =>
        await DefaultDeleteAsync(key);
}


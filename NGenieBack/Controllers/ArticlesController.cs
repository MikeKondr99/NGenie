using NGenieBack.Database;
using NGenieBack.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace NGenieBack.Controllers;

public class ArticlesController : DefaultRepositoryController<Article, Guid>
{
    public ArticlesController(Context db) : base(db, db.Articles)
    {
    }



    [EnableQuery]
    public IQueryable<Article> Get() =>
         DefaultGet();

    [EnableQuery]
    public SingleResult<Article> Get(Guid key) =>
        DefaultGet(key);

    //[EnableQuery]
    //public async Task<IActionResult> PostAsync([FromBody] ArticlePostDto postDto) =>
    //    await DefaultPostAsync(postDto);

    //[EnableQuery]
    //public async Task<IActionResult> PatchAsync(Guid key, [FromBody] ArticlePatchDto postDto) =>
    //    await DefaultPatchAsync(key, postDto);

    [EnableQuery]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteAsync(Guid key) =>
        await DefaultDeleteAsync(key);
}
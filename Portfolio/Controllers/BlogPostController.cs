using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Models.PortfolioBlogging;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        public PortfolioBloggingContext context { private get; init; }
        public BlogPostController(PortfolioBloggingContext context) => this.context = context;

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> GetBlogCountAsync() => Ok(await context.Blogs.CountAsync());
        

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> GetPostsCountAsync(int BlogId) => Ok(await context.Posts.Where(p => p.BlogID == BlogId).CountAsync());

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<PostView>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> GetPostsAsync(int BlogId, int Page = 1) => Ok(
            (await context.Posts
                .Where(p => p.BlogID == BlogId)
                .ToListAsync())
            .Skip(10 * Page)
            .Select(p => p.ConvertToPostView())
        );

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> CreateBlogAsync(BlogView blogView)
        {
            context.Blogs.Add(blogView.ConvertToBlog());

            int changed = await context.SaveChangesAsync();

            return Ok(changed > 0);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> CreatePostAsync(PostView postView)
        {
            context.Posts.Add(postView.ConvertToPost());

            int changed = await context.SaveChangesAsync();

            return Ok(changed > 0);
        }

    }
}

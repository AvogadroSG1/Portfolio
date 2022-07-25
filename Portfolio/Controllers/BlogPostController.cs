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

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> CreateBlogAsync(BlogView blogView)
        {
            context.Blogs.Add(blogView.ConvertToBlog());

            int changed = await context.SaveChangesAsync();

            return Ok(changed > 0);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(IEnumerable<BlogView>), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> GetBlogsAsync()
            => Ok((await context.Blogs.ToListAsync()).Select(b => b.ConvertToBlogView()));

        [HttpDelete("[action]")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> DeleteBlogAsync(int blogId)
        {
            context.Remove(await context.Blogs.SingleAsync(b => b.BlogID == blogId));

            int changed = await context.SaveChangesAsync();

            return Ok(changed > 0);
        }

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
                .Skip((Page - 1) * 10)
                .Take(10)
                .ToListAsync())
            .Select(p => p.ConvertToPostView())
        );

        [HttpPost("[action]")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> CreatePostAsync(PostView postView)
        {
            context.Posts.Add(postView.ConvertToPost());

            int changed = await context.SaveChangesAsync();

            return Ok(changed > 0);
        }

        [HttpPatch("[action]")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> UpdatePostAsync(PostView postView)
        {
            var postToUpdate = await context.Posts.SingleOrDefaultAsync(p => p.PostID == postView.PostId);

            if (postToUpdate is null)
            {
                return BadRequest("Invalid Post");
            }

            postToUpdate.Content = postView.Content;

            int changed = await context.SaveChangesAsync();

            return Ok(changed > 0);
        }


        [HttpDelete("[action]")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> DeletePostAsync(int postId)
        {
            (await context.Posts.SingleAsync(b => b.PostID == postId)).IsDeleted = true;

            int changed = await context.SaveChangesAsync();

            return Ok(changed > 0);
        }

        [HttpDelete("[action]")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesErrorResponseType(typeof(Exception))]
        public async Task<IActionResult> PermanentlyDeletePostAsync(int postId)
        {
            context.Remove(await context.Posts.SingleAsync(b => b.PostID == postId));

            int changed = await context.SaveChangesAsync();

            return Ok(changed > 0);
        }

    }
}

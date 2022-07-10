using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;

namespace Portfolio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        public PortfolioBloggingContext context { private get; init; }
        public BlogPostController(PortfolioBloggingContext context) => this.context = context;

        [HttpGet("[action]")]
        [Authorize]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        public async Task<IActionResult> Test()
        {
            return Ok(await context.Blogs.CountAsync());
        }
    }
}

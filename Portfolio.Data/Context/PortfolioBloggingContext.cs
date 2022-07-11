using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Data.Models.PortfolioBlogging;

namespace Portfolio.Data.Context
{
    public class PortfolioBloggingContext : DbContext
    {
        public class BloggingContextFactory : IDesignTimeDbContextFactory<PortfolioBloggingContext>
        {
            public PortfolioBloggingContext CreateDbContext(string[] args)
            {
                IServiceCollection services = new ServiceCollection();

                services.AddDbContext<PortfolioBloggingContext>(options => options.UseNpgsql("Host=solaria;Database=BlogDb;Username=Peter;Password=1PeterPassword!;"));

                return services.BuildServiceProvider().GetService<PortfolioBloggingContext>();
            }
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public PortfolioBloggingContext(DbContextOptions<PortfolioBloggingContext> options) : base(options)
        {
        }
    }
}

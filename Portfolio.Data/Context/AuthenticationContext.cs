using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using Portfolio.Data.Models.Authentication;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace Portfolio.Data.Context;

public class AuthenticationContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public class AuthenticationContextFactory : IDesignTimeDbContextFactory<AuthenticationContext>
    {
        public AuthenticationContext CreateDbContext(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<AuthenticationContext>(options => options.UseNpgsql("Host=solaria;Database=Authentication;Username=Peter;Password=1PeterPassword!;"));
            services.Configure<OperationalStoreOptions>(x => { });

            return services.BuildServiceProvider().GetService<AuthenticationContext>();
        }
    }

    public AuthenticationContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions)
        : base(options, operationalStoreOptions)
    {
        
    }
}

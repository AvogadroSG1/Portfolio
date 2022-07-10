using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Portfolio.Data.Context;
using Portfolio.Data.Models.Authentication;
//dotnet publish
// dotnet publish "/Users/Avogadro/Projects/Portfolio/Portfolio/Portfolio.csproj" --configuration "Release" --output "../../PublishOutput/Portfolio"
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "wwwroot/client-app";
});

builder.Services.AddDbContext<PortfolioBloggingContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("BloggingContext")!));

builder.Services.AddDbContext<AuthenticationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AuthenticationContext")!));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AuthenticationContext>();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, AuthenticationContext>();

builder.Services.AddAuthentication()
    .AddIdentityServerJwt();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerDocument();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseOpenApi();
app.UseSwaggerUi3();

app.UseAuthentication();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");
app.MapRazorPages();

if (!app.Environment.IsDevelopment())
{
    app.UseSpa(spa =>
    {

        spa.Options.SourcePath = "ClientApp";
        if (app.Environment.IsDevelopment())
        {
            spa.UseAngularCliServer(npmScript: "start");
        }
    });
}
app.MapFallbackToFile("index.html");

app.Run();

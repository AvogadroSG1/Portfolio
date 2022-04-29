using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.FileProviders;
//dotnet publish
// dotnet publish "/Users/Avogadro/Projects/Portfolio/Portfolio/Portfolio.csproj" --configuration "Release" --output "../../PublishOutput/Portfolio"
var builder = WebApplication.CreateBuilder (args);

builder.Services.AddControllers ();
builder.Services.AddSpaStaticFiles (configuration => {
    configuration.RootPath = "ClientApp/dist";
});

var app = builder.Build ();

if (!app.Environment.IsDevelopment ()) {
    app.UseHsts ();
}

app.UseForwardedHeaders (new ForwardedHeadersOptions {
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseHttpsRedirection ();
app.UseStaticFiles ();
app.UseStaticFiles ();
if (!app.Environment.IsDevelopment ()) {
    app.UseSpaStaticFiles ();
}
app.UseRouting ();

app.MapControllerRoute (
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.UseSpa (spa => {

    spa.Options.SourcePath = "ClientApp/";
    spa.Options.DefaultPageStaticFileOptions = new StaticFileOptions () {
        FileProvider = new PhysicalFileProvider (Path.Combine (Directory.GetCurrentDirectory (), "ClientApp")),
        RequestPath = PathString.Empty
    };
    if (app.Environment.IsDevelopment ()) {
        spa.UseAngularCliServer (npmScript: "start");
    }
});

app.Run ();
using AOAHub.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// ApiBaseUrl may be absolute (dev: separate API port) or relative to the site (prod: "/api/" behind the reverse proxy).
var apiBaseUrl = new Uri(new Uri(builder.HostEnvironment.BaseAddress), builder.Configuration["ApiBaseUrl"] ?? "");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = apiBaseUrl });

await builder.Build().RunAsync();

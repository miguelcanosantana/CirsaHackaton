using CirsaHackaton;
using CirsaHackaton.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.FileProviders;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//This Singleton is not static, it's an instance that will be injected across pages
var userService = new UserService();
userService.InitializeDummyDB();
builder.Services.AddSingleton<UserService>(userService);

await builder.Build().RunAsync();

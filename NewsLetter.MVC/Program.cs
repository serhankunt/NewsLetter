using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using NewsLetter.Application;
using NewsLetter.Domain.Entities;
using NewsLetter.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(configure =>
{
    configure.Cookie.Name = "NewsLetters.Auth";
    configure.LoginPath = "/Auth/Login";
    configure.LogoutPath = "/Auth/Login";

    //configure.Cookie.Expiration = TimeSpan.FromDays(1);
});

builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

using(var scoped = app.Services.CreateScope())
{
    var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    if (!userManager.Users.Any())
    {
        AppUser appUser = new()
        {
            Email = "hserhan006@gmail.com",
            UserName = "hskunt",
        };
        userManager.CreateAsync(appUser,"Password12*").Wait();  
    }
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

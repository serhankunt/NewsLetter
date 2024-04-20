using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NewsLetter.Application.Features.Auth.Login;
using System.Security.Claims;

namespace NewsLetter.MVC.Controllers;
public class AuthController(
    IMediator mediator
) : Controller
{
    public IActionResult Login()
    {
		return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Login(LoginCommand request, CancellationToken cancellationToken){
        var response = await mediator.Send(request,cancellationToken);
		TempData["UserNameOrEmail"] = request.UserNameOrEmail;
		TempData["Password"] = request.Password;

		if (!response.IsSuccessful){
            TempData["Error"] = response.ErrorMessages!.First();
			
			return RedirectToAction("Login");
        }

        List<Claim> claims = new()
        {
            new Claim("Name","Serhan Kunt"),
            
            
        };

        var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties();

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),authProperties);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");   
    }
}

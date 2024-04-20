using Microsoft.AspNetCore.Mvc;
using NewsLetter.MVC.Models;
using System.Diagnostics;

namespace NewsLetter.MVC.Controllers;
public class HomeController : Controller
{
    public IActionResult Index()
    {
        
        return View();
    }
    
}

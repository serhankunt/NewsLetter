using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewsLetter.Application.Features.Blogs.Create;
using NewsLetter.Application.Features.Blogs.GetAllBlog;

namespace NewsLetter.MVC.Controllers;
public class NewsLettersController(IMediator mediator) : Controller
{
    public async Task<IActionResult> Index(string search = "")
    {
        var response = await mediator.Send(new GetAllBlogQuery(search));
        return View(response.Data);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogCommand request)
    {
        var response = await mediator.Send(request);
        return RedirectToAction("Index");
    }
}

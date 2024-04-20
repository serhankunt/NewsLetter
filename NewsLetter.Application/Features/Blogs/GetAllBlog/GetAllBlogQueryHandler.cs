using MediatR;
using Microsoft.EntityFrameworkCore;
using NewsLetter.Domain.Entities;
using NewsLetter.Domain.Repositories;
using TS.Result;

namespace NewsLetter.Application.Features.Blogs.GetAllBlog;

internal sealed class GetAllBlogQueryHandler(IBlogRepository blogRepository) : IRequestHandler<GetAllBlogQuery, Result<List<Blog>>>
{
    async Task<Result<List<Blog>>> IRequestHandler<GetAllBlogQuery, Result<List<Blog>>>.Handle(GetAllBlogQuery request, CancellationToken cancellationToken)
    {
        var response = await blogRepository
            .Where(p=>p.Title.ToLower()
            .Contains(request.Search.ToLower()))
            .OrderByDescending(p=>p.PublishDate)
            .ToListAsync(); 
        return response;
    }
}
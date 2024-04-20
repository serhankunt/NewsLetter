using MediatR;
using NewsLetter.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TS.Result;

namespace NewsLetter.Application.Features.Blogs.GetAllBlog;
public sealed record GetAllBlogQuery(
    string Search):IRequest<Result<List<Blog>>>;

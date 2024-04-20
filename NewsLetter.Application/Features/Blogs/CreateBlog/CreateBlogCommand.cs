﻿using MediatR;
using TS.Result;

namespace NewsLetter.Application.Features.Blogs.Create;
public sealed record CreateBlogCommand(
    string Title,
    string Summary,
    string Content,
    string IsPublish,
    DateOnly PublishDate) : IRequest<Result<string>>;

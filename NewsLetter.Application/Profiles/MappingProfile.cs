using AutoMapper;
using NewsLetter.Application.Features.Blogs.Create;
using NewsLetter.Domain.Entities;

namespace NewsLetter.Application.Profiles;
public sealed class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBlogCommand, Blog>().ForMember(p => p.IsPublish, options =>
        {
            options.MapFrom(p => p.IsPublish == "on");
        }).ReverseMap();

    }
}

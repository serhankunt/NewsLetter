using GenericRepository;
using NewsLetter.Domain.Entities;
using NewsLetter.Domain.Repositories;
using NewsLetter.Infrastructure.Context;

namespace NewsLetter.Infrastructure.Repositories;
internal sealed class BlogRepository : Repository<Blog, ApplicationDbContext>, IBlogRepository
{
    public BlogRepository(ApplicationDbContext context) : base(context)
    {
    }
}

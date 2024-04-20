using GenericRepository;
using NewsLetter.Domain.Entities;
using NewsLetter.Domain.Repositories;
using NewsLetter.Infrastructure.Context;

namespace NewsLetter.Infrastructure.Repositories;

internal sealed class SubscribeRepository : Repository<Subscribe, ApplicationDbContext>, ISubscribeRepository
{
    public SubscribeRepository(ApplicationDbContext context) : base(context)
    {
    }
}

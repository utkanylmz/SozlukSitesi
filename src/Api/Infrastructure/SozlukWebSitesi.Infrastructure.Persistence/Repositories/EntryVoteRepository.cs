using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukWebSitesi.Infrastructure.Persistence.Repositories
{
    public class EntryVoteRepository : GenericRepository<EntryVote>, IEntryVoteRepository
    {
        public EntryVoteRepository(SozlukSitesiContext dbContext) : base(dbContext)
        {

        }
    }
}

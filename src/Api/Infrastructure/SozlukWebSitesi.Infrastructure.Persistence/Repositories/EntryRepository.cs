using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukWebSitesi.Infrastructure.Persistence.Repositories
{
    public class EntryRepository : GenericRepository<Entry>, IEntryRepository
    {
        public EntryRepository(SozlukSitesiContext dbContext) : base(dbContext)
        {

        }
    }
}

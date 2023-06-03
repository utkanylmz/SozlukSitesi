using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukWebSitesi.Infrastructure.Persistence.Repositories
{
    public class EntryFavoriteRepository : GenericRepository<EntryFavorite >, IEntryFavoriteRepository
    {
        public EntryFavoriteRepository(SozlukSitesiContext dbContext) : base(dbContext)
        {

        }
    }
}

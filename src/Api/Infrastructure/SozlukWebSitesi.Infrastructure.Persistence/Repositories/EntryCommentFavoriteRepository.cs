using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukWebSitesi.Infrastructure.Persistence.Repositories
{
    public class EntryCommentFavoriteRepository : GenericRepository<EntryCommentFavorite>, IEntryCommentFavoriteRepository
    {
        public EntryCommentFavoriteRepository(SozlukSitesiContext dbContext) : base(dbContext)
        {

        }
    }
}

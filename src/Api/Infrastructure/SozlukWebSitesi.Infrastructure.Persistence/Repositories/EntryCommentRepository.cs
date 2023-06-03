using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukWebSitesi.Infrastructure.Persistence.Repositories
{
    public class EntryCommentRepository : GenericRepository<EntryComment>, IEntryCommentRepository
    {
        public EntryCommentRepository(SozlukSitesiContext dbContext) : base(dbContext)
        {

        }
    }
}

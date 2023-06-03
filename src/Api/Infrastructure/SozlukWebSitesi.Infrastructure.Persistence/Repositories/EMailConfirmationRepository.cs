using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukWebSitesi.Infrastructure.Persistence.Repositories
{
    public class EMailConfirmationRepository : GenericRepository<EMailConfirmation>, IEMailConfirmationRepository
    {
        public EMailConfirmationRepository(SozlukSitesiContext dbContext) : base(dbContext)
        {

        }
    }
}

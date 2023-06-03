using SozlukWebSitesi.Infrastructure.Persistence.Context;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using SozlukWebSitesiApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesi.Infrastructure.Persistence.Repositories
{
    public class UserRepository:GenericRepository<User>,IUserRepository
    {
        public UserRepository(SozlukSitesiContext dbContext):base(dbContext)
        {
            
        }
    }
}

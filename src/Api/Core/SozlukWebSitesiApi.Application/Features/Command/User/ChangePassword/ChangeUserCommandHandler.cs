using AutoMapper;
using MediatR;
using SozlukWebSiteCommon.Events.User;
using SozlukWebSiteCommon.Infrastructure;
using SozlukWebSiteCommon.Infrastructure.Exceptions;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.User.ChangePassword
{
    public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ChangeUserPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            if(!request.UserId.HasValue)
                throw new ArgumentNullException(nameof(request.UserId));

            var dbUser = await _userRepository.GetByIdAsync(request.UserId.Value);

            if (dbUser is null)
                throw new DatabaseValidationException("User not found!");

            var ecpPass = PasswordEncryptor.Encrypt(request.OldPassword);
            if (dbUser.Password != ecpPass)
                throw new DatabaseValidationException("Old password wrong");

            dbUser.Password =PasswordEncryptor.Encrypt(request.NewPassword);
            await _userRepository.UpdateAsync(dbUser);

            return true;
        }
    }
}

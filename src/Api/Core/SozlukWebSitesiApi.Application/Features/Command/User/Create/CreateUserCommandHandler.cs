using AutoMapper;
using MediatR;
using SozlukWebSiteCommon;
using SozlukWebSiteCommon.Events.User;
using SozlukWebSiteCommon.Infrastructure;
using SozlukWebSiteCommon.Infrastructure.Exceptions;
using SozlukWebSiteCommon.ViewModels.RequestModels;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.User.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existsUser = await _userRepository.GetSingleAsync(i => i.EmailAddress == request.EMailAddress);

            if (existsUser is not null)
                throw new DatabaseValidationException("User already exists");

            var dbUser = _mapper.Map<Domain.Models.User>(request);

            var rows=await _userRepository.AddAsync(dbUser);

            //Email Created/Changed

            if (rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };
                QueueFactory.SendMessageToExchange(exchangeName:SozlukConstants.UserExchangeName,
                                                    exchangeType:SozlukConstants.DefaultExchangeType,
                                                    queueName:SozlukConstants.UserEmailChangedQueueName,
                                                    obj:@event);
            }
            return dbUser.Id;
        }
    }
}

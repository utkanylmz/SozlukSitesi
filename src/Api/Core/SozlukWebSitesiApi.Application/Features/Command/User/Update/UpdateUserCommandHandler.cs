using AutoMapper;
using MediatR;
using SozlukWebSiteCommon.Events.User;
using SozlukWebSiteCommon.Infrastructure;
using SozlukWebSiteCommon;
using SozlukWebSiteCommon.Infrastructure.Exceptions;
using SozlukWebSiteCommon.ViewModels.RequestModels;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.User.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetByIdAsync(request.Id);
           
            if (dbUser == null)
                throw new DatabaseValidationException("User not found!");
            var dbEmailAddress = dbUser.EmailAddress;
            var emailChanged = string.CompareOrdinal(dbEmailAddress, request.EMailAddress) != 0;
          
            
            _mapper.Map(request, dbUser);
            //  dbUser = _mapper.Map<Domain.Models.User>(request);
            //İki metotta aynı işlemi yapıyor ama üstteki daha performanslı mapleme işlemi yapmak için arada yeni bir
            //nesne yaratmıyor

            var rows = await _userRepository.UpdateAsync(dbUser);
            //Email Değişikliğini kontrol edilecek eğer email değişikliği yapıldıysa Rabbitmq yardımyla  onay maili gönderilmesi için
            //mesaj yayınlanacak



            if (emailChanged && rows > 0)
            {
                var @event = new UserEmailChangedEvent()
                {
                    OldEmailAddress = null,
                    NewEmailAddress = dbUser.EmailAddress
                };
                QueueFactory.SendMessageToExchange(exchangeName: SozlukConstants.UserExchangeName,
                                                    exchangeType: SozlukConstants.DefaultExchangeType,
                                                    queueName: SozlukConstants.UserEmailChangedQueueName,
                                                    obj: @event);
            }

            dbUser.EmailConfirmed = false;
            await _userRepository.UpdateAsync(dbUser);
            return dbUser.Id;
        }
    }
}

using MediatR;

namespace SozlukWebSitesiApi.Application.Features.Command.User.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public Guid ConfirmationId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.Entry.DeleteFav
{
    public class DeleteEntryFavCommand:IRequest<bool>
    {
        public Guid EntryId { get; set; }
        public Guid UserId { get; set; }
    }
}

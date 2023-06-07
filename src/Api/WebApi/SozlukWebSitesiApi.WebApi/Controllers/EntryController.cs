using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SozlukWebSitesiApi.Application.Features.Queries.GetEntries;
using SozlukWebSitesiApi.Application.Features.Queries.GetMainPageEntries;
using SozlukWebSitesiApi.Domain.Models;

namespace SozlukWebSitesiApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : BaseController
    {
        private readonly IMediator _mediator;

        public EntryController(IMediator mediator)
        {
           _mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> GetEntries([FromQuery] GetEntriesQuery query)
        {
            var entries = await _mediator.Send(query);

            return Ok(entries);
        }

        [HttpGet]
        [Route("MainPageEntries")]
        public async Task<IActionResult> GetMainPageEntries(int page, int pageSize)
        {
            var entries = await _mediator.Send(new GetMainPageEntriesQuery(UserId,page, pageSize));

            return Ok(entries);
        }
    }
}

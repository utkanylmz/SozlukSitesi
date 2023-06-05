﻿using AutoMapper;
using MediatR;
using SozlukWebSiteCommon.ViewModels.RequestModels;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.Entry.Create
{
    public class CreateEntryCommandHandler:IRequestHandler<CreateEntryCommand,Guid>
    {
        private readonly IEntryRepository _entryRepository;
        private readonly IMapper _mapper;

        public CreateEntryCommandHandler(IEntryRepository entryRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommand request, CancellationToken cancellationToken)
        {
            var dbEntry = _mapper.Map<Domain.Models.Entry>(request);
            await _entryRepository.AddAsync(dbEntry);
            return dbEntry.Id;
        }
    }
}

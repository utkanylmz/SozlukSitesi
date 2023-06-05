﻿using AutoMapper;
using MediatR;
using SozlukWebSiteCommon.ViewModels.RequestModels;
using SozlukWebSitesiApi.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozlukWebSitesiApi.Application.Features.Command.EntryComment.Create
{
    public class CreateEntryCommentCommandHandler:IRequestHandler<CreateEntryCommentCommand,Guid>
    {
        private readonly IEntryCommentRepository _entryCommentRepository;
        private readonly IMapper _mapper;

        public CreateEntryCommentCommandHandler(IEntryCommentRepository entryCommentRepository, IMapper mapper)
        {
            _entryCommentRepository = entryCommentRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEntryCommentCommand request, CancellationToken cancellationToken)
        {
            var dbEntryComment = _mapper.Map<Domain.Models.EntryComment>(request);
            await _entryCommentRepository.AddAsync(dbEntryComment);

            return dbEntryComment.Id;
        }
    }
}

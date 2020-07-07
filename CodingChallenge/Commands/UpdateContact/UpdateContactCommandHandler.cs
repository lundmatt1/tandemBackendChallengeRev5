using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodingChallenge.Entities;
using CodingChallenge.Services;
using MediatR;

namespace CodingChallenge.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : AsyncRequestHandler<UpdateContactCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICosmosDbService _cosmosDbService;

        public UpdateContactCommandHandler(IMapper mapper, ICosmosDbService cosmosDbService)
        {
            _mapper = mapper;
            _cosmosDbService = cosmosDbService;
        }

        protected override async Task Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ContactEntity>(request);
            await _cosmosDbService.UpdateContactAsync(request.Id, entity);
        }
    }
}

using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodingChallenge.Entities;
using CodingChallenge.Services;
using MediatR;

namespace CodingChallenge.Commands.CreateContact
{
    public class CreateContactCommandHandler : AsyncRequestHandler<CreateContactCommand>
    {
        private readonly IMapper _mapper;
        private readonly ICosmosDbService _cosmosDbService;

        public CreateContactCommandHandler(IMapper mapper, ICosmosDbService cosmosDbService)
        {
            _mapper = mapper;
            _cosmosDbService = cosmosDbService;
        }

        protected override async Task Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ContactEntity>(request);
            await _cosmosDbService.AddContactAsync(entity);
        }
    }
}

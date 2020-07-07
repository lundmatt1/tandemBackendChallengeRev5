using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CodingChallenge.Models;
using CodingChallenge.Services;
using MediatR;

namespace CodingChallenge.Commands.GetContact
{
    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, ContactDto>
    {
        private readonly IMapper _mapper;
        private readonly ICosmosDbService _cosmosDbService;

        public GetContactQueryHandler(IMapper mapper, ICosmosDbService cosmosDbService)
        {
            _mapper = mapper;
            _cosmosDbService = cosmosDbService;
        }

        public async Task<ContactDto> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            var contactEntity = await _cosmosDbService.GetContactAsync(request.Id);
            return _mapper.Map<ContactDto>(contactEntity);
        }
    }
}

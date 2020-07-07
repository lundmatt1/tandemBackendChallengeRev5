using System;
using CodingChallenge.Models;
using MediatR;

namespace CodingChallenge.Commands.GetContact
{
    public class GetContactQuery : IRequest<ContactDto>
    {
        public Guid Id { get; set; }
    }
}

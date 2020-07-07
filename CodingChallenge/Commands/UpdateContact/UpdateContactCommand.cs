using System;
using MediatR;

namespace CodingChallenge.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

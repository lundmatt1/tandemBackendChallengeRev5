using System;
using MediatR;

namespace CodingChallenge.Commands.CreateContact
{
    public class CreateContactCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

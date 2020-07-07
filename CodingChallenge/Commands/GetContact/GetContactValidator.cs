using System;
using FluentValidation;

namespace CodingChallenge.Commands.GetContact
{
    public class GetContactValidator: AbstractValidator<GetContactQuery>
    {
        public GetContactValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
}

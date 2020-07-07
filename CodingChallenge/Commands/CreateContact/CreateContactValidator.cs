using System;
using FluentValidation;

namespace CodingChallenge.Commands.CreateContact
{
    public class CreateContactValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactValidator()
        {
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.LastName).NotEmpty();
            RuleFor(command => command.Email).NotEmpty();
            RuleFor(command => command.Phone).NotEmpty();
        }
    }
}

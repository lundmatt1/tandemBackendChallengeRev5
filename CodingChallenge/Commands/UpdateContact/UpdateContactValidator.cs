using System;
using FluentValidation;

namespace CodingChallenge.Commands.UpdateContact
{
    public class UpdateContactValidator: AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactValidator()
        {
            RuleFor(command => command.Id).NotEmpty();
            RuleFor(command => command.FirstName).NotEmpty();
            RuleFor(command => command.LastName).NotEmpty();
            RuleFor(command => command.Email).NotEmpty();
            RuleFor(command => command.Phone).NotEmpty();
        }
    }
}

using CleanArchitecture.Application.Features.Streamers.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Actors.Commands.CreateActor
{
    internal class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
    {

        public CreateActorCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");

            RuleFor(p => p.apellido)
                 .NotEmpty().WithMessage("La {Apellido} no puede estar en blanco").NotNull()
                .MaximumLength(50).WithMessage("{Apellido} no puede exceder los 50 caracteres");
            ;

        }
    }
}

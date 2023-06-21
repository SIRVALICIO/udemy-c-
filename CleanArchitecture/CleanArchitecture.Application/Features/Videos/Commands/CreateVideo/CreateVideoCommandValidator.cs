using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Features.Streamers.Commands;
using FluentValidation;


namespace CleanArchitecture.Application.Features.Videos.Commands.CreateVideo
{
    internal class CreateVideoCommandValidator : AbstractValidator<CreateVideoCommand>
    {
        public CreateVideoCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{Nombre} no puede estar en blanco")
                .NotNull()
                .MaximumLength(50).WithMessage("{Nombre} no puede exceder los 50 caracteres");

            RuleFor(p => p.StreamerId)
                 .NotEmpty().WithMessage("La {StreamerId} no puede estar en blanco");

        }
    }
}

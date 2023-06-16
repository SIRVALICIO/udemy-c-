using FluentValidation;


namespace CleanArchitecture.Application.Features.Streamers.Commands.CreateStreamer
{
    public class CreateStreamerCommandValidator : AbstractValidator<CreateStreamerCommand>
    {
        public CreateStreamerCommandValidator()
        {

            RuleFor(p => p.Nombre).NotEmpty().WithMessage("{Nombre} NO puede estar en blanco").NotNull().MaximumLength(50).WithMessage("{Nombre} NO puede exceder los 50 caracteres");

            RuleFor(p => p.Url).NotEmpty().WithMessage("{Url} No puede estar en blanco");


        }
    }
}

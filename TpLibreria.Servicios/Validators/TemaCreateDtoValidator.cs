using TpLibreria.Servicios.DTOs.Tema;
using FluentValidation;

namespace TpLibreria.Servicios.Validators
{
    public class TemaCreateDtoValidator : AbstractValidator<TemaCreateDto>
    {
        public TemaCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(150).WithMessage("La descripción no puede superar los 150 caracteres.");
        }
    }
}

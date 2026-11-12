using TpLibreria.Servicios.DTOs.Tema;
using FluentValidation;

namespace TpLibreria.Servicios.Validators
{
    public class TemaUpdateDtoValidator : AbstractValidator<TemaUpdateDto>
    {
        public TemaUpdateDtoValidator()
        {
            RuleFor(x => x.TemaId)
                .GreaterThan(0).WithMessage("El identificador no es válido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(150).WithMessage("La descripción no puede superar los 150 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("Falta la versión del registro.");
        }
    }
}

using TpLibreria.Servicios.DTOs.Editorial;
using FluentValidation;

namespace TpLibreria.Servicios.Validators
{
    public class EditorialUpdateDtoValidator : AbstractValidator<EditorialUpdateDto>
    {
        public EditorialUpdateDtoValidator()
        {
            RuleFor(x => x.EditorialId)
                .GreaterThan(0).WithMessage("El identificador no es válido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.PaisOrigen)
                .NotEmpty().WithMessage("El país de origen es obligatorio.")
                .MaximumLength(50).WithMessage("El país de origen no puede superar los 50 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("Falta la versión del registro.");
        }
    }
}

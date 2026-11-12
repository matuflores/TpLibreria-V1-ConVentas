using TpLibreria.Servicios.DTOs.Editorial;
using FluentValidation;

namespace TpLibreria.Servicios.Validators
{
    public class EditorialCreateDtoValidator : AbstractValidator<EditorialCreateDto>
    {
        public EditorialCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no puede superar los 100 caracteres.");

            RuleFor(x => x.PaisOrigen)
                .NotEmpty().WithMessage("El país de origen es obligatorio.")
                .MaximumLength(50).WithMessage("El país de origen no puede superar los 50 caracteres.");
        }
    }
}

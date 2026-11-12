using TpLibreria.Servicios.DTOs.Autor;
using FluentValidation;

namespace TpLibreria.Servicios.Validators
{
    public class AutorCreateDtoValidator : AbstractValidator<AutorCreateDto>
    {
        public AutorCreateDtoValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.FechaNacimiento)
                .Must(f => f.Date <= DateTime.Today).WithMessage("La fecha de nacimiento no puede ser futura.")
                .Must(f => f.Date >= new DateTime(1753, 1, 1)).WithMessage("La fecha de nacimiento no es válida.");

            RuleFor(x => x.Nacionalidad)
                .NotEmpty().WithMessage("La nacionalidad es obligatoria.")
                .MaximumLength(50).WithMessage("La nacionalidad no puede superar los 50 caracteres.");
        }
    }
}

using TpLibreria.Servicios.DTOs.Cliente;
using FluentValidation;

namespace TpLibreria.Servicios.Validators
{
    public class ClienteUpdateDtoValidator : AbstractValidator<ClienteUpdateDto>
    {
        public ClienteUpdateDtoValidator()
        {
            RuleFor(x => x.ClienteId)
                .GreaterThan(0).WithMessage("El identificador no es válido.");

            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.")
                .MaximumLength(50).WithMessage("El nombre no puede superar los 50 caracteres.");

            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es obligatorio.")
                .MaximumLength(50).WithMessage("El apellido no puede superar los 50 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("El email es obligatorio.")
                .MaximumLength(100).WithMessage("El email no puede superar los 100 caracteres.")
                .EmailAddress().WithMessage("El email no tiene un formato válido.");

            RuleFor(x => x.Telefono)
                .MaximumLength(20).WithMessage("El teléfono no puede superar los 20 caracteres.");

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("Falta la versión del registro.");
        }
    }
}

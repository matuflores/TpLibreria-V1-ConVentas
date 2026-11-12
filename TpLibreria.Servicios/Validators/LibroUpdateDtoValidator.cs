using TpLibreria.Entidades;
using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.DTOs.Libro;
using FluentValidation;

namespace TpLibreria.Servicios.Validators
{
    public class LibroUpdateDtoValidator : AbstractValidator<LibroUpdateDto>
    {
        public LibroUpdateDtoValidator()
        {
            RuleFor(x => x.LibroId)
                .GreaterThan(0).WithMessage("El identificador no es válido.");

            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("El título es obligatorio.")
                .MaximumLength(100).WithMessage("El título no puede superar los 100 caracteres.");

            RuleFor(x => x.Descripcion)
                .MaximumLength(250).WithMessage("La descripción no puede superar los 250 caracteres.");

            RuleFor(x => x.AnioPublicacion)
                .InclusiveBetween(1000, DateTime.Today.Year)
                .WithMessage("El año de publicación debe estar entre 1000 y el año actual.");

            RuleFor(x => x.Precio)
                .GreaterThan(0).WithMessage("El precio debe ser mayor que cero.");

            RuleFor(x => x.EditorialId)
                .GreaterThan(0).WithMessage("La editorial es obligatoria.");

            RuleFor(x => x.AutoresIds)
                .NotEmpty().WithMessage("El libro debe tener al menos un autor.");

            RuleFor(x => x.TemasIds)
                .NotEmpty().WithMessage("El libro debe tener al menos un tema.");

            // Reglas del libro físico
            When(x => x.Tipo == TipoLibro.Fisico, () =>
            {
                RuleFor(x => x.Isbn)
                    .NotEmpty().WithMessage("El ISBN es obligatorio.")
                    .Must(i => !string.IsNullOrWhiteSpace(i) && LibroFisico.EsIsbnValido(LibroFisico.NormalizarIsbn(i)))
                    .WithMessage("El ISBN debe tener 10 o 13 caracteres (solo números; el último del ISBN-10 puede ser X).");

                RuleFor(x => x.Stock)
                    .GreaterThanOrEqualTo(0).WithMessage("El stock no puede ser negativo.");
            });

            // Reglas del libro digital
            When(x => x.Tipo == TipoLibro.Digital, () =>
            {
                RuleFor(x => x.Identificador)
                    .NotEmpty().WithMessage("El identificador es obligatorio.")
                    .MaximumLength(50).WithMessage("El identificador no puede superar los 50 caracteres.");

                RuleFor(x => x.Formato)
                    .NotEmpty().WithMessage("El formato es obligatorio.")
                    .MaximumLength(20).WithMessage("El formato no puede superar los 20 caracteres.");

                RuleFor(x => x.TamanoArchivo)
                    .GreaterThan(0).WithMessage("El tamaño del archivo debe ser mayor que cero.");

                RuleFor(x => x.UrlDescarga)
                    .NotEmpty().WithMessage("La URL de descarga es obligatoria.")
                    .MaximumLength(250).WithMessage("La URL de descarga no puede superar los 250 caracteres.")
                    .Must(u => Uri.TryCreate(u, UriKind.Absolute, out var uri) &&
                        (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                    .WithMessage("La URL de descarga no es válida.");
            });

            RuleFor(x => x.RowVersion)
                .NotEmpty().WithMessage("Falta la versión del registro.");
        }
    }
}

using TpLibreria.Datos;
using TpLibreria.Datos.Interfaces;
using TpLibreria.Datos.Repositorios;
using TpLibreria.Servicios.DTOs.Autor;
using TpLibreria.Servicios.DTOs.Cliente;
using TpLibreria.Servicios.DTOs.Editorial;
using TpLibreria.Servicios.DTOs.Libro;
using TpLibreria.Servicios.DTOs.Tema;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Servicios.Servicios;
using TpLibreria.Servicios.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace TpLibreria.Ioc
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<LibreriaDbContext>();

            services.AddScoped<IEditorialRepositorio, EditorialRepositorio>();
            services.AddScoped<IEditorialServicio, EditorialServicio>();
            services.AddScoped<IValidator<EditorialCreateDto>, EditorialCreateDtoValidator>();
            services.AddScoped<IValidator<EditorialUpdateDto>, EditorialUpdateDtoValidator>();

            services.AddScoped<IAutorRepositorio, AutorRepositorio>();
            services.AddScoped<IAutorServicio, AutorServicio>();
            services.AddScoped<IValidator<AutorCreateDto>, AutorCreateDtoValidator>();
            services.AddScoped<IValidator<AutorUpdateDto>, AutorUpdateDtoValidator>();

            services.AddScoped<ITemaRepositorio, TemaRepositorio>();
            services.AddScoped<ITemaServicio, TemaServicio>();
            services.AddScoped<IValidator<TemaCreateDto>, TemaCreateDtoValidator>();
            services.AddScoped<IValidator<TemaUpdateDto>, TemaUpdateDtoValidator>();

            services.AddScoped<ILibroRepositorio, LibroRepositorio>();
            services.AddScoped<ILibroServicio, LibroServicio>();
            services.AddScoped<IValidator<LibroCreateDto>, LibroCreateDtoValidator>();
            services.AddScoped<IValidator<LibroUpdateDto>, LibroUpdateDtoValidator>();

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IClienteServicio, ClienteServicio>();
            services.AddScoped<IValidator<ClienteCreateDto>, ClienteCreateDtoValidator>();
            services.AddScoped<IValidator<ClienteUpdateDto>, ClienteUpdateDtoValidator>();

            services.AddScoped<IVentaRepositorio, VentaRepositorio>();
            services.AddScoped<IVentaServicio, VentaServicio>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionDemo.Application;
using OnionDemo.Application.Command;
using OnionDemo.Application.IRepository;
using OnionDemo.Application.Query;
using OnionDemo.Application.Repository;
using OnionDemo.Domain.DomainServices;
using OnionDemo.Infrastructure.Queries;

namespace OnionDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBookingQuery, BookingQuery>();
        //services.AddScoped<IBookingDomainService, BookingDomainService>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IAccommodationRepository, AccommodationRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork<BookMyHomeContext>>();
        services.AddScoped<IHostRepository, HostRepository>();
        services.AddScoped<IHostQuery, HostQuery>();
        services.AddScoped<IAddressValidationCommand, AddressValidationCommand>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IDawaQuery, DawaQuery>();
        services.AddHostedService<PendingAddressChecker>();


        // Register DbContext
        services.AddDbContext<BookMyHomeContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString
                    ("BookMyHomeDbConnection"),
                x => 
                    x.MigrationsAssembly("OnionDemo.DatabaseMigration")));

        //services.AddScoped<IUnitOfWork, UnitOfWork>(u =>
        //{
        //    var db = u.GetService<BookMyHomeContext>();
        //    return new UnitOfWork<>
        //});

        return services;
    }

}
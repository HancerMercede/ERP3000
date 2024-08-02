using ERP3000.Repository;
using ERP3000.Repository.Conctracts;
using ERP3000.Service;
using ERP3000.Service.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ERP3000.Helpers;

public static class ServicesExtensionsMethods
{

    public static void ConfiguredCors(this IServiceCollection services) =>
        services.AddCors(opt =>
        {
            opt.AddPolicy("AllowAll", builder => {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
        });

    public static void ConfiguredSqlServerContext(this IServiceCollection services, string connection)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connection);
        });
    }

    public static void ConfigureRepositoryManager(this IServiceCollection services) =>
     services.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();
}

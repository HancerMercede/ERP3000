using ERP3000.Repository;
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
}

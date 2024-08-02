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
}

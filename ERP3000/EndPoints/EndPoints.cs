using Microsoft.AspNetCore.Builder;

namespace ERP3000.EndPoints
{
    public static class EndPoints
    {
        public static void MainEnPoint(WebApplication app)
        {
            app.MapGet("/Test", () =>
            {
                return "Healthy";
            });
        }
    }
}

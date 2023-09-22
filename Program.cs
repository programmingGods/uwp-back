using System.Text.Json;

namespace uwp_back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins, policy =>
                {
                    policy.WithOrigins().AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            var app = builder.Build();

            app.UseCors(MyAllowSpecificOrigins);

            app.MapGet("/api/Department", () =>
            {
                return Results.Json("wafwa");
            });

            app.MapPost("/api/Run", async context =>
            {
                context.Response.StatusCode = 206;

                await context.Response.WriteAsJsonAsync("awdawd");
            });

            app.Run();
        }
    }
}
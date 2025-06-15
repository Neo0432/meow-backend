using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawsBackendDotnet.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication UseAppMiddleware(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapSwagger();

                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("v1/swagger.json", "Meow API");
                });
            }

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            return app;
        }
    }
}

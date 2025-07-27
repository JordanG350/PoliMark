using polimark.api.models;
using Microsoft.AspNetCore.Diagnostics;

namespace polimark.api.Dependecy
{
    public static class AppBuilderExtentions
    {
        public static IApplicationBuilder AddSwaggerColletion(this IApplicationBuilder app) 
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "maassapp.api v1"));
            return app;
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(e =>
            {
                e.Run(async context =>
                { 
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";
                    var contexFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contexFeature != null)
                    {
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}

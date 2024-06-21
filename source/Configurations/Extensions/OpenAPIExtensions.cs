using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Configurations.Extensions
{
    public static class OpenAPIExtensions
    {
        public const string title = "FastEndpoints";
        public const string version = "v1";

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName);

                options.SwaggerDoc(version, new OpenApiInfo
                {
                    Version = version,
                    Title = title,
                    Description = "Sample Fast Endpoints API",
                    TermsOfService = new Uri("https://fast-endpoints.com/api/documentation"),
                    Contact = new OpenApiContact
                    {
                        Name = "Contacts",
                        Url = new Uri("https://fast-endpoints.com/contacts")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "License",
                        Url = new Uri("https://fast-endpoints.com/license")
                    }
                });
            });

            return services;
        }
    }
}

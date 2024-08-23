using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace EmprestimoLivros.Infra.Ioc {

    public static class DependencyInjectionSwagger {

        public static IServiceCollection AddInfraestructureSwagger (this IServiceCollection services) {
            services.AddSwaggerGen(c => {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JSON Web Tokens are an open, industry standard RFC 7519 method for representing claims securely between two parties."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme() {
                            Reference = new OpenApiReference() {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            return services;
        }

    }
}
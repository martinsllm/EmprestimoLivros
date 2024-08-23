using System.Text;
using EmprestimoLivros.Application.Mappings;
using EmprestimoLivros.Domain.Entities;
using EmprestimoLivros.Domain.Interfaces;
using EmprestimoLivros.Infra.Data;
using EmprestimoLivros.Infra.Data.Context;
using EmprestimoLivros.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace EmprestimoLivros.Infra.Ioc {

    public static class DependencyInjection {

        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration) {

            var connectionString = configuration["ConnectionString"];
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

            services.AddEntityFrameworkMySql()
                .AddDbContext<EmprestimoDbContext>(
                    options => options.UseMySql(connectionString, serverVersion)
                );

            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options => {
                options.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Settings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IEntityRepository<Cliente>, ClienteRepository>();
            services.AddScoped<IEntityRepository<Livro>, LivroRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddAutoMapper(typeof(MappingDTO));

            return services;
        }
    }

}
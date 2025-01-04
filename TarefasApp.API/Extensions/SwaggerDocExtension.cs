using Amazon.Runtime.Internal.Transform;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TarefasApp.API.Extensions
{
  
    public static class SwaggerDocExtension
    {

        public static IServiceCollection AddSwaggerDoc(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "Desafio API - Desafio Técnico",
                        Description = "API para controle de tarefas de usuários com suporte a Refresh Token.",
                        Version = "1.0",
                        Contact = new OpenApiContact
                        {
                            Name = "Rubens Manhães Bernardes",
                            Email = "rubensmanhaesb@hotmail.com",
                            Url = new Uri("https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/overview")
                        }
                    });

                    //configuração para incluir os comentários na documentação
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);

                    //configuração para incluir o JWT Bearer Swagger
                    options.AddSecurityDefinition("Bearer",
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                        Description = "Por favor, insira o token JWT Bearer",
                        Name = "Authorization",
                        Type = Microsoft.OpenApi.Models
                            .SecuritySchemeType.ApiKey,
                    });

                    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        {
                            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                            {
                                Reference = new Microsoft.OpenApi
                                .Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models
                                .ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TarefasApp");
                
                // Adicionar script customizado para gerenciar o token
                options.InjectJavascript("/swagger-custom.js");
            });

            return app;
        }
    }
}

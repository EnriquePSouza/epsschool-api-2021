using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using EpsSchool.Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EpsSchool.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Injeção de Dependencia do Contexto de Banco de Dados.
            services.AddDbContext<SchoolContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            // Tratando erro de loop infinito no envio do Json.
            services.AddControllers()
                    .AddNewtonsoftJson(
                        opt => opt.SerializerSettings.ReferenceLoopHandling =
                            Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            // Mapeamento Automatico Para os Dtos - Os Helpers são o meio de campo.
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Injeção de Dependencia do Controle com Inversão de Controle.
            services.AddScoped<IRepository, Repository>();

            // Swagger - Utilizado para execução e testes da API.
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("epsschoolapi",
                new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "EPS School API",
                    Version = "1.0"

                });

                var xmlCommentFiles = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFiles);

                options.IncludeXmlComments(xmlCommentFullPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger()
                .UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/swagger/epsschoolapi/swagger.json", "epsschoolapi");
                    options.RoutePrefix = "";
                });

            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

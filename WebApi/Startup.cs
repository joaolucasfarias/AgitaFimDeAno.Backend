using Application.Filmes.Comandos.EditarFilme;
using Application.Filmes.Comandos.NovoFilme;
using Application.Filmes.Consultas.ListasFilmes;
using Application.Filmes.Consultas.VisualizarFilme;
using Application.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence.Filmes;

namespace WebApi
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
            services.AddTransient<INovoFilmeComando, NovoFilmeComando>();
            services.AddTransient<IEditarFilmeComando, EditarFilmeComando>();

            services.AddSingleton<IListarFilmesConsulta, ListarFilmesConsulta>();
            services.AddSingleton<IVisualizarFilmeConsulta, VisualizarFilmeConsulta>();

            services.AddSingleton<IFilmesRepositorio, FilmesRepositorio>();

            services.AddControllers();

            services.AddSwaggerGen();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

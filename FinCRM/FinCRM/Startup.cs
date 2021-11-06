using FinCRM.ApplicationServices.API.Domain;
using FinCRM.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace FinCRM
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
            //Tu bêdziemy uczyæ jak pobieraæ requesty z Mediatr
            //Podajemy jak¹kolwiek klasê w naszym obiekcie, a MEdiatR domyœli siê, ¿e chodzi nam o ten projekt.
            services.AddMediatR(typeof(ResponseBase<>));



            //Dziêki temu w ka¿dej klasie bêdziemy mogli wywo³aæ repozytorium z konkretn¹ encj¹, bêdziemy go u¿ywaæ globalnie
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Informujemy controller, sk¹d ma wiedzieæ gdzie jest nasza baza
            services.AddDbContext<CRMStorageContext>(
                opt => opt.UseSqlServer(this.Configuration.GetConnectionString("FinCRMDatabaseConnection")));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FinCRM", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinCRM v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

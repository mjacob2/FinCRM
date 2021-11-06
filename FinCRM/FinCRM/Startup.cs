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
            //Tu b�dziemy uczy� jak pobiera� requesty z Mediatr
            //Podajemy jak�kolwiek klas� w naszym obiekcie, a MEdiatR domy�li si�, �e chodzi nam o ten projekt.
            services.AddMediatR(typeof(ResponseBase<>));



            //Dzi�ki temu w ka�dej klasie b�dziemy mogli wywo�a� repozytorium z konkretn� encj�, b�dziemy go u�ywa� globalnie
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Informujemy controller, sk�d ma wiedzie� gdzie jest nasza baza
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
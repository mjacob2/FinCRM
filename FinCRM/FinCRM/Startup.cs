using FinCRM.ApplicationServices.API.Domain;
using FinCRM.ApplicationServices.API.Validators;
using FinCRM.ApplicationServices.Mappings;
using FinCRM.Authentication;
using FinCRM.DataAccess;
using FinCRM.DataAccess.CQRS;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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

            //Rejestrujemy modu� do Authentykacji u�ytkownik�
            services.AddAuthentication("BasicAuthentication")
                // poni�ej definicja tego, jak to b�dzie obs�ugowane
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            
            // Rejestruj wszystkie validatory, kt�re znajduj� si� w tym Assembly, co ten podany ni�ej
            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddClientRequestValidator>());
            //Pozwalamy aby FluentValidator m�g� sprawdza� dane a� na poziomie Kontrollera
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });




            //wpisujemy, �eby m�c go wstrzykn�� do naszych Konstruktor�w
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            //Pokazujemy, �eby korzysta� z AutoMappera. Dzieki tej linii wszystkie profile z AutoMappera b�d� si� dodawa� automatycznie
            services.AddAutoMapper(typeof(ClientsProfile).Assembly);

            //Tu b�dziemy uczy� jak pobiera� requesty z Mediatr
            //Podajemy jak�kolwiek klas� w naszym obiekcie, a MEdiatR domy�li si�, �e chodzi nam o ten projekt.
            services.AddMediatR(typeof(ResponseBase<>));

            //Dzi�ki temu w ka�dej klasie b�dziemy mogli wywo�a� repozytorium z konkretn� encj�, b�dziemy go u�ywa� globalnie
          
            // Odk�d u�ywamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie m�wi�.

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
            // Tu s� opcje u�ywane tylko podczas dewelopmentu. Nie wychodz� przy produkcji.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FinCRM v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

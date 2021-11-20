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

            //Rejestrujemy modu³ do Authentykacji u¿ytkownikó
            services.AddAuthentication("BasicAuthentication")
                // poni¿ej definicja tego, jak to bêdzie obs³ugowane
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
            
            // Rejestruj wszystkie validatory, które znajduj¹ siê w tym Assembly, co ten podany ni¿ej
            services.AddMvcCore()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddClientRequestValidator>());
            //Pozwalamy aby FluentValidator móg³ sprawdzaæ dane a¿ na poziomie Kontrollera
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });




            //wpisujemy, ¿eby móc go wstrzykn¹æ do naszych Konstruktorów
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            //Pokazujemy, ¿eby korzystaæ z AutoMappera. Dzieki tej linii wszystkie profile z AutoMappera bêd¹ siê dodawaæ automatycznie
            services.AddAutoMapper(typeof(ClientsProfile).Assembly);

            //Tu bêdziemy uczyæ jak pobieraæ requesty z Mediatr
            //Podajemy jak¹kolwiek klasê w naszym obiekcie, a MEdiatR domyœli siê, ¿e chodzi nam o ten projekt.
            services.AddMediatR(typeof(ResponseBase<>));

            //Dziêki temu w ka¿dej klasie bêdziemy mogli wywo³aæ repozytorium z konkretn¹ encj¹, bêdziemy go u¿ywaæ globalnie
          
            // Odk¹d u¿ywamy CQRS i Queries nie potrzebujemy Repository !!! Ale Kamizelich jeszcze o tym nie mówi³.

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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
            // Tu s¹ opcje u¿ywane tylko podczas dewelopmentu. Nie wychodz¹ przy produkcji.
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

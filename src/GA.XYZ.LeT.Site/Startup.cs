using System.Reflection;
using AutoMapper;
using GA.XYZ.LeT.Application.AutoMapper;
using GA.XYZ.LeT.Infra.CrossCutting.Bus;
using GA.XYZ.LeT.Infra.CrossCutting.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GA.XYZ.LeT.Site {

    public class Startup{

        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services){
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperConfiguration)));

            RegisterServices(services); //Chamada da função para aplicar as dependecias

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IHttpContextAccessor acessor){
            if (env.IsDevelopment()){
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else{
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>{
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            InMemoryBus.ContainerAcessor = () => acessor.HttpContext.RequestServices;

        }

        //Injeção de dependencia
        private static void RegisterServices(IServiceCollection services) {
            InjectorBootstrapper.RegisterServices(services);
        }
    }
}

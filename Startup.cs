using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using web_net_core.Aplicacion;

namespace web_net_core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // Este m�todo se utiliza para configurar los servicios que se utilizan en la aplicaci�n.
        public void ConfigureServices(IServiceCollection services)
        {
            // Agrega el soporte para el patr�n MVC (Model-View-Controller) en la aplicaci�n.
            services.AddControllersWithViews();

            // Agrega un servicio IDbConnection al contenedor de servicios y lo registra con un �mbito de servicio.
            // Tambi�n define una f�brica que devuelve una nueva instancia de SqlConnection con la cadena de conexi�n especificada en la secci�n de configuraci�n "MiConexion".
            // Esto significa que cada vez que se solicita un IDbConnection dentro de un �mbito de servicio, se devuelve una instancia �nica de SqlConnection.
            services.AddScoped<IDbConnection>(c => new SqlConnection(Configuration.GetConnectionString("MiConexion")));

            // Agrega un servicio UsuariosApp al contenedor de servicios y lo registra con un �mbito de servicio transitorio.
            // Esto significa que cada vez que se solicita un UsuariosApp dentro de un �mbito de servicio, se devuelve una nueva instancia de UsuariosApp.
            services.AddTransient<UsuariosApp>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

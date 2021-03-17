using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Database;
using Ecommerce.Libraries.Login;
using Ecommerce.Libraries.Session;
using Ecommerce.Repositories;
using Ecommerce.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            /*
             * SESSION - INJEÇÃO DE DEPENDENCIA
             */
            services.AddHttpContextAccessor();

            /*
             *                      PADRÃO REPOSITORY 
             *  USANDO SCOPED AO INVES DE TRANSIENT, P/ TER UM INSTANCIA DA CLASSE REPOSITORY POR REQUISIÇÃO
             */
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<INewsletterRepository, NewsletterRepository>();

            services.Configure<CookiePolicyOptions>(options => 
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            /*
             * Configurando Session 
             */
            services.AddMemoryCache();
            services.AddSession(options => { 

            });
            services.AddScoped<Session>();
            services.AddScoped<LoginClient>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaVirtual;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<LojaVirtualContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

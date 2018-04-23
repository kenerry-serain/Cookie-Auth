using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace AspNetCore.CookieAuth
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
            services.AddMvc();
            services

                /* Creating policies based on profile claims */
                .AddAuthorization(options =>
                {
                    /*  (PolicyName, ()=> (Claim type, Claim value)) */
                    options.AddPolicy("Client-Policy", builder => builder.RequireClaim("Profile-Type", "Client"));
                    options.AddPolicy("Manager-Policy", builder => builder.RequireClaim("Profile-Type", "Manager"));
                })

                /* Adding cookie authentication */
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "Netflix-Cookie";

                    /* When the cookie not exists */
                    options.Events.OnRedirectToLogin = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };

                    /* When the cookie is invalid or expired */
                    options.Events.OnRedirectToAccessDenied = context =>
                    {
                        context.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /* Activating authentication middleware */
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}

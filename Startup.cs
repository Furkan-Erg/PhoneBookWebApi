using Microsoft.AspNetCore.Builder;
using Microsoft.Net.Http.Headers;

namespace ContactAppBackend
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
            services.AddDbContext<AppContext>();

            // configure cors
            ConfigureCors(services);
            services.AddMvc();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors("DevelopmentPolicy");
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        private static void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("DevelopmentPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));
        }
    }
}

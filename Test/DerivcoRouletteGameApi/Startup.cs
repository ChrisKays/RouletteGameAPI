using AutoMapper;
using RouletteGameApi.Models;
using RouletteGameApi.Repositories;
using RouletteGameApi.Repositories.Interface;
using RouletteGameApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;




namespace TestWebApi
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
            services.AddControllers();

            services.AddDbContext<RouletteGameContext>(option =>
            option.UseSqlite(Configuration.GetConnectionString("DefaultConnection"))
            );

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IBet, BetService>();
            services.AddScoped<ISpin, SpinService>();
            services.AddScoped<IPayout, PayoutService>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Roulette API",
                    Version = "v2",
                    Description = "C# REST API based around the game of roulette",
                });
            });
            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>{endpoints.MapControllers();});
            app.UseSwagger();
            app.UseSwaggerUI(options =>options.SwaggerEndpoint("/swagger/v2/swagger.json", "Roulette API"));
        }
    }
}

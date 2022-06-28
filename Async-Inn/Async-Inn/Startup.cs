using Async_Inn.Data;
using Async_Inn.Models;
using Async_Inn.Models.Interface;
using Async_Inn.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // There are other options like this
            })
            .AddEntityFrameworkStores<AsyncInnDbContext>();

            services.AddDbContext<AsyncInnDbContext>(options => {
                // Our DATABASE_URL from js days
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
            services.AddTransient<IHotel, HotelService>();
            services.AddTransient<IRoom, RoomService>();
            services.AddTransient<IAmenity, AmenityService>();
            services.AddTransient<IHotelRoom, HotelRoomService>();
            services.AddTransient<IUserService, IdentityUserService>();
            services.AddScoped<JwtTokenService>();

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Async Inn",
                    Version = "v1",
                });
            });

            // Add the wiring for adding "Authentication" for our API
            // "We want the system to always use these "Schemes" to authenticate us
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
              {
                  // Tell the authenticaion scheme "how/where" to validate the token + secret
                  options.TokenValidationParameters = JwtTokenService.GetValidationParameters(Configuration);
              });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("createRoom", policy => policy.RequireClaim("permissions", "createRoom"));
                options.AddPolicy("updateRoom", policy => policy.RequireClaim("permissions", "updateRoom"));
                options.AddPolicy("deleteRoom", policy => policy.RequireClaim("permissions", "deleteRoom"));

                options.AddPolicy("createHotel", policy => policy.RequireClaim("permissions", "createHotel"));
                options.AddPolicy("updateHotel", policy => policy.RequireClaim("permissions", "updateHotel"));
                options.AddPolicy("deleteHotel", policy => policy.RequireClaim("permissions", "deleteHotel"));

                options.AddPolicy("createAmenity", policy => policy.RequireClaim("permissions", "createAmenity"));
                options.AddPolicy("updateAmenity", policy => policy.RequireClaim("permissions", "updateAmenity"));
                options.AddPolicy("deleteAmenity", policy => policy.RequireClaim("permissions", "deleteAmenity"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Async Inn");
                options.RoutePrefix = "";
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}

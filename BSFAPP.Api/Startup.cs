using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BSFAPP.Api.Core;
using BSFAPP.Api.Core.Interfaces.Repositories;
using BSFAPP.Api.Core.Interfaces.Services;
using BSFAPP.Api.Core.Services;
using BSFAPP.Api.Infrastructure.Data;
using BSFAPP.Api.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace BSFAPP.Api
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase")));

            services.AddControllers();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                        Configuration.GetSection("AppSettings:Token").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAuthorization(options =>
            {
               options.AddPolicy("CanRead", policy =>
               {
                   policy.RequireAssertion(context =>
                       context.User.HasClaim("HasAcceptedTermsAndConditions", "True") ||
                       context.User.IsInRole("Admin"));
               });
               options.AddPolicy("CanEdit", policy =>
               {
                   policy.RequireAssertion(context =>
                       context.User.IsInRole("Admin") ||
                       context.User.HasClaim("HasAcceptedTermsAndConditions", "True") &&
                       context.User.IsInRole("User"));
               });
               options.AddPolicy("CanCreate", policy =>
               {
                   policy.RequireAssertion(context =>
                       context.User.IsInRole("Admin") ||
                       context.User.HasClaim("HasAcceptedTermsAndConditions", "True") &&
                       context.User.IsInRole("User"));
               });
               options.AddPolicy("CanDelete", policy =>
               {
                   policy.RequireRole("Admin");
               });
            });

            services.AddCors();

            services.AddAutoMapper(typeof(Startup));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IMapRepository, MapRepository>();
            services.AddScoped<ICombatRoleRepository, CombatRoleRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IParticipationRepository, ParticipationRepository>();

            services.AddScoped<IMapService, MapService>();
            services.AddScoped<ICombatRoleService, CombatRoleService>();
            services.AddScoped<IOperationService, OperationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IParticipationService, ParticipationService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "BSF API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BSF API");
                c.RoutePrefix = string.Empty;
            });

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
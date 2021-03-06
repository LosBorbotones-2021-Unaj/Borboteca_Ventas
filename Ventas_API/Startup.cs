using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ventas_AccessData;
using Ventas_AccessData.Commands;
using Ventas_AccessData.Queries;
using Ventas_AccessData.Validations.CarroLibroValidations;
using Ventas_AccessData.Validations.CarroValidations;
using Ventas_AccessData.Validations.VentasValidations;
using Ventas_Application.Services;
using Ventas_Application.Services.Interface_Service;
using Ventas_Domain.Commands;
using Ventas_Domain.IDatabaseValidations;
using Ventas_Domain.Queries;

namespace Ventas_API
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
            var connectionString = Configuration.GetSection("connectionString").Value;
           
            services.AddDbContext<VentasContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<ICarroLibroQuery, CarroLibroQuery>();
            services.AddTransient<ICarroQuery, CarroQuery>();
            services.AddTransient<IVentasQuery, VentasQuery>();
            services.AddTransient<IVentasService, VentasService>();
            services.AddTransient<ICarroLibroService, CarroLibroService>();
            services.AddTransient<ICarroService, CarroService>();
            services.AddTransient<IQueryGeneric, QueryGeneric>();
            services.AddTransient<ICarroValidations, CarroValidations>();
            services.AddTransient<IVentasValidations, VentasValidations>();
            services.AddTransient<ICarroLibroValidations, CarroLibroValidations>();

            //SKL KATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            //SWAGER
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Borboteca_Ventas", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AnyAllow", policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            //JWT
            var key = Encoding.ASCII.GetBytes(Configuration.GetSection("JwtSettings:Secret").Value);
            services.AddAuthentication(au =>
            {
                au.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                au.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.RequireHttpsMetadata = false;
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Borboteca_Ventas.API v1"));
            }

            app.UseCors("AnyAllow");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

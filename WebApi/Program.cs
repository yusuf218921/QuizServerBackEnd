using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyRevolvers.Autofac;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            

            builder.Services.AddControllers();
            // QuizFrontEnd'in �al��t��� localle ba�lant� olu�turmak i�in
            builder.Services.AddCors(options =>
            {
                // Bu Bilgisayarda QuizFrontend localhost:3000 portunda �al���yor, kendi bilgisayar�n�zda
                // frontend hangi localde �al���yorsa api ba�lant�s�n�n d�zg�n kurulabilmesi i�in ona g�re config�re edin
                // �rn: localhost:5500 portunda �al���yorsa "http://localhost:3000" k�sm�n� ona g�re d�zenleyin
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:3000")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();



            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                .AddJwtBearer(options =>

                {

                    options.TokenValidationParameters = new TokenValidationParameters

                    {

                        ValidateIssuer = true,

                        ValidateAudience = true,

                        ValidateLifetime = true,

                        ValidIssuer = tokenOptions.Issuer,

                        ValidAudience = tokenOptions.Audience,

                        ValidateIssuerSigningKey = true,

                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                    };

                });
            builder.Services.AddDependencyResolvers(new ICoreModule[] {
            new CoreModule()});
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Host.UseServiceProviderFactory(services => new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                });
            
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");

            app.MapControllers();
            

            app.Run();
        }
    }
}
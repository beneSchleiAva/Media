
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FrontendBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Persistence.Entities.Concrete.Context;

namespace ReactApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<EntityContext>();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(ConfigureContainer);
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("AllowSpecificOrigins");
            app.UseCors(cp =>
            {
                cp.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            app.MapControllers();

            app.Run();
        }

        private static void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DependencyModule>();
        }
    }
}

using CleanArchit.Infrastructure.IoC;
using CleanArchit.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Swashbuckle.AspNetCore.Swagger;
using CleanArchit.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionStringDbCourse = builder.Configuration.GetConnectionString("CourseConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<CourseDBContext>(options =>
                options.UseSqlServer(connectionStringDbCourse));
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c=>c.SwaggerDoc("UniversityAPI", new Microsoft.OpenApi.Models.OpenApiInfo() 
                                                            { Title="Universaty API", Version="V1"}));

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "University API V1");
            });

            app.MapControllers();

            app.Run();
        }
        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }
    }
}
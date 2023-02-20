using Microsoft.Extensions.DependencyInjection;
using CleanArchit.Application.Services;
using CleanArchit.Application.Interfases;
using CleanArchit.Domain.Intarfaces;
using CleanArchit.Infrastructure.Data.Repository;

namespace CleanArchit.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            //Application layer
            services.AddScoped<ICourseService, CourseService>();

            //Infrastructure Data
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}

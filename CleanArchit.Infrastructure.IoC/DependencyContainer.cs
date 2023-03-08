using Microsoft.Extensions.DependencyInjection;
using CleanArchit.Application.Services;
using CleanArchit.Application.Interfases;
using CleanArchit.Domain.Intarfaces;
using CleanArchit.Infrastructure.Data.Repository;
using CleanArchit.Domain.Core.Bus;
using CleanArchit.Infrastructure.Bus;
using MediatR;
using CleanArchit.Domain.Commands;
using CleanArchit.Domain.CommandHandlers;
using CleanArchit.Infrastructure.Data.Context;

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
            services.AddScoped <CourseDBContext> ();

            //MediatoR

            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Domain Handler
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();
        }
    }
}

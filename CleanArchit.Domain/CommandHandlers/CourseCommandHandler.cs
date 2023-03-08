using CleanArchit.Domain.Commands;
using CleanArchit.Domain.Intarfaces;
using CleanArchit.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchit.Domain.CommandHandlers
{
    public class CourseCommandHandler : IRequestHandler<CourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;

        public CourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Task<bool> Handle(CourseCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var course = new Course()
                {
                    Name = request.Name,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                };
                _courseRepository.Add(course);
            }
            catch
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}

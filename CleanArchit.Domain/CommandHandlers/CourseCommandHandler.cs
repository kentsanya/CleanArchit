using CleanArchit.Domain.Commands;
using CleanArchit.Domain.Intarfaces;
using CleanArchit.Domain.Models;
using MediatR;

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
                    Price=request.Price,
                    Author=request.Author,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                };
                _courseRepository.Add(course);
                _courseRepository.Save();
            }
            catch
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}

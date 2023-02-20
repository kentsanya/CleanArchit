using CleanArchit.Application.Interfases;
using CleanArchit.Application.ViewModels;
using CleanArchit.Domain.Intarfaces;

namespace CleanArchit.Application.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository) 
        {
            _courseRepository = courseRepository;
        }
        public ViewCourseModel GetViewCourse()
        {
            return new ViewCourseModel 
            { 
                Courses = _courseRepository.GetCourses() 
            };
        }
    }
}

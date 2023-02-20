using CleanArchit.Domain.Intarfaces;
using CleanArchit.Domain.Models;
using CleanArchit.Infrastructure.Data.Context;

namespace CleanArchit.Infrastructure.Data.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private CourseDBContext _context;
        public CourseRepository(CourseDBContext context) 
        {
            _context = context;
        }
        public IEnumerable<Course> GetCourses()
        {
            return _context.Courses;
        }
    }
}

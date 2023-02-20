using CleanArchit.Domain.Models;


namespace CleanArchit.Domain.Intarfaces
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetCourses(); 
    }
}

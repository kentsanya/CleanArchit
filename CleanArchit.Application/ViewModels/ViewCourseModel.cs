using CleanArchit.Domain.Models;


namespace CleanArchit.Application.ViewModels
{
    public class ViewCourseModel
    {
        public IQueryable<Course> Courses { get; set; }
    }
}

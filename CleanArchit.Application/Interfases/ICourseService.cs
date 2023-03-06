using CleanArchit.Application.ViewModels;
using CleanArchit.Domain.Models;

namespace CleanArchit.Application.Interfases
{
    public interface ICourseService
    {
        public ViewCourseModel GetViewCourse();

        public void Add(Course entity);


        public Course? FindById(int id);


        public bool Remove(Course entity);

        public void Save();
 

        public  Task SaveAsync();
       

        public bool UpDate(Course entity);
        
    }
}

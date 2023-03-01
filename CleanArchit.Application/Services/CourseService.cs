using CleanArchit.Application.Interfases;
using CleanArchit.Application.ViewModels;
using CleanArchit.Domain.Intarfaces;
using CleanArchit.Domain.Models;

namespace CleanArchit.Application.Services
{
    public class CourseService : ICourseService
    {
        private ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository) 
        {
            _courseRepository = courseRepository;
        }

        public void Add(Course entity)
        {
            _courseRepository.Add(entity);
        }

        public Course? FindById(int id)
        {
            return _courseRepository.FindById(id);
        }

        public ViewCourseModel GetViewCourse()
        {
            return new ViewCourseModel
            {
                Courses = _courseRepository.GetAll()
            };
        }

        public bool Remove(Course entity)
        {
             return  _courseRepository.Remove(entity);
        }

        public void Save()
        {
            _courseRepository.Save();
        }

        public async Task SaveAsync()
        {
           await _courseRepository.SaveAsync();
        }

        public bool UpDate(Course entity)
        {
            return _courseRepository.UpDate(entity);
        }
    }
}

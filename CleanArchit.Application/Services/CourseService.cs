using CleanArchit.Application.Interfases;
using CleanArchit.Application.ViewModels;
using CleanArchit.Domain.Commands;
using CleanArchit.Domain.Core.Bus;
using CleanArchit.Domain.Intarfaces;
using CleanArchit.Domain.Models;

namespace CleanArchit.Application.Services
{
    public class CourseService : ICourseService
    {
        //Polymorf connection
        private ICourseRepository _courseRepository;
        private IMediatorHandler _bus;
        public CourseService(ICourseRepository courseRepository, IMediatorHandler mediator) 
        {
            _bus= mediator;
            _courseRepository = courseRepository;
        }

        public void Add(Course entity)
        {
            var createCourseCommand = new CreateCourseCommand(
               entity.Name,
               entity.Description,
               entity.Author,
               entity.Price,
               entity.ImageUrl
             );
            _bus.SendCommand(createCourseCommand);
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

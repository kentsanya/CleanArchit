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

        public void Add(Course entity)
        {
            _context.Add(entity);
        }

        public Course? FindById(int id)
        {
            if (id != 0)
            {
                var course = _context.Courses.FirstOrDefault(c => c.Id == id);
                if (course != null)
                    return course;
            }
            return default;

        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public bool Remove(Course entity)
        {
            if (entity != null)
            {
                _context.Courses.Remove(entity);
                return true;
            }
            else return false;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool UpDate(Course entity)
        {
            try
            {
                if (entity != null)
                {
                    _context.Courses.Update(entity);
                    return true;
                }else return false;
            }
            catch 
            {
                return false;
            }
        }
    }
}

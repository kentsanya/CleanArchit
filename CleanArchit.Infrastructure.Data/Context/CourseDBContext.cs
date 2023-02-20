using CleanArchit.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchit.Infrastructure.Data.Context
{
    public class CourseDBContext:DbContext
    {
        public CourseDBContext(DbContextOptions<CourseDBContext> options) : base(options)
        {
           Database.EnsureCreated();
        }
        public DbSet<Course> Courses { get; set; }
    }
}

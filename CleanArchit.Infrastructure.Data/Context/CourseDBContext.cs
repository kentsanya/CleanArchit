using CleanArchit.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArchit.Infrastructure.Data.Context
{
    public class CourseDBContext:DbContext
    {
        public CourseDBContext(DbContextOptions<CourseDBContext> options) : base(options)
        {

        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            //optionsBuilder.UseLazyLoadingProxies();
        }
    }
}

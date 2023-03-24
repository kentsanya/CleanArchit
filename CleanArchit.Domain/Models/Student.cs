

namespace CleanArchit.Domain.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public List<Course> Courses { get; set; } 

        //navigation property
        public List<Mark> Marks { get; set; }


    }
}

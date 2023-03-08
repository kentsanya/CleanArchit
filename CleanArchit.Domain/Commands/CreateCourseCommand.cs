

namespace CleanArchit.Domain.Commands
{
    public class CreateCourseCommand:CourseCommand
    {
        public CreateCourseCommand(string name, string description, string imageurl) 
        {
            Name = name;
            Description = description;
            ImageUrl= imageurl;
        }
    }
}

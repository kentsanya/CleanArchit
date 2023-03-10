
namespace CleanArchit.Domain.Commands
{
    public class CreateCourseCommand:CourseCommand
    {
        public CreateCourseCommand(string name, string description, string author, decimal price, string imageurl) 
        {
            Name = name;
            Description = description;
            Author= author;
            Price = price;
            ImageUrl= imageurl;
        }
    }
}

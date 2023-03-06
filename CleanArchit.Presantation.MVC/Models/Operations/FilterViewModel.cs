using CleanArchit.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchit.Presantation.MVC.Models.Operations
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Course> courses, int idcourse,  string name) 
        {
            courses.Insert(0, new Course { Id = 0,Name = "All"});
            Courses =new SelectList(courses,"Id", "Name", idcourse);
            SelectedCourse = idcourse;
            SelectedName=name;
        }

        public SelectList Courses { get; }

        public int SelectedCourse { get; }

        public string SelectedName { get; }


    }
}

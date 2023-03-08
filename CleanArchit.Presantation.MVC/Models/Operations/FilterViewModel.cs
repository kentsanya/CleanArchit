using CleanArchit.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CleanArchit.Presantation.MVC.Models.Operations
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Course> courses,  string name) 
        {
            Courses =new SelectList(courses,"Id", "Name");

            SelectedCourse = name;
        }

        public SelectList Courses { get; }

   
        public string SelectedCourse { get; }


    }
}

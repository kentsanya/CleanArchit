using CleanArchit.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CleanArchit.Application.ViewModels
{
    public class ViewCourseModel
    {
        internal IEnumerable<Course> Courses { get; set; }
    }
}

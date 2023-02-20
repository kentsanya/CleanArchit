using CleanArchit.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchit.Application.Interfases
{
    public interface ICourseService
    {
        public ViewCourseModel GetViewCourse();
    }
}

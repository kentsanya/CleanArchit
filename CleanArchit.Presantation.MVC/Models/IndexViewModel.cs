using CleanArchit.Domain.Models;
using CleanArchit.Presantation.MVC.Models.Operations;

namespace CleanArchit.Presantation.MVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Course> Courses { get; }
        public SortViewModel Sort { get; }
        public FilterViewModel Filter { get; }
        public PaginationViewModel Pagination { get; }

        public IndexViewModel(IEnumerable<Course> courses, SortViewModel sort, FilterViewModel filter, PaginationViewModel pagination)
        {
            Courses = courses;
            Sort = sort;
            Filter = filter;
            Pagination = pagination;
        }
    }
}

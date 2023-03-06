namespace CleanArchit.Presantation.MVC.Models.Operations
{
    public class PaginationViewModel
    {
        public PaginationViewModel(int count, int pagenumber, int pagesize) 
        {
            PageNumber = pagenumber;
            TotalPages =(int) Math.Ceiling(count / (decimal)pagesize);

        }

        public int PageNumber { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviosPage=>PageNumber > 0;
        public bool HasNextPage=>PageNumber < TotalPages;


    }
}

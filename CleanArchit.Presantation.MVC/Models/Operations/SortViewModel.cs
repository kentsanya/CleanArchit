namespace CleanArchit.Presantation.MVC.Models.Operations
{
    public class SortViewModel
    {
        public SortViewModel(SortState sortState) 
        {
            NameSort = sortState == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            AuthorSort = sortState == SortState.AuthorAsc ? SortState.AuthorDesc : SortState.AuthorAsc;
            PriceSort = sortState == SortState.PriceAsc ? SortState.PriceDesc : SortState.PriceAsc;
            Current= sortState;
        }

        public SortState NameSort { get; }
        public SortState AuthorSort { get; }
        public SortState PriceSort { get; }
        public SortState Current { get; }

    }
}

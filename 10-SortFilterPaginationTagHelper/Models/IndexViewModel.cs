namespace _10_SortFilterPaginationTagHelper.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }

        public IndexViewModel(IEnumerable<User> users, FilterViewModel filterViewModel,
            SortViewModel sortViewModel, PageViewModel pageViewModel)
        {
            Users = users;
            FilterViewModel = filterViewModel;
            SortViewModel = sortViewModel;
            PageViewModel = pageViewModel;
        }
    }
}

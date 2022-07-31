namespace _7_Pagination.Models
{
    public class IndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public PageViewModel PageViewModel { get; set; }

        public IndexViewModel(IEnumerable<User> users, PageViewModel pageViewModel)
        {
            Users = users;
            PageViewModel = pageViewModel;
        }
    }
}

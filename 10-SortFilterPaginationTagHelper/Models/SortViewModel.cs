namespace _10_SortFilterPaginationTagHelper.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; set; }
        public SortState AgeSort { get; set; }
        public SortState CompanySort { get; set; }
        public SortState Current { get; set; }
        public SortState ForPage { get; set; }
        public bool Up { get; set; }

        public SortViewModel(SortState sortOrder)
        {
            NameSort = SortState.NameAsc;
            AgeSort = SortState.AgeAsc;
            CompanySort = SortState.CompanyAsc;
            Up = sortOrder != SortState.NameDesc &&
                sortOrder != SortState.CompanyDesc &&
                sortOrder != SortState.AgeDesc;
            ForPage = sortOrder;

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    Current = NameSort = SortState.NameAsc;
                    break;
                case SortState.AgeAsc:
                    Current = AgeSort = SortState.AgeDesc;
                    break;
                case SortState.AgeDesc:
                    Current = AgeSort = SortState.AgeAsc;
                    break;
                case SortState.CompanyAsc:
                    Current = CompanySort = SortState.CompanyDesc;
                    break;
                case SortState.CompanyDesc:
                    Current = CompanySort = SortState.CompanyAsc;
                    break;
                default:
                    Current = NameSort = SortState.NameDesc;
                    break;
            }
        }
    }
}

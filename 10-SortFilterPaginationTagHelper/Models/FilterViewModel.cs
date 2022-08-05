using Microsoft.AspNetCore.Mvc.Rendering;

namespace _10_SortFilterPaginationTagHelper.Models
{
    public class FilterViewModel
    {
        public SelectList Companies { get; }
        public int SelectedCompany { get; }
        public string SelectedName { get; set; }

        public FilterViewModel(List<Company> companies, int companyId, string name)
        {
            companies.Insert(0, new Company() { Id = 0, Name = "Все" });
            Companies = new SelectList(companies, "Id", "Name", companyId);
            SelectedCompany = companyId;
            SelectedName = name;
        }
    }
}

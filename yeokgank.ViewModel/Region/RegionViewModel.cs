using System.Collections.Generic;
using yeokgank.ViewModel.Paging;

namespace yeokgank.ViewModel.Region
{
    public class RegionViewModel
    {
        public IEnumerable<RegionModel> Region { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

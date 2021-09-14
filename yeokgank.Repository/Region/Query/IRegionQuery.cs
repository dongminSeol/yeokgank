using System.Collections.Generic;
using yeokgank.ViewModel.Region;

namespace yeokgank.Repository.Region.Query
{
    public interface IRegionQuery
    {
        List<RegionViewModel> List(string search = "", string orderBy = "", int? pageNumber = 1, int pageSize = 10);
        List<RegionViewModel> List(string search = "", int? pageNumber = 1, int pageSize = 10);
    }
}

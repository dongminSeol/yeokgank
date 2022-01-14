using System.Collections.Generic;
using yeokgank.ViewModel.Region;

namespace yeokgank.Repository.Region.Query
{
    public interface IRegionQueries
    {
        RegionViewModel List(string ad_h_cd, string ad_m_cd, string ad_s_cd, string ad_t_cd, int? page = 1, int? pagesize = 10);
    }
}

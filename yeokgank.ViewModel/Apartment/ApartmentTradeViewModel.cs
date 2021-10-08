using System.Collections.Generic;
using yeokgank.ViewModel.Paging;

namespace yeokgank.ViewModel.Apartment
{
    public class ApartmentTradeViewModel
    {
        public IEnumerable<ApartmentTradeModel> ApartmentTrade { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

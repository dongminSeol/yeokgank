using yeokgank.ViewModel.Apartment;
namespace yeokgank.Repository.Apartment.Query
{
    public interface IApartmentQuery
    {
        ApartmentTradeViewModel TradeMonth(string ad_h_cd, string ad_m_cd, string startdate, string enddate);
    }
}

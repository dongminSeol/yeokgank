using yeokgank.ViewModel.Apartment;
namespace yeokgank.Repository.Apartment.Query
{
    interface IApartmentQuery
    {
        ApartmentTradeViewModel Trade(string search = "", int? page = 1, int pagesize = 10);
    }
}

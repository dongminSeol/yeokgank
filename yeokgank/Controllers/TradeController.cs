using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using yeokgank.Repository.Apartment.Query;

namespace yeokgank.Controllers
{
    [Route("api/[controller]/[action]"), Produces("application/json")]
    [ApiController]
    public class TradeController : ControllerBase
    {
        private readonly ILogger<TradeController> _logger;
        private readonly IApartmentQueries _apartmentQuery;
        public TradeController(ILogger<TradeController> logger, IApartmentQueries apartmentQuery) 
        {
            _logger = logger;
            _apartmentQuery = apartmentQuery;
        }

        [HttpGet]
        public IActionResult Month(string h_cd, string m_cd,string s_date, string e_date)
        {
            var data = _apartmentQuery.TradeMonth(h_cd, m_cd, s_date, e_date);
            return Ok(data);
        }

    }
}

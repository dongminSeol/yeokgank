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
        private readonly IApartmentQueries _apartmentQueries;
        public TradeController(ILogger<TradeController> logger, IApartmentQueries apartmentQueries) 
        {
            _logger = logger;
            _apartmentQueries = apartmentQueries;
        }

        [HttpGet]
        public IActionResult Month(string h_cd, string m_cd,string s_date, string e_date)
        {
            var data = _apartmentQueries.TradeMonth(h_cd, m_cd, s_date, e_date);
            return Ok(data);
        }

    }
}

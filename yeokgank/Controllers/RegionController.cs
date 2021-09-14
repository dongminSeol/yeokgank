using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using yeokgank.Repository.Region.Query;
namespace yeokgank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionQuery _regionQuery;
        private readonly ILogger<RegionController> _logger;
        public RegionController(ILogger<RegionController> logger, IRegionQuery regionQuery) 
        {
            _logger = logger;
            _regionQuery = regionQuery;
        }

        public dynamic Get()
        {
            
            var data = _regionQuery.List(search: "", pageNumber: 1, pageSize: 10);

            //_logger.LogInformation();
            //_logger.LogDebug(JsonResult)

            return data;
        }
    }
}

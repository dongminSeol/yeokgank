﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using yeokgank.Repository.Region.Query;
namespace yeokgank.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]"), Produces("application/json")]
    public class RegionController : ControllerBase
    {
        private readonly ILogger<RegionController> _logger;
        private readonly IRegionQueries _regionQuery;
        public RegionController(ILogger<RegionController> logger, IRegionQueries regionQuery)
        {
            _logger = logger;
            _regionQuery = regionQuery;
        }

        [HttpGet]
        public IActionResult List(string h_cd, string m_cd, string s_cd, string t_cd, int? page = 1 ,int? size = 10)
        {
             
            var data = _regionQuery.List(h_cd, m_cd, s_cd, t_cd, page, size);

            //_logger.LogInformation();
            //_logger.LogDebug(JsonResult)

            return Ok(data);
        }
    }
}

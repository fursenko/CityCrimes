using CityCrimes.Common;
using CityCrimes.DAL;
using CityCrimes.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace CityCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesController : ControllerBase
    {
        private readonly IOptions<CityCrimesConfig> _config;

        public CrimesController(IOptions<CityCrimesConfig> config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Crime>> Get(string type, string year)
        {
            var request = new SearchCrimesRequest() { PrimaryType = type, Year = year, Db = _config.Value.Database };
            
            IEnumerable<Crime> result = new CrimeDB(_config.Value.DatabaseServer).GetCrimes(request);

            return Ok(result);
        }
    }
}
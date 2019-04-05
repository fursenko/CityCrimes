using CityCrimes.Common;
using CityCrimes.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CityCrimes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Crime>> Get(string type, string year)
        {
            var request = new SearchCrimeRequest() { PrimaryType = type, Year = year };
            IEnumerable<Crime> result = new CrimeDB().GetCrimes(request);

            return Ok(result);
        }
    }
}
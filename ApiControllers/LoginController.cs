using CoinCalculatorAPI.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoinCalculatorAPI.ApiControllers
{
    [Route( "[controller]" )]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //No Auth needed
        // POST api/<LoginController>
        [HttpPost]
        public async Task<ActionResult> Post( [FromBody] Credentials creds )
        {
            //hash pass
            HashSlingingSlasher hashIt = new HashSlingingSlasher();
            creds.password = hashIt.HashItOut( creds.password );
            //check against "db", TODOL Add a DB
            if( DBHelper.Login( creds ) )
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
            
        }
    }
}

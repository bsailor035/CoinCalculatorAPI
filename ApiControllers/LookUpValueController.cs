using CoinCalculatorAPI.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoinCalculatorAPI.ApiControllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class LookUpValueController : ControllerBase
    {
        //Auth
        // POST api/<LookUpValueController>
        [HttpPost]
        public async Task<Wallet> Post( [FromBody] RequestedLookup lookupRequest )
        {

            return new Wallet();
        }
    }
}

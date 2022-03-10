using CoinCalculatorAPI.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoinCalculatorAPI.ApiControllers
{
    [Route( "/[controller]" )]
    [ApiController]
    public class CreateUserController : ControllerBase
    {
        //No Auth needed
        // POST api/<CreateUserController>
        [HttpPost]
        public async Task<ActionResult> Post( [FromBody] User user )
        {
            //hash pass
            HashSlingingSlasher hashIt = new HashSlingingSlasher();
            user.password = hashIt.HashItOut( user.password );
            //store info
            if(DBHelper.AddUser(user))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

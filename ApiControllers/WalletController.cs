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
    public class WalletController : ControllerBase
    {
        //Auth
        // GET: api/<WalletController>
        [HttpGet]
        public async Task<Wallet> Get()
        {
            return new Wallet();
        }

        //Auth
        //POST: Add Coin to wallet
        [HttpPost]
        public async Task<ActionResult<Wallet>> Post( Coin coin )
        {
            User user = new User();
            Wallet wallet = new Wallet();
            //Add the latest coin to the wallet, return total wallet

        }

        //POST: Add Coin to wallet
        [HttpDelete]
        public async Task<ActionResult<Wallet>> Delete( Coin coin )
        {
            User user = new User();
            Wallet wallet = new Wallet();
            //Add the latest coin to the wallet, return total wallet

        }
    }
}

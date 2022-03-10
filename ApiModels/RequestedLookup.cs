using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinCalculatorAPI.ApiModels
{
    public class RequestedLookup
    {
        public RequestedLookup()
        {

        }

        [Required]
        public Wallet wallet { get; set; }
        [Required]
        public string currencySymbol { get; set; }
    }
}

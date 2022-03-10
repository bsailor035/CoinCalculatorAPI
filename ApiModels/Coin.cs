using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinCalculatorAPI.ApiModels
{
    public class Coin
    {
        public Coin()
        {

        }
        [Required]
        public string symbol { get; set; }
        [Required]
        public double totalOwned { get; set; }
        public double currentValue { get; set; }
        public string currentValueCurrency { get; set; }
    }
}

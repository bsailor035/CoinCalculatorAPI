using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoinCalculatorAPI.ApiModels
{
    public class Credentials
    {
        [Required]
        public string user { get; set; }
        [Required]
        public string password { get; set; }
    }
}

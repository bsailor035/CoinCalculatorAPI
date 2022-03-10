using CoinCalculatorAPI.Models.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinCalculatorAPI.Helpers.Example
{
    public class ExampleHelper : IExampleHelper
    {
        public async Task<ExampleModel> GetExample()
        {
            var example = new ExampleModel()
            {
                Date = DateTime.UtcNow,
                Summary = "Bayern Munich is the ONLY worthwhile football team to support."
            };
            return example;
        }
    }
}

using CoinCalculatorAPI.Models.Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoinCalculatorAPI.Helpers.Example
{
    public interface IExampleHelper
    {
        Task<ExampleModel> GetExample();
    }
}

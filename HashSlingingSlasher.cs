using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CoinCalculatorAPI
{
    public class HashSlingingSlasher
    {
        public HashSlingingSlasher()
        {

        }

        public string HashItOut(string pass)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[ 128 / 8 ];
            using( var rngCsp = new RNGCryptoServiceProvider() )
            {
                rngCsp.GetNonZeroBytes( salt );
            }
            Console.WriteLine( $"Salt: {Convert.ToBase64String( salt )}" );

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            return Convert.ToBase64String( KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8 ) );
        }
    }
}

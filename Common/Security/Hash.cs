using Scrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFSE.Common.Security
{
    /// <summary>
    /// A class to contain all Hashing functions the portal might need.
    /// </summary>
    public static class Hash
    {
        /// <summary>
        /// Hash using the Scrypt algorithm. State-of-the-art password hashing as of 2016.
        /// The following implementation was used: https://github.com/viniciuschiele/Scrypt
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        public static string Scrypt(string plaintext)
        {
            ScryptEncoder encoder = new ScryptEncoder();

            string hashedText = encoder.Encode(plaintext);

            return hashedText;
        }
        
        /// <summary>
        /// Compare a plaintext password with a hash.
        /// </summary>
        /// <param name="plaintext"></param>
        /// <param name="hashedText"></param>
        /// <returns></returns>
        public static bool CompareScrypt(string plaintext, string hashedText)
        {
            ScryptEncoder encoder = new ScryptEncoder();

            bool areEquals = encoder.Compare(plaintext, hashedText);

            return areEquals;
        }
    }
}

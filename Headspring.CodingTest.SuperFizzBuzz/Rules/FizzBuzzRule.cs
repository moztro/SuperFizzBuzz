using System;
using System.Collections.Generic;
using System.Text;

namespace Headspring.CodingTest.SuperFizzBuzz.Rules
{
    /// <summary>
    /// Represents a rule against what the dividend will run against to. Checking if
    /// dividend is multiple of the Divisor set
    /// </summary>
    public class FizzBuzzRule
    {
        /// <summary>
        /// The integer value to which the dividend will be checked for multiple
        /// </summary>
        public int Divisor { get; set; }

        /// <summary>
        /// The output message to display if dividend is a multiple of the divisor
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Indicates whether or not the dividend is multiple of Divisor rule set
        /// </summary>
        /// <param name="dividend"></param>
        /// <returns></returns>
        public bool IsMultiple(int dividend) => dividend % Divisor == 0;
    }
}

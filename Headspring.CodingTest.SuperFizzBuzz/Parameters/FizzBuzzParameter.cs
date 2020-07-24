using Headspring.CodingTest.SuperFizzBuzz.Rules;
using System.Collections.Generic;

namespace Headspring.CodingTest.SuperFizzBuzz.Parameters
{
    public class FizzBuzzParameter
    {
        /// <summary>
        /// Contains a set of numbers to which the FizzBuzz will run
        /// </summary>
        public  ICollection<int> Range { get; set; }

        /// <summary>
        /// Set of rules to which the Range will be validated against
        /// </summary>
        public ICollection<FizzBuzzRule> Rules { get; set; }
    }
}

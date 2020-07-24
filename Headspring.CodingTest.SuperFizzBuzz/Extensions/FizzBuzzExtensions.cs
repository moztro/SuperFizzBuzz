using Headspring.CodingTest.SuperFizzBuzz.Rules;
using System.Collections.Generic;

namespace Headspring.CodingTest.SuperFizzBuzz.Extensions
{
    public static class FizzBuzzExtensions
    {
        /// <summary>
        /// Check whether the dividend number is multiple of a set of rules
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="fizzBuzzRules"></param>
        /// <returns></returns>
        public static string FizzBuzzCheck(this int dividend, ICollection<FizzBuzzRule> fizzBuzzRules)
        {
            string outputMessage = string.Empty;

            // Iterate over each rule to check if dividend is multiple of any of the rules set
            foreach(FizzBuzzRule rule in fizzBuzzRules)
            {
                if(rule.IsMultiple(dividend))
                    // If is multiple, retrieve the token and add it to the output message result
                    outputMessage += rule.Token;
            }

            return outputMessage;
        }
    }
}

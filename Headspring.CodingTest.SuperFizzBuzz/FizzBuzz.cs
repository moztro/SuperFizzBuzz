using Headspring.CodingTest.SuperFizzBuzz.Extensions;
using Headspring.CodingTest.SuperFizzBuzz.Parameters;
using System;

namespace Headspring.CodingTest.SuperFizzBuzz
{
    public class FizzBuzz
    {
        /// <summary>
        /// Executes the fizz buzz check against the arguments provided
        /// </summary>
        /// <param name="parameter"></param>
        public void Run(FizzBuzzParameter parameter)
        {
            foreach(int dividend in parameter.Range)
            {
                // Get the token message(s) for the dividend if any
                string token = dividend.FizzBuzzCheck(parameter.Rules);

                // If token is empty, get the number to print instead
                string outputMessage = !string.IsNullOrEmpty(token) ? token : dividend.ToString();

                // Prints to the console
                Console.WriteLine(outputMessage);
            }
        }
    }
}

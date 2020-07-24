using Headspring.CodingTest.SuperFizzBuzz;
using Headspring.CodingTest.SuperFizzBuzz.Rules;
using Headspring.CodingTest.SuperFizzBuzz.Parameters;
using System;
using System.Collections.Generic;

namespace Headspring.CodingTest.AdvancedFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solving Super FizzBuzz");

            var parameterByRange = new FizzBuzzRangeParameter(-12, 145);
            parameterByRange.Rules = new List<FizzBuzzRule>
            {
                new FizzBuzzRule { Divisor = 3, Token = "Fizz" },
                new FizzBuzzRule { Divisor = 5, Token = "Buzz" },
                new FizzBuzzRule { Divisor = 38, Token = "Bazz" }
            };

            var superFizzBuzz = new FizzBuzz();
            superFizzBuzz.Run(parameterByRange);

            Console.ReadKey();
        }
    }
}

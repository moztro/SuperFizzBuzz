using System;
using System.Collections.Generic;
using Headspring.CodingTest.SuperFizzBuzz;
using Headspring.CodingTest.SuperFizzBuzz.Rules;
using Headspring.CodingTest.SuperFizzBuzz.Parameters;

namespace Headspring.CodingTest.ClassicFizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Solving classic FizzBuzz");

            var parameterByRange = new FizzBuzzRangeParameter(1, 100);
            parameterByRange.Rules = new List<FizzBuzzRule>
            {
                new FizzBuzzRule { Divisor = 3, Token = "Fizz" },
                new FizzBuzzRule { Divisor = 5, Token = "Buzz" }
            };

            var superFizzBuzz = new FizzBuzz();
            superFizzBuzz.Run(parameterByRange);

            Console.ReadKey();
        }
    }
}

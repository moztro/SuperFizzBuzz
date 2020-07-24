using Headspring.CodingTest.SuperFizzBuzz;
using Headspring.CodingTest.SuperFizzBuzz.Extensions;
using Headspring.CodingTest.SuperFizzBuzz.Rules;
using Headspring.CodingTest.SuperFizzBuzz.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Headspring.CodingTest.Tests
{
    public class SuperFizzBuzzTests
    {
        #region Overall flow tests
        [Theory]
        [InlineData(-10, -100)]
        [InlineData(-200, -100)]
        [InlineData(-100, -50)]
        [InlineData(-50, 0)]
        [InlineData(0, 50)]
        [InlineData(50, 100)]
        [InlineData(100, 200)]
        [InlineData(-1000, 1000)]
        [InlineData(0, 0)]
        public void SuperFizzBuzzWithRangeParameters(int start, int end)
        {
            var parameterByRange = new FizzBuzzRangeParameter(start, end);
            parameterByRange.Rules = new List<FizzBuzzRule>
            {
                new FizzBuzzRule { Divisor = 3, Token = "Fizz" },
                new FizzBuzzRule { Divisor = 5, Token = "Buzz" },
                new FizzBuzzRule { Divisor = 38, Token = "Bazz" }
            };

            var superFizzBuzz = new FizzBuzz();
            superFizzBuzz.Run(parameterByRange);
        }

        [Fact]
        public void SuperFizzBuzzWithSetOfSequentialIntegerParameters()
        {
            var parameterByRange = new FizzBuzzParameter();
            parameterByRange.Range = new List<int> { 1, 30, 50, 77, 188, 12323, 3094 };
            parameterByRange.Rules = new List<FizzBuzzRule>
            {
                new FizzBuzzRule { Divisor = 3, Token = "Fizz" },
                new FizzBuzzRule { Divisor = 5, Token = "Buzz" },
                new FizzBuzzRule { Divisor = 38, Token = "Bazz" }
            };

            var superFizzBuzz = new FizzBuzz();
            superFizzBuzz.Run(parameterByRange);
        }

        [Fact]
        public void SuperFizzBuzzWithSetOfNonSequentialIntegerParameters()
        {
            var parameterByRange = new FizzBuzzParameter();
            parameterByRange.Range = new List<int> { 100, 30, 50, -77, 188, -12323, 1, 0, 3094 };
            parameterByRange.Rules = new List<FizzBuzzRule>
            {
                new FizzBuzzRule { Divisor = 3, Token = "Fizz" },
                new FizzBuzzRule { Divisor = 5, Token = "Buzz" },
                new FizzBuzzRule { Divisor = 38, Token = "Bazz" }
            };

            var superFizzBuzz = new FizzBuzz();
            superFizzBuzz.Run(parameterByRange);
        }
        #endregion Overall flow tests

        #region Parameters creation tests
        [Theory]
        [InlineData(-200, -100)]
        [InlineData(-100, -50)]
        [InlineData(-50, 0)]
        [InlineData(0, 50)]
        [InlineData(50, 100)]
        [InlineData(100, 200)]
        [InlineData(-1000, 1000)]
        [InlineData(0, 0)]
        public void CanCreateSequentialRangeParameters(int start, int end)
        {
            Assert.IsType<FizzBuzzRangeParameter>(new FizzBuzzRangeParameter(start, end));
        }

        [Theory]
        [InlineData(-100, -200)]
        [InlineData(0, -50)]
        [InlineData(100, 0)]
        [InlineData(1000, -1000)]
        public void CanCreateNonSequentialRangeParameters(int start, int end)
        {
            Assert.IsType<FizzBuzzRangeParameter>(new FizzBuzzRangeParameter(start, end));
        }

        [Fact]
        public void CanCreateValidSetOfSequentialIntegerParameters()
        {
            var setOfIntegersParameter = new FizzBuzzParameter()
            {
                Range = new List<int> { 1, 2, 3, 4, 5 }
            };

            Assert.IsType<FizzBuzzParameter>(setOfIntegersParameter);
            Assert.NotEmpty(setOfIntegersParameter.Range);
        }

        [Fact]
        public void CanCreateValidSetOfNonSequentialIntegerParameters()
        {
            var setOfIntegersParameter = new FizzBuzzParameter()
            {
                Range = new List<int> { 3, 2, 5, 1, 4 }
            };

            Assert.IsType<FizzBuzzParameter>(setOfIntegersParameter);
            Assert.NotEmpty(setOfIntegersParameter.Range);
        }

        [Theory]
        [InlineData(1, 100)]
        [InlineData(-100, 100)]
        public void CanCreateSequentialRangeWithProvidedRangeParameters(int rangeStart, int rangeEnd)
        {
            var fizzBuzzRangeParameter = new FizzBuzzRangeParameter(rangeStart, rangeEnd);
            var expectedRange = new List<int>();

            for (int i = rangeStart; i <= rangeEnd; i++)
                expectedRange.Add(i);

            Assert.Equal(expectedRange.Count, fizzBuzzRangeParameter.Range.Count);
            Assert.Equal(expectedRange, fizzBuzzRangeParameter.Range.ToList());
        }

        #endregion Parameters creation tests

        #region Rules tests
        [Theory]
        [InlineData(5, 5)]
        [InlineData(25, 5)]
        [InlineData(9, 3)]
        [InlineData(27, 3)]
        public void IsValidMultiple(int dividend, int divisor)
        {
            var fizzBuzzRule = new FizzBuzzRule();
            fizzBuzzRule.Divisor = divisor;

            Assert.True(fizzBuzzRule.IsMultiple(dividend));
        }

        [Theory]
        [InlineData(8, 5)]
        [InlineData(89, 5)]
        [InlineData(10, 3)]
        [InlineData(100, 3)]
        public void IsInvalidMultiple(int dividend, int divisor)
        {
            var fizzBuzzRule = new FizzBuzzRule();
            fizzBuzzRule.Divisor = divisor;

            Assert.False(fizzBuzzRule.IsMultiple(dividend));
        }

        [Theory]
        [InlineData(3, 3, "Fizz")]
        [InlineData(9, 3, "Fizz")]
        [InlineData(5, 5, "Buzz")]
        [InlineData(10, 5, "Buzz")]
        public void RuleReturnsValidToken(int dividend, int divisor, string token)
        {
            var rule = new FizzBuzzRule { Divisor = divisor, Token = token};
            var rules = new List<FizzBuzzRule> { rule };

            string output = dividend.FizzBuzzCheck(rules);

            Assert.Equal(token, output);
        }

        [Theory]
        [InlineData(10, 3, "Fizz")]
        [InlineData(100, 3, "Fizz")]
        [InlineData(21, 5, "Buzz")]
        [InlineData(123, 5, "Buzz")]
        public void RuleReturnsInvalidToken(int dividend, int divisor, string token)
        {
            var rule = new FizzBuzzRule { Divisor = divisor, Token = token };
            var rules = new List<FizzBuzzRule> { rule };

            string output = dividend.FizzBuzzCheck(rules);

            Assert.NotEqual(token, output);
        }
        #endregion Rules tests
    }
}

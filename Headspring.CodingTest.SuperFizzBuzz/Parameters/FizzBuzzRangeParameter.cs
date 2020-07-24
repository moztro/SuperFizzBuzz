using System;
using System.Collections.Generic;
using System.Text;

namespace Headspring.CodingTest.SuperFizzBuzz.Parameters
{
    public class FizzBuzzRangeParameter : FizzBuzzParameter
    {
        public FizzBuzzRangeParameter(int rangeStart, int rangeEnd)
        {
            // Commented this since non sequential ranges are permitted
            //ValidateRange(rangeStart, rangeEnd);

            _rangeStart = rangeStart;
            _rangeEnd = rangeEnd;

            CreateRange();
        }

        private int _rangeStart { get; }
        private int _rangeEnd { get; }

        /// <summary>
        /// Create the range of number based on provided range limits
        /// </summary>
        private void CreateRange()
        {
            base.Range = new List<int>();

            if (IsRangeSequential(_rangeStart, _rangeEnd))
            {
                for (int i = _rangeStart; i <= _rangeEnd; i++)
                    base.Range.Add(i);
            }
            else
            {
                for (int i = _rangeEnd; i <= _rangeStart; i++)
                    base.Range.Add(i);
            }
        }

        /// <summary>
        /// Return whether the provided range limits are 
        /// based on a sequential order [rangeStart <= x <= rangeEnd]
        /// </summary>
        /// <param name="rangeStart"></param>
        /// <param name="rangeEnd"></param>
        /// <returns></returns>
        private bool IsRangeSequential(int rangeStart, int rangeEnd) => rangeEnd >= rangeStart;

        /// <summary>
        /// Validate that range is sequential, otherwise throws an exception
        /// </summary>
        private void ValidateRange(int rangeStart, int rangeEnd)
        {
            bool isSequential = IsRangeSequential(rangeStart, rangeEnd);

            if(!isSequential)
            {
                throw new ArgumentOutOfRangeException(
                    paramName: $"{nameof(rangeStart)}-{nameof(rangeEnd)}",
                    message: $"{rangeStart} to {rangeEnd} is not a valid range."
                );
            }
        }
    }
}

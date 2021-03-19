using System;
using System.Collections.Generic;

namespace DelegatesAndStuff
{

    public delegate bool FilterMethod(int x);
    public class NumberFilter
    {


        public List<int> FilterOutOdds(List<int> numbers)
        {

            return Filter(numbers, x => x % 2 == 0); // Method Group
        }

        public List<int> FilterOutEvens(List<int> numbers)
        {
            return Filter(numbers, theNumber => theNumber % 2 != 0);
        }

        private List<int> Filter(List<int> numbers, Predicate<int> op)
        {
            var results = new List<int>();
            foreach (var number in numbers)
            {
                if (op(number))
                {
                    results.Add(number);
                }
            }
            return results;
        }

    }
}
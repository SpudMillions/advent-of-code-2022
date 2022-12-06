using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day6 : DayBase
    {
        internal Day6(): base(6, 2022, "Tuning Trouble") { }

        public override void Play()
        {
            var input = string.Join("", Input);
            var first = 0;
            var found = false;
            var found14 = false;
            var first14 = 0;

            while (!found)
            {
                found = IsUnique(input.Substring(first, 4));
                first++;
            }


            while (!found14)
            {
                found14 = IsUnique(input.Substring(first14, 14));
                first14++;
            }
            
            Console.WriteLine($"{GetType().Name} : {Title} --- Characters Processed for 4 unique: {first + 3}. Characters processed for 14 unique: {first14 + 13}");
        }
        
        private bool IsUnique(string input)
        {
            var list = new List<char>();
            foreach (var c in input)
            {
                if (list.Contains(c))
                {
                    return false;
                }
                list.Add(c);
            }
            return true;
        }
    }
}
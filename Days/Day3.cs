using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day3 : DayBase
    {
        public Day3() : base(3, 2022, "Rucksack Reorganization"){}
        
        private const int UpperOffSet = 38;
        private const int LowerOffSet = 96;
        public override void Play()
        {
            
            var input = Input;

            var total = 0;
            var badgeTotal = 0;
            var elfCounter = 0;
            var badgeFinder = new List<string>();

            foreach (var line in input)
            {
                elfCounter++;
                badgeFinder.Add(line);

                if (elfCounter == 3)
                {
                    badgeFinder[0].Intersect(badgeFinder[1]).Intersect(badgeFinder[2]).ToList().ForEach(x =>
                    {
                        if (x >= 65 && x <= 90)
                        {
                            badgeTotal += x - UpperOffSet;
                        }
                        else
                        {
                            badgeTotal += x - LowerOffSet;
                        }
                    });

                    badgeFinder.Clear();
                    elfCounter = 0;
                }

                var middle = line.Length / 2;
                var firstHalf = line[..middle];
                var secondHalf = line.Substring(middle, middle);

                firstHalf.Intersect(secondHalf).ToList().ForEach(x =>
                {
                    if (x >= 65 && x <= 90)
                    {
                        total += x - UpperOffSet;
                    }
                    else
                    {
                        total += x - LowerOffSet;
                    }
                });

            }

            Console.WriteLine($"{GetType().Name}: {Title} -- Total score: {total}, Total score part two: {badgeTotal}");
        }
    }
}
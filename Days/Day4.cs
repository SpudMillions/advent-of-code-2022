using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day4: DayBase
    {
        public Day4() : base(4, 2022, "Camp Cleanup")
        {
        }

        public override void Play()
        {
            var input = Input;

            var totalOverlappingCompletely = 0;
            var totalAnyOverlap = 0;
            
            List<int> firstSectionCleaning = new List<int>();
            List<int> secondSectionCleaning = new List<int>();

            foreach (var line in input)
            {
                var sections = line.Split(',');
                var firstSectionStart = int.Parse(sections[0].Split('-')[0]);
                var firstSectionEnd = int.Parse( sections[0].Split('-')[1]);
                var secondSectionStart = int.Parse(sections[1].Split('-')[0]);
                var secondSectionEnd = int.Parse(sections[1].Split('-')[1]);
                
                firstSectionCleaning.AddRange(Enumerable.Range(firstSectionStart, firstSectionEnd - firstSectionStart + 1));
                secondSectionCleaning.AddRange(Enumerable.Range(secondSectionStart, secondSectionEnd - secondSectionStart + 1));
                
                var overlapping = firstSectionCleaning.Intersect(secondSectionCleaning).ToList();

                if(overlapping.Count > 0)
                {
                    totalAnyOverlap++;
                }

                if(overlapping.Count == firstSectionCleaning.Count || overlapping.Count == secondSectionCleaning.Count)
                {
                    totalOverlappingCompletely++;
                }         
                
                firstSectionCleaning.Clear();
                secondSectionCleaning.Clear();
            }

            Console.WriteLine($"{GetType().Name}: {Title} -- Total overlapping completely: {totalOverlappingCompletely}, Total any overlap: {totalAnyOverlap}");
        }
    }
}
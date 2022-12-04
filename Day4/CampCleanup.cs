using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    class CampCleanup
    {
        internal void Play()
        {
            var input = InputLoader.LoadData("day4.txt", "4");

            var totalOverlappingCompletely = 0;
            var totalAnyOverlap = 0;

            foreach (var line in input)
            {
                var sections = line.Split(',');
                var firstSection = sections[0];
                var secondSection = sections[1];
                var firstSectionStart = int.Parse(firstSection.Split('-')[0]);
                var firstSectionEnd = int.Parse(firstSection.Split('-')[1]);
                var secondSectionStart = int.Parse(secondSection.Split('-')[0]);
                var secondSectionEnd = int.Parse(secondSection.Split('-')[1]);
            

                List<int> firstSectionCleaning = new List<int>();
                List<int> secondSectionCleaning = new List<int>();
                firstSectionCleaning.AddRange(Enumerable.Range(firstSectionStart, firstSectionEnd - firstSectionStart + 1));
                secondSectionCleaning.AddRange(Enumerable.Range(secondSectionStart, secondSectionEnd - secondSectionStart + 1));
                
                var overlapping = firstSectionCleaning.Intersect(secondSectionCleaning).ToList();

                if(overlapping.Count > 0)
                {
                    totalAnyOverlap++;
                }

                if(overlapping.Count == firstSectionCleaning.Count() || overlapping.Count == secondSectionCleaning.Count())
                {
                    totalOverlappingCompletely++;
                }            
            }

            Console.WriteLine($"Day4: Total overlapping completely: {totalOverlappingCompletely}, Total any overlap: {totalAnyOverlap}");
        }
    }
}
//65 - 90 A-Z
//97 - 122 a-z


class RucksackReorganization 
{
      internal void Play()
    {
        const int UPPEROFFSET = 38;
        const int LOWEROFFSET = 96;
        var input = InputLoader.LoadData("day3.txt", "3");

        var total = 0;
        var badgeTotal = 0;
        var elfCounter = 0;
        var badgeFinder = new List<string>();

        foreach (var line in input)
        {
            elfCounter++;
            badgeFinder.Add(line);

            if(elfCounter == 3){
                badgeFinder[0].Intersect(badgeFinder[1]).Intersect(badgeFinder[2]).ToList().ForEach(x => {
                    if (x >= 65 && x <= 90)
                    {
                        badgeTotal += x - UPPEROFFSET;
                    }
                    else
                    {
                        badgeTotal += x - LOWEROFFSET;
                    }
                });

                badgeFinder.Clear();
                elfCounter = 0;
            }
            //split line in middle and find same character in both halves
            var middle = line.Length / 2;
            var firstHalf = line.Substring(0, middle);
            var secondHalf = line.Substring(middle, middle);

            firstHalf.Intersect(secondHalf).ToList().ForEach(x => {
                Console.WriteLine($"First half: {firstHalf}, Second half: {secondHalf}, Character: {x}");
                if (x >= 65 && x <= 90)
                {
                    total += x - UPPEROFFSET;
                }
                else
                {
                    total += x - LOWEROFFSET;
                }
            });
            
        }
                Console.WriteLine($"Day3: Total score: {total}, Total score part two: {badgeTotal}");
    }
}
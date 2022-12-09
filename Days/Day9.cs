using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using AdventOfCode.Common;

namespace AdventOfCode.Days
{
    public class Day9 : DayBase
    {
        internal Day9() : base(9, 2022, "Rope Bridge")
        {
        }

        public override void Play()
        {
            var input = Input;
            var visitedPositions = new HashSet<(int, int)>();
            var visitedPositionsForKnots = new HashSet<(int, int)>();
            
            var headPosition = (0, 0);
            var tailPosition = (0, 0);
            var knots = new[] {
                (0, 0),
                (0, 0),
                (0, 0),
                (0, 0),
                (0, 0),
                (0, 0),
                (0, 0),
                (0, 0),
                (0, 0),
            };
            
            foreach (var line in input)
            {
                var direction = line[0];
                var distance = int.Parse(line[1..]);

                for (var j = 0; j < distance; j++)
                {
                    Move(ref headPosition, direction);
                    Follow(ref tailPosition, headPosition);
                    visitedPositions.Add(tailPosition);
                }
            }
            
            //reset for part 2
            headPosition = (0, 0);

            foreach (var line in input)
            {
                var direction = line[0];
                var distance = int.Parse(line[1..]);

                for (var j = 0; j < distance; j++)
                {
                    Move(ref headPosition, direction);
                    Follow(ref knots[0], headPosition);

                    for (var k = 1; k < knots.Length; k++)
                    {
                        Follow(ref knots[k],knots[k - 1]);
                    }
                    
                    visitedPositionsForKnots.Add(knots[knots.Length - 1]);
                }
            }
            
            Console.WriteLine($"{GetType().Name} : {Title} --- Tail visited {visitedPositions.Count} positions. Knots visited {visitedPositionsForKnots.Count} positions.");
        }
        
        private static void Move(ref (int x, int y) position, char direction)
        {
            switch (direction)
            {
                case 'U':
                    position.y++;
                    break;
                case 'D':
                    position.y--;
                    break;
                case 'R':
                    position.x++;
                    break;
                case 'L':
                    position.x--;
                    break;
            }
        }
        
        private static void Follow(ref (int x, int y) tailPosition, (int x, int y) headPosition)
        {
            var (x, y) = headPosition;
            var xDiff = x - tailPosition.x;
            var yDiff = y - tailPosition.y;
            var isWithinRange = Math.Abs(xDiff) <= 1 && Math.Abs(yDiff) <= 1;
            
            if (isWithinRange) return;
            tailPosition.x += Math.Sign(xDiff);
            tailPosition.y += Math.Sign(yDiff);

        }
    }
}
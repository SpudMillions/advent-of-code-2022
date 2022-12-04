
namespace AdventOfCode.Days
{
    public static class Extensions
    {
        //string being passed in is a word or phrase
        public static Move ToMove(this string move)
        {
            switch (move)
            {
                case "X":
                case "A":
                    return Move.Rock;
                case "Y":
                case "B":
                    return Move.Paper;
                case "Z":
                case "C":
                    return Move.Scissors;
                default:
                    throw new ArgumentException($"Invalid move: {move}");
            }
        }

        public static Move ToResult(this string move)
        {
            switch (move)
            {
                case "X":
                    return Move.ElfWins;
                case "A":
                    return Move.Rock;
                case "Y":
                    return Move.Draw;
                case "B":
                    return Move.Paper;
                case "Z":
                    return Move.PlayerWins;
                case "C":
                    return Move.Scissors;
                default:
                    throw new ArgumentException($"Invalid move: {move}");
            }
        }
    }
}
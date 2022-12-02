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
}

namespace AdventOfCode.Day2
{
    public partial class RockPaperScissors
    {
        internal class RoundMoves
        {
            public RoundMoves(Move firstEntry, Move secondEntry)
            {
                SecondEntry = secondEntry;
                FirstEntry = firstEntry;
            }

            public Move SecondEntry { get; set; }
            public Move FirstEntry { get; set; }
        }

        internal class RoundResult
        {
            public RoundResult(RoundResult firstEntry, RoundResult secondEntry)
            {
                SecondEntry = secondEntry;
                FirstEntry = firstEntry;
            }

            public RoundResult SecondEntry { get; set; }
            public RoundResult FirstEntry { get; set; }
        }
    }
}
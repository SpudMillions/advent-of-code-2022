

internal partial class RockPaperScissors
{
    internal class RoundMoves
    {
        public RoundMoves(Move elfMove, Move playerMove)
        {
            PlayerMove = playerMove;
            ElfMove = elfMove;
        }

        public Move PlayerMove { get; set; }
        public Move ElfMove { get; set; }
    }
}
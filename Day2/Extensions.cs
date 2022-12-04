
using System;

namespace AdventOfCode.Day2
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
            return move switch
            {
                "X" => Move.ElfWins,
                "A" => Move.Rock,
                "Y" => Move.Draw,
                "B" => Move.Paper,
                "Z" => Move.PlayerWins,
                "C" => Move.Scissors,
                _ => throw new ArgumentException($"Invalid move: {move}")
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode.Common;

namespace AdventOfCode.Day2
{
    internal class RockPaperScissors
    {
        internal void Play()
        {
            var input = InputLoader.LoadData("day2.txt", "2");
            IEnumerable<RoundMoves> roundMoves = CreateRounds(input, EntryType.Move);
            IEnumerable<RoundMoves> roundResults = CreateRounds(input, EntryType.Result);

            var totalScore = (from roundMove in roundMoves
                let roundScore = GetScoreFromRoundResult(roundMove)
                let moveScore = GetScoreForMoveUsed(roundMove.SecondEntry)
                select (roundScore + moveScore)).Sum();

            var totalScorePartTwo = (from roundMove in roundResults
                let roundScorePartTwo = GetScoreFromRoundResultPartTwo(roundMove)
                let moveScorePartTwo = GetScoreForMoveUsedPartTwo(roundMove)
                select (roundScorePartTwo + moveScorePartTwo)).Sum();

            Console.WriteLine($"Day2: Total score: {totalScore}, Total score part two: {totalScorePartTwo}");
        }

        private int GetScoreForMoveUsedPartTwo(RoundMoves roundMove)
        {
            return roundMove.SecondEntry switch
            {
                Move.ElfWins when roundMove.FirstEntry == Move.Rock => 3,
                Move.ElfWins when roundMove.FirstEntry == Move.Paper => 1,
                Move.ElfWins when roundMove.FirstEntry == Move.Scissors => 2,
                Move.Draw when roundMove.FirstEntry == Move.Rock => 1,
                Move.Draw when roundMove.FirstEntry == Move.Paper => 2,
                Move.Draw when roundMove.FirstEntry == Move.Scissors => 3,
                Move.PlayerWins when roundMove.FirstEntry == Move.Rock => 2,
                Move.PlayerWins when roundMove.FirstEntry == Move.Paper => 3,
                Move.PlayerWins when roundMove.FirstEntry == Move.Scissors => 1,
                _ => 0
            };
        }

        private int GetScoreFromRoundResultPartTwo(RoundMoves roundMoves)
        {
            return roundMoves.SecondEntry switch
            {
                Move.PlayerWins => 6,
                Move.Draw => 3,
                _ => 0
            };
        }

        private int GetScoreFromRoundResult(RoundMoves roundMoves)
        {
            switch (roundMoves.SecondEntry)
            {
                case Move.Rock when roundMoves.FirstEntry == Move.Scissors:
                case Move.Paper when roundMoves.FirstEntry == Move.Rock:
                case Move.Scissors when roundMoves.FirstEntry == Move.Paper:
                    return 6;
                case Move.PlayerWins:
                    break;
                case Move.ElfWins:
                    break;
                case Move.Draw:
                    break;
                default:
                {
                    if (roundMoves.SecondEntry == roundMoves.FirstEntry)
                    {
                        return 3;
                    }

                    break;
                }
            }

            return 0;
        }

        private int GetScoreForMoveUsed(Move move)
        {
            return move switch
            {
                Move.Rock => 1,
                Move.Paper => 2,
                Move.Scissors => 3,
                _ => 0
            };
        }


        //load input data from file return list of pairs
        private IEnumerable<RoundMoves> CreateRounds(List<string> lines, EntryType entryType)
        {
            List<RoundMoves> moves = new List<RoundMoves>();
            
            foreach (string line in lines)
            {
                var currentRound = line.Split(' ');
                var elfMove = entryType == EntryType.Move ? currentRound[0].ToMove() : currentRound[0].ToResult();
                var playerMove = entryType == EntryType.Move ? currentRound[1].ToMove() : currentRound[1].ToResult();
                var round = new RoundMoves(elfMove, playerMove);
                moves.Add(round);
            }
            return moves;
        }
    }
}
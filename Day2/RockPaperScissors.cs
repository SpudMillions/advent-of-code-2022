// See https://aka.ms/new-console-template for more information


internal partial class RockPaperScissors
{
    public RockPaperScissors()
    {
    }

    internal void Play()
    {
        var input = InputLoader.LoadData("day2.txt", "2");
        List<RoundMoves> roundMoves = createRounds(input, EntryType.Move);
        List<RoundMoves> roundResults = createRounds(input, EntryType.Result);
        var totalScore = 0;
        var totalScorePartTwo = 0;

        foreach (var roundMove in roundMoves)
        {
            var roundScore = GetScoreFromRoundResult(roundMove);
            var moveScore = GetScoreForMoveUsed(roundMove.SecondEntry);
            var roundScorePartTwo = GetScoreFromRoundResultPartTwo(roundMove);
            var moveScorePartTwo = GetScoreForMoveUsedPartTwo(roundMove);

            totalScore += (roundScore + moveScore);
            totalScorePartTwo += (roundScorePartTwo + moveScorePartTwo);
        }

        Console.WriteLine($"Day2: Total score: {totalScore}, Total score part two: {totalScorePartTwo}");
    }

    private int GetScoreForMoveUsedPartTwo(RoundMoves roundMove)
    {
        if(roundMove.SecondEntry == Move.ElfWins){
            if(roundMove.FirstEntry == Move.Rock){
                return 3;
            }
            if(roundMove.FirstEntry == Move.Paper){
                return 1;
            }
            if(roundMove.FirstEntry == Move.Scissors){
                return 2;
            }
        }

        if(roundMove.SecondEntry == Move.Draw){
            if(roundMove.FirstEntry == Move.Rock){
                return 1;
            }
            if(roundMove.FirstEntry == Move.Paper){
                return 2;
            }
            if(roundMove.FirstEntry == Move.Scissors){
                return 3;
            }
        }

        if(roundMove.SecondEntry == Move.PlayerWins){
            if(roundMove.FirstEntry == Move.Rock){
                return 2;
            }
            if(roundMove.FirstEntry == Move.Paper){
                return 3;
            }
            if(roundMove.FirstEntry == Move.Scissors){
                return 1;
            }
        }
        return 0;
    }

    private int GetScoreFromRoundResultPartTwo(RoundMoves roundMove)
    {
        if(roundMove.SecondEntry == Move.PlayerWins){
            return 6;
        }
        if( roundMove.SecondEntry == Move.Draw){
            return 3;
        }
        return 0;
    }

    internal int GetScoreFromRoundResult(RoundMoves roundMoves){
        if(roundMoves.SecondEntry == Move.Rock && roundMoves.FirstEntry == Move.Scissors){
            return 6;
        } else if(roundMoves.SecondEntry == Move.Paper && roundMoves.FirstEntry == Move.Rock){
            return 6;
        } else if(roundMoves.SecondEntry == Move.Scissors && roundMoves.FirstEntry == Move.Paper){
            return 6;
        } else if(roundMoves.SecondEntry == roundMoves.FirstEntry){
            return 3;
        }
        return 0;
    }

    internal int GetScoreForMoveUsed(Move move){
        if(move == Move.Rock){
            return 1;
        } else if(move == Move.Paper){
            return 2;
        } else if(move == Move.Scissors){
            return 3;
        }
        return 0;
    }


    //load input data from file return list of pairs
    internal List<RoundMoves> createRounds(List<string> lines, EntryType entryType)
    {
        List<RoundMoves> moves = new List<RoundMoves>();

        //loop through the lines
        foreach (string line in lines)
        {
            //split the line into parts
            var currentRound = line.Split(' ');
            var elfMove = currentRound[0].ToMove();
            var playerMove = entryType == EntryType.Move ? currentRound[1].ToMove() : currentRound[1].ToResult();
            var round = new RoundMoves(elfMove, playerMove);
            moves.Add(round);
        }
        return moves;
    }
}
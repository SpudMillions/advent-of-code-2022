// See https://aka.ms/new-console-template for more information


internal partial class RockPaperScissors
{
    public RockPaperScissors()
    {
    }

    internal void Play()
    {
        List<RoundMoves> roundMoves = LoadData("day2.txt");
        var totalScore = 0;
        var totalScorePartTwo = 0;

        foreach (var roundMove in roundMoves)
        {
            var roundScore = GetScoreFromRoundResult(roundMove);
            var moveScore = GetScoreForMoveUsed(roundMove.PlayerMove);
            var roundScorePartTwo = GetScoreFromRoundResultPartTwo(roundMove);
            var moveScorePartTwo = GetScoreForMoveUsedPartTwo(roundMove);

            totalScore += (roundScore + moveScore);
            totalScorePartTwo += (roundScorePartTwo + moveScorePartTwo);
        }

        Console.WriteLine($"Day2: Total score: {totalScore}, Total score part two: {totalScorePartTwo}");
    }

    private int GetScoreForMoveUsedPartTwo(RoundMoves roundMove)
    {
        if(roundMove.PlayerMove == Move.Rock){
            if(roundMove.ElfMove == Move.Rock){
                return 3;
            }
            if(roundMove.ElfMove == Move.Paper){
                return 1;
            }
            if(roundMove.ElfMove == Move.Scissors){
                return 2;
            }
        }

        if(roundMove.PlayerMove == Move.Paper){
            if(roundMove.ElfMove == Move.Rock){
                return 1;
            }
            if(roundMove.ElfMove == Move.Paper){
                return 2;
            }
            if(roundMove.ElfMove == Move.Scissors){
                return 3;
            }
        }

        if(roundMove.PlayerMove == Move.Scissors){
            if(roundMove.ElfMove == Move.Rock){
                return 2;
            }
            if(roundMove.ElfMove == Move.Paper){
                return 3;
            }
            if(roundMove.ElfMove == Move.Scissors){
                return 1;
            }
        }
        return 0;
    }

    private int GetScoreFromRoundResultPartTwo(RoundMoves roundMove)
    {
        if(roundMove.PlayerMove == Move.Scissors){
            return 6;
        }
        if( roundMove.PlayerMove == Move.Paper){
            return 3;
        }
        return 0;
    }

    internal int GetScoreFromRoundResult(RoundMoves roundMoves){
        if(roundMoves.PlayerMove == Move.Rock && roundMoves.ElfMove == Move.Scissors){
            return 6;
        } else if(roundMoves.PlayerMove == Move.Paper && roundMoves.ElfMove == Move.Rock){
            return 6;
        } else if(roundMoves.PlayerMove == Move.Scissors && roundMoves.ElfMove == Move.Paper){
            return 6;
        } else if(roundMoves.PlayerMove == roundMoves.ElfMove){
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
    internal List<RoundMoves> LoadData(string fileName)
    {
        List<RoundMoves> moves = new List<RoundMoves>();
        //get the file path
        var filePath = Path.Combine(Environment.CurrentDirectory, "Day2/" + fileName);
        //read the file
        var lines = File.ReadAllLines(filePath);
        //loop through the lines
        foreach (string line in lines)
        {
            //split the line into parts
            var currentRound = line.Split(' ');
            var elfMove = currentRound[0].ToMove();
            var playerMove = currentRound[1].ToMove();
            var round = new RoundMoves(elfMove, playerMove);
            moves.Add(round);
        }
        return moves;
    }
}
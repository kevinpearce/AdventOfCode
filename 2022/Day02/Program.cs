var totalScore = 0;
var totalScorep2 = 0;

foreach (string line in File.ReadLines("./input.txt"))
{
    var myScore = Score(line[2]);
    var opponentsScore = Score(line[0]);
    var result = Result(opponentsScore, myScore);
    totalScore += myScore + result;

    var myScorep2 = Score(Decision(line));
    var resultp2 = Result(opponentsScore, myScorep2);
    totalScorep2 += myScorep2 + resultp2;
}

Console.WriteLine($"Part1 - totalScore: {totalScore}"); //13565

Console.WriteLine($"Part2 - totalScore: {totalScorep2}"); //12424

int Score (char playedHand)
{
    int result = playedHand switch  
    {  
        'A' or 'X' => 1,  
        'B' or 'Y' => 2,  
        'C' or 'Z' => 3,
        _ => 0,
    };  

    return result;
}

int Result (int opponent, int me)
{
    if (opponent == me)
    {
        return 3;
    }

    if ((me == 3 && opponent == 1) || (me == 1 && opponent == 2) || (me == 2 && opponent == 3))
    {
        return 0;
    }

    return 6;
}

char Decision (string line)
{
    if (line[2] == 'X')
    {
        char result = line[0] switch  
        {  
            'A' => 'C',  
            'B' => 'A',  
            'C' => 'B',
        };  

        return result;
    }
    
    if (line[2] == 'Y')
    {
        return line[0];
    }

    char resulte = line[0] switch  
    {  
        'A' => 'B',  
        'B' => 'C',  
        'C' => 'A',
    };  

    return resulte;
}
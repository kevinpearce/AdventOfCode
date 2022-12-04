var totalOverlappingRanges = 0;
var partialOverlapping = 0;

foreach (string line in File.ReadLines("./input.prod"))
{
    totalOverlappingRanges += RangeInRange(LineParser(line));
    partialOverlapping += PartialRangeInRange(LineParser(line));
}

Console.WriteLine($"Part 1 : {totalOverlappingRanges}"); // 657
Console.WriteLine($"Part 2 : {partialOverlapping}"); // 938

int[] LineParser (string line)
{
    var parsedLine = new int[4];
    
    var range = line.Split(',');

    var aSplit = range[0].Split('-');
    parsedLine[0] = Int32.Parse(aSplit[0]);
    parsedLine[1] = Int32.Parse(aSplit[1]);

    var bSplit = range[1].Split('-');
    parsedLine[2] = Int32.Parse(bSplit[0]);
    parsedLine[3] = Int32.Parse(bSplit[1]);

    return parsedLine;
}

int RangeInRange (int[] ranges)
{
    if (ranges[0] <= ranges[2] && ranges[1] >= ranges[3])
    {
        return 1;
    }

    if (ranges[2] <= ranges[0] && ranges[3] >= ranges[1])
    {
        return 1;
    }

    return 0;
}

int PartialRangeInRange (int[] ranges)
{
    if (ranges[0] <= ranges[2] && ranges[1] >= ranges[2])
    {
        return 1;
    }

    if (ranges[2] <= ranges[0] && ranges[3] >= ranges[0])
    {
        return 1;
    }

    return 0;
}
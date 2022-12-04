var totalOverlappingRanges = 0;
var partialOverlapping = 0;

foreach (string line in File.ReadLines("./input.prod"))
{
    totalOverlappingRanges += RangeInRange(line);
    partialOverlapping += PartialRangeInRange(line);
}

Console.WriteLine($"Part 1 : {totalOverlappingRanges}"); // 657
Console.WriteLine($"Part 2 : {partialOverlapping}"); // 938

int RangeInRange (string line)
{
    var range = line.Split(',');

    var aSplit = range[0].Split('-');
    int startA = Int32.Parse(aSplit[0]);
    int endA = Int32.Parse(aSplit[1]);

    var bSplit = range[1].Split('-');
    int startB = Int32.Parse(bSplit[0]);
    int endB = Int32.Parse(bSplit[1]);

    if (startA <= startB && endA >= endB)
    {
        return 1;
    }

    if (startB <= startA && endB >= endA)
    {
        return 1;
    }

    return 0;
}

int PartialRangeInRange (string line)
{
    var range = line.Split(',');

    var aSplit = range[0].Split('-');
    int startA = Int32.Parse(aSplit[0]);
    int endA = Int32.Parse(aSplit[1]);

    var bSplit = range[1].Split('-');
    int startB = Int32.Parse(bSplit[0]);
    int endB = Int32.Parse(bSplit[1]);

    if (startA <= startB && endA >= startB)
    {
        return 1;
    }

    if (startB <= startA && endB >= startA)
    {
        return 1;
    }

    return 0;
}
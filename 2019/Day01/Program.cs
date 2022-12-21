string[] theFile = File.ReadAllLines("./input.prod");

int sumOfFuel = 0;
int sumOfAddedFuel = 0;

foreach (string line in theFile)
{
    sumOfFuel += Calculator(Int32.Parse(line)); //part1

    Calculator(Int32.Parse(line), true); //part2
}

Console.WriteLine($"Part1 : {sumOfFuel}"); //part1 = 3399947
Console.WriteLine($"Part2 : {sumOfAddedFuel}"); //part2 = 5097039

int Calculator (int input, bool recursive = false)
{
    int result = input / 3 - 2;

    if (result > 0 && recursive)
    {
        sumOfAddedFuel += result;
        return Calculator(result, true);
    }

    return result;
}
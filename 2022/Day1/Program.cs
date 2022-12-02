using System.Linq;

var Elves = new List<int>();

var index = 0;

foreach (string line in File.ReadLines("./input.txt"))
{
    var calories = 0;
    Int32.TryParse(line, out calories);

    if (calories == 0)
    {
        index ++;
        continue;
    }

    if (Elves.Count() == index)
    {
        Elves.Add(calories);
        continue;
    }

    Elves[index] += calories;
}

Console.WriteLine($"Part 1 : {HighestCalorieTotal(Elves)}"); //71124

Console.WriteLine($"Part 2 : {HighestCalorieTotal(Elves, 3)}"); //204639

int HighestCalorieTotal(List<int> caloriesPerElf, int numberOfElves = 1)
{
    var sum = 0;
    var localList = new List<int>(caloriesPerElf);

    for (var i = 0; i < numberOfElves; i++)
    {
        sum += localList.Max();

        var maxIndex = localList.IndexOf(localList.Max());

        localList.RemoveAt(maxIndex);
    }

    return sum;
}
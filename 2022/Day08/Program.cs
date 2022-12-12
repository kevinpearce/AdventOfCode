string[] theFile = File.ReadAllLines("./input.test");

int[,] results = new int[theFile.Length, theFile[0].Length];

char currentCell = '/';

// LEFT walk
for (int y = 0; y < theFile.Length; y++)
{
    for (int x = 0; x < theFile[0].Length; x++)
    {
        CheckHeight(y, x);
    }
    currentCell = '/';
}

// RIGHT walk
for (int y = theFile.Length - 1; y >= 0; y--)
{
    for (int x = theFile[0].Length - 1; x >= 0; x--)
    {
        CheckHeight(y, x);
    }
    currentCell = '/';
}

// TOP walk 
for (int x = 0; x < theFile[0].Length; x++)
{
    for (int y = 0; y < theFile.Length; y++)
    {
        CheckHeight(y, x);
    }
    currentCell = '/';
}

// BASE walk
for (int x = theFile[0].Length - 1; x >= 0; x--)
{
    for (int y = theFile.Length - 1; y >= 0; y--)
    {
        CheckHeight(y, x);
    }
    currentCell = '/';
}

// print raw data
foreach (string line in theFile)
{
    Console.WriteLine(line);
}

// whitespace
Console.WriteLine();

// print result array
for (int i = 0; i < results.GetLength(0); i++)
{
    for (int j = 0; j < results.GetLength(1); j++)
    {
        Console.Write(results[i,j]);
    }
    Console.WriteLine();
}

// whitespace
Console.WriteLine();

int sum = results.Cast<int>().Sum();
Console.WriteLine($"Part 1 : {sum}"); // Part1: 1851

void CheckHeight (int y, int x)
{
    var height = theFile[y][x];

    if (theFile[y][x] > currentCell)
    {
        results[y, x] = 1;
        currentCell = height;
    }
}

// Part2 : the tree that can see the most zeroes???
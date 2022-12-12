string[] theFile = File.ReadAllLines("./input.test");

// index through inner trees
for (int y=1; y < theFile.Length - 1; y++)
{
    for (int x=1; x < theFile[y].Length - 1; x++)
    {
        var height = theFile[y][x];

        // Pass to check routine here?
        Console.WriteLine(height);
    }
}
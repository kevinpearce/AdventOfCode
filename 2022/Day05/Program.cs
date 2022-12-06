string[] theFile = File.ReadAllLines("./input.prod");

List<string> rawStackData = new List<string>();
List<string> instructionData = new List<string>();
List<Stack<char>> stacks = new List<Stack<char>>();

foreach (string line in theFile)
{
    if (line == string.Empty) continue;

    if (line[0] == 'm')
    {
        instructionData.Add(line);
    }
    else
    {
        rawStackData.Add(line);
    }
}

foreach (string line in Enumerable.Reverse(rawStackData).Skip(1))
{
    var stack = 0;

    for (int i = 0; i < line.Length; i += 4)
    {
        if (line[i] == '[')
        {
            if (stacks.ElementAtOrDefault(stack) == null)
            {
                stacks.Add(new Stack<char>());
            }

            stacks[stack].Push(line[i+1]);
        }
        stack ++;
    }
}

foreach (string line in instructionData)
{
    string[] separators = { "move ", " from ", " to " };

    var instruction = line.Split(separators, System.StringSplitOptions.RemoveEmptyEntries);

    var numberOfMoves = Int32.Parse(instruction[0]);
    var from = Int32.Parse(instruction[1]) - 1;
    var to = Int32.Parse(instruction[2]) - 1;

    Stack<char> tempStorage = new Stack<char>();

    for (int i = 0; i < numberOfMoves; i++)
    {
        var tempCrate = stacks[from].Pop();

        tempStorage.Push(tempCrate);
    }

    while (tempStorage.Count > 0)
    {
        stacks[to].Push(tempStorage.Pop());
    }

}

foreach (Stack<char> endStack in stacks)
{
    Console.WriteLine(endStack.Peek()); // Part1 : PTWLTDSJV, Part2 : WZMFVGGZP
}
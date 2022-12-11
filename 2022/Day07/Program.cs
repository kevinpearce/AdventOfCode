var path = "./input.prod";

List<Content> allItems = new ();
Stack<Content> currentPath = new ();
currentPath.Push(new Content("/"));

foreach (string line in File.ReadLines(path))
{
    var (first, last) = SplitLines(line);

    if (first == "$")
    {
        Command(line);
    }
    else if (first == "dir")
    {
        var tempFolder = new Content(last);
        allItems.Add(tempFolder);
        currentPath.Peek().AddChild(tempFolder);
    }
    else
    {
        var tempFile = new Content(last, first);
        currentPath.Peek().AddChild(tempFile);
    }
}

var sum = 0;

foreach (Content item in allItems)
{
    int total = item.GetSize();

    if (total <= 100000) sum += total;
}

Console.WriteLine($"Sum : {sum}"); //test 95437 : prod 1501149

// ================================

(string first, string last) SplitLines (string input)
{
    var seperated = input.Split(' ');

    return (seperated.First(), seperated.Last());
}

void Command (string line)
{
    var (first, last) = SplitLines(line);

    if (last == "/") return;

    if (last == "..")
    {
        currentPath.Pop();
        return;
    }

    if (line.Split(' ').Length > 2)
    {    
        Content? existing = currentPath.Peek().children.Where(x => x.name.Equals(last)).FirstOrDefault();

        currentPath.Push(existing);
    }
}
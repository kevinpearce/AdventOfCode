var path = "./input.prod";

List<Content> allItems = new ();
Stack<Content> currentPath = new ();
var homeDirectory = new Content("/");
currentPath.Push(homeDirectory);

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

Console.WriteLine($"Part1 : {sum}"); //test 95437 : prod 1501149

// ================================

List<Content> ordered = OrderListBySize();
int totalSize = homeDirectory.GetSize();

for (int i = 0; i < ordered.Count(); i++)
{
    int current = 0;

    if ((totalSize - ordered[i].GetSize()) < 40000000) 
    {
        Console.WriteLine(ordered[i].GetSize()); //Part2 : 10096985
        break;
    }

    current = i;
}

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

List<Content> OrderListBySize ()
{
    List<Content> sortedList = allItems.OrderBy(o => o.GetSize()).ToList();

    return sortedList;
}
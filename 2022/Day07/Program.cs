var path = "./input.prod";

HashSet<Content> items = new (); 
Stack<Content> currentPath = new ();

foreach (string line in File.ReadLines(path))
{
    var (first, last) = SplitLines(line);

    if (first == "$")
    {
        Command(line);
    }
    else if (first == "dir")
    {
        var temp = new Content(last);
        items.Add(temp);
        currentPath.Peek().AddChild(temp);
    }
    else
    {
        currentPath.Peek().AddChild(new Content(last, first));
    }
}

var sum = 0;

foreach (Content item in items)
{
    int total = item.GetSize();

    if (total <= 100000) sum += total;
}

Console.WriteLine($"Sum : {sum}"); //774902 = too low - duplicate folder names causing issues as handled as unique in hash set

// ================================

(string first, string last) SplitLines (string input)
{
    var seperated = input.Split(' ');

    return (seperated.First(), seperated.Last());
}

void Command (string line)
{
    var (first, last) = SplitLines(line);

    if (last == "..")
    {
        currentPath.Pop();
        return;
    }

    if (line.Split(' ').Length > 2)
    {    
        Content? existing = items.Where(x => x.name.Equals(last)).FirstOrDefault();

        if (existing is null)
        {
            var temp = new Content(last);
            items.Add(temp);
            currentPath.Push(temp);
        }
        else
        {
            currentPath.Push(existing);
        }
    }
}
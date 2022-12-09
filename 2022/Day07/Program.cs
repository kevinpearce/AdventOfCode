var path = "./input.test";
var position = new Stack<string>();

Dictionary<string, List<string>> folderContents = new Dictionary<string, List<string>>();
Dictionary<string, int> contentSize = new Dictionary<string, int>();

foreach (string line in File.ReadLines(path))
{
    var (first, last) = SplitLines(line);

    if (first == "$")
    {
        IssueCommmand(last);
    }
    else 
    {
        HandleContents(first, last);
    }
}

foreach (KeyValuePair<string, List<string>> entry in folderContents)
{
    Console.WriteLine(entry.Key);
}

Console.WriteLine("-------");

foreach (KeyValuePair<string, int> entry in contentSize)
{
    Console.WriteLine(entry.Key);
    Console.WriteLine(entry.Value);
}

// walk dictionary - recursive summing of contents of dirs
// look/sum other dir entries if required

// #################################################################################

(string first, string last) SplitLines (string input)
{
    var seperated = input.Split(' ');

    return (seperated.First(), seperated.Last());
}

void IssueCommmand (string command)
{
    if (command == "..")
    {
        position.Pop();
        return;
    }

    if (command != "ls") // hack: does not allow for folder named "ls"
    {
        position.Push(command);

        HandleDirectoryFromCommand();
    }
}

void HandleDirectoryFromCommand ()
{
    var test = position.Peek();

    if (!folderContents.ContainsKey(test))
    {
        folderContents.Add(test, new List<string>());
    }

    if (!contentSize.ContainsKey(test))
    {
        contentSize.Add(test, 0);
    }
}

void HandleContents (string first, string last)
{
    var currentLocation = position.Peek();
    
    folderContents[currentLocation].Add(last);

    if (first == "dir")
    {
        if (!contentSize.ContainsKey(last))
        {
            contentSize.Add(last, 0);
        }
    }
    else
    {
        if (!contentSize.ContainsKey(last))
        {
            contentSize.Add(last, Int32.Parse(first));
        }
    }
}
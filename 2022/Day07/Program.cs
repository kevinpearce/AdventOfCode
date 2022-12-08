var path = "./input.test";

// stack for holding current position
var position = new Stack<string>();

// dictionary for holding dirs
Dictionary<string, List<string>> folderContents = new Dictionary<string, List<string>>();

// parser to switch thru lines for command vs contents
foreach (string line in File.ReadLines(path))
{
    var (first, last) = SplitLines(line);

    // command
    if (first == "$")
    {
        IssueCommmand(last);
        break;
    }

    // contents
    if (first == "dir")
    {
        HandleContents(last);
    }
    else
    {
        HandleContents(first);
    }
}

foreach (KeyValuePair<string, List<string>> entry in folderContents)
{
    Console.WriteLine(entry.Key);
}

// walk dictionary - recursive summing of contents of dirs
// look/sum other dir entries if required

// line splitter, return first and last as tuple<string, string>
(string first, string last) SplitLines (string input)
{
    var seperated = input.Split(' ');

    return (seperated.First(), seperated.Last());
}

// uses stack to hold directory position state
void IssueCommmand (string command)
{
    Console.WriteLine(command);

    if (command == "..")
    {
        position.Pop();
        return;
    }

    if (command != "ls") // hack: does not allow for folder named "ls"
    {
        position.Push(command);

        // add dir to dictionary here if not already exists
        if (!folderContents.ContainsKey(command))
        {
            folderContents.Add(command, new List<string>());
        }

        return; 
    }
}

//add to list in dict
void HandleContents (string contents)
{
    if (folderContents.ContainsKey(contents))
    {
        folderContents[position.Peek()].Add(contents);
    }
}

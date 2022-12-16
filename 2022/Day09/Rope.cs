class Rope
{
    public List<Node> ropeNodes = new();

    public Rope (int nodeQty = 2)
    {
        for (int i = 0; i < nodeQty; i++)
        {
            ropeNodes.Add(new Node());
        }
    }

    public void Move (string input)
    {
        Tuple<string, int> command = ParseCommand(input);

        // TODO
        // send commands to list.First()
        // iterate through moves 1 by 1
        // cascade each update through all nodes in list
    }

    private Tuple<string, int> ParseCommand (string input)
    {
        string[] seperated = input.Split(' ');
        string direction = seperated.First();
        int numberOfMoves = Int32.Parse(seperated.Last());

        return Tuple.Create<string, int>(direction, numberOfMoves);
    }
}
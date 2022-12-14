class Rope
{
    public List<Node> ropeNodes = new();

    public Rope (int nodeQty = 2)
    {
        AddNode(nodeQty);
    }

    public void Move (string input)
    {
        Tuple<int, int> command = ParseCommand(input);

        // move in X direction
        if (command.Item2 == 0)
        {
            for (int i = 1; i <= command.Item1; i++)
            {
                // MoveHead
                ropeNodes.First().UpdatePosition(i, 0);

                // UpdateOtherNodes

            }
        }

        // move in Y direction
        // if (command.Item1 == 0)
        // {
            
        // }
    }

    private void UpdateOtherNodes ()
    {
        // WIP : needs work - swap to recursive call ??

        // walk through list of nodes
        // check rules to see if current node needs moving
        // move node if required
        // repeat until all nodes have been checked/updated
        
        for (int i = 1; i < ropeNodes.Count; i++)
        {
            int previousX = ropeNodes[i-1].GetPosition().Item1;
            int previousY = ropeNodes[i-1].GetPosition().Item2;

            int currentX = ropeNodes[i].GetPosition().Item1;
            int currentY = ropeNodes[i].GetPosition().Item2;

            // if (previousX != currentX && previousY != currentY)
            // {
            //     // move diag + which move = first
            //     ropeNodes[i].UpdatePosition(Tuple.Create<int, int>(1, 0)); //which way? +/-
            //     ropeNodes[i].UpdatePosition(Tuple.Create<int, int>(0, 1)); //which way? +/-
            // }

            if (Math.Abs(previousX - currentX) > 1)
            {   
                if (currentX - previousX < 0)
                {
                    ropeNodes[i].UpdatePosition(Tuple.Create<int, int>(-1, 0));
                    Console.WriteLine("neg");
                }
                else
                {
                    ropeNodes[i].UpdatePosition(Tuple.Create<int, int>(1, 0));
                    Console.WriteLine("pos");
                }
            }

            // if (Math.Abs(previousY - currentY) > 1)
            // {
            //     if (currentY - previousY < 0)
            //     {
            //         ropeNodes[i].UpdatePosition(Tuple.Create<int, int>(0, -1));
            //     }
            //     else
            //     {
            //         ropeNodes[i].UpdatePosition(Tuple.Create<int, int>(0, 1));
            //     }
            // }
        }
    }

    private void AddNode (int qty)
    {
        for (int i = 0; i < qty; i++)
        {
            ropeNodes.Add(new Node());
        }
    }

    private Tuple<int, int> ParseCommand (string input)
    {
        string[] seperated = input.Split(' ');
        string direction = seperated.First();
        int numberOfMoves = Int32.Parse(seperated.Last());

        return ParseDirection(direction, numberOfMoves);
    }

    private Tuple<int, int> ParseDirection (string direction, int numberOfMoves)
    {
        Tuple<int, int> output;

        output = direction switch
        {
            "L" => Tuple.Create<int, int>(-numberOfMoves, 0),
            "R" => Tuple.Create<int, int>(numberOfMoves, 0),
            "U" => Tuple.Create<int, int>(0, -numberOfMoves),
            "D" => Tuple.Create<int, int>(0, numberOfMoves)
        };

        return output;
    }
}
class Node
{
    private int positionX { get; set; }
    private int positionY { get; set; }
    private HashSet<Tuple<int, int>> uniquePositionsVisited { get; set; } = new();

    public Node ()
    {
        positionX = 0;
        positionY = 0;
        uniquePositionsVisited.Add(Tuple.Create<int, int>(positionX, positionY));
    }

    public int GetSumOfUniquePositionsVisited ()
    {
        return uniquePositionsVisited.Count;
    }

    // public void UpdatePosition (?)
    // {
    // }

    // public ? GetPosition ()
    // {
    // }
}

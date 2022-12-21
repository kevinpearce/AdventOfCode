class Node
{
    private int positionX { get; set; }
    private int positionY { get; set; }
    private HashSet<Tuple<int, int>> uniquePositionsVisited { get; set; } = new();

    public Node ()
    {
        positionX = 0;
        positionY = 0;

        UpdateUniquePositionsVisited();
    }

    public int GetSumOfUniquePositionsVisited ()
    {
        return uniquePositionsVisited.Count;
    }

    public void UpdatePosition (int xInput, int yInput)
    {
        positionX += xInput;
        positionY += yInput;

        UpdateUniquePositionsVisited();
    }

    public Tuple<int, int> GetPosition ()
    {
        return (Tuple.Create<int, int>(positionX, positionY));
    }

    private void UpdateUniquePositionsVisited ()
    {
        uniquePositionsVisited.Add(Tuple.Create<int, int>(positionX, positionY));
    }
}
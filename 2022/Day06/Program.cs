var path = "./input.prod";

GetStartPosition(path, 4); // Part1: 1287
GetStartPosition(path, 14); // Part2: 3716

void GetStartPosition (string path, int distinct)
{
    using (StreamReader reader = new StreamReader(path))
    {
        Queue<char> queue = new Queue<char>();
        int index = 0;

        while (reader.Peek() >= 0)
        {
            if (queue.Count > distinct-1) queue.Dequeue();

            queue.Enqueue((char)reader.Read());

            index++;

            if (queue.Distinct().Count() == distinct) 
            {
                Console.WriteLine($"Index : {index}");
                break;
            }
        }
    }
}
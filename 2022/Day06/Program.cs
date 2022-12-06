var path = "./input.prod";

var packetMarker = 0;
var packetMarkerReported = false;
var messageMarker = 0;
var messageMarkerReported = false;

using (StreamReader reader = new StreamReader(path))
{
    Queue<char> packetQueue = new Queue<char>();
    Queue<char> messageQueue = new Queue<char>();

    while (reader.Peek() >= 0)
    {
        if (packetQueue.Count > 3) packetQueue.Dequeue();
        if (messageQueue.Count > 13) messageQueue.Dequeue();

        var packet = (char)reader.Read();

        packetQueue.Enqueue(packet);
        messageQueue.Enqueue(packet);

        packetMarker++;
        messageMarker++;

        if (packetQueue.Distinct().Count() == 4 && packetMarkerReported == false)
        {
            Console.WriteLine(packetMarker); // Part1: 1287
            packetMarkerReported = true;
        }

        if (messageQueue.Distinct().Count() == 14 && messageMarkerReported == false)
        {
            Console.WriteLine(messageMarker); // Part2: 3716
            messageMarkerReported = true;
        }
    }
}
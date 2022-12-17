string[] input = File.ReadAllLines("./input.test");

Rope instance = new();

// foreach (string line in input)
// {
//     instance.Move(line);
// }

// Console.WriteLine(instance.ropeNodes.Last().GetSumOfUniquePositionsVisited());




// ################# testing rubbish below ########################
string test = "R 4";

instance.Move(test);

Console.WriteLine(instance.ropeNodes.First().GetSumOfUniquePositionsVisited());
Console.WriteLine(instance.ropeNodes.First().GetPosition());
Console.WriteLine(instance.ropeNodes.Last().GetPosition());
var sumTotal = 0;

var bagitems = new List<string>();
var sumTotalAcrossBags = 0;

foreach (string line in File.ReadLines("./input.txt"))
{
    var item = CommonItem(line);
    sumTotal += ItemPriority(item);

    bagitems.Add(line);

    if (bagitems.Count == 3)
    {
        var common = CommonItemAcrossBags(bagitems[0], bagitems[1], bagitems[2]);
        sumTotalAcrossBags += ItemPriority(common);
        bagitems.RemoveRange(0, 3);
    }
}

Console.WriteLine($"Part 1 : {sumTotal}"); // 7785
Console.WriteLine($"Part 2 : {sumTotalAcrossBags}"); // 2633

char CommonItem (string inputList)
{
    var index = inputList.Length/2;

    var stringOne = inputList.Substring(0, index);
    var stringTwo = inputList.Substring(index);
    var CommonList = stringOne.Intersect(stringTwo);

    return CommonList.First();
}

int ItemPriority (char inputChar)
{
    int modifier = Char.IsUpper(inputChar) ? 38 : 96;

    return Convert.ToChar(inputChar) - modifier;
}

char CommonItemAcrossBags (string bag1, string bag2, string bag3)
{
    var CommonList = (bag1.Intersect(bag2)).Intersect(bag3);

    return CommonList.First();
}
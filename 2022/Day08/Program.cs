string[] theFile = File.ReadAllLines("./input.prod");

int[,] results = new int[theFile.Length, theFile[0].Length];
int[,] treesVisibleLeft = new int[theFile.Length, theFile[0].Length];
int[,] treesVisibleRight = new int[theFile.Length, theFile[0].Length];
int[,] treesVisibleTop = new int[theFile.Length, theFile[0].Length];
int[,] treesVisibleBase = new int[theFile.Length, theFile[0].Length];
int[,] totalVisible = new int[theFile.Length, theFile[0].Length];

char currentCell = '/';
int currentCellVisibilty = 0;

// LEFT walk
for (int y = 0; y < theFile.Length; y++)
{
    for (int x = 0; x < theFile[0].Length; x++)
    {
        CheckHeight(y, x);

        //Part 2 addition
        if (!VerifyIfEdge(y, x))
        {
            CheckVisibilty(y, x);
        }
    }
    currentCell = '/';
}

// RIGHT walk
for (int y = theFile.Length - 1; y >= 0; y--)
{
    for (int x = theFile[0].Length - 1; x >= 0; x--)
    {
        CheckHeight(y, x);
    }
    currentCell = '/';
}

// TOP walk 
for (int x = 0; x < theFile[0].Length; x++)
{
    for (int y = 0; y < theFile.Length; y++)
    {
        CheckHeight(y, x);
    }
    currentCell = '/';
}

// BASE walk
for (int x = theFile[0].Length - 1; x >= 0; x--)
{
    for (int y = theFile.Length - 1; y >= 0; y--)
    {
        CheckHeight(y, x);
    }
    currentCell = '/';
}

// final tree visibilty calculator
for (int i = 0; i < treesVisibleBase.GetLength(0); i++)
{
    for (int j = 0; j < treesVisibleBase.GetLength(1); j++)
    {
        totalVisible[i,j] = treesVisibleBase[i,j] * treesVisibleLeft[i,j] * treesVisibleRight[i,j] * treesVisibleTop[i,j];
    }
}

int sum = results.Cast<int>().Sum();
Console.WriteLine($"Part 1 : {sum}"); // Part1: 1851

int max = totalVisible.Cast<int>().Max();
Console.WriteLine($"Part 2 : {max}"); // Part2: 574080

void CheckHeight (int y, int x)
{
    var height = theFile[y][x];

    if (theFile[y][x] > currentCell)
    {
        results[y, x] = 1;
        currentCell = height;
    }
}

void CheckVisibilty (int y, int x)
{
    CheckVisibiltyLeft(y, x);
    CheckVisibiltyRight(y, x);
    CheckVisibiltyTop(y, x);
    CheckVisibiltyBase(y, x);
}

void CheckVisibiltyLeft (int y, int x)
{   
    if (x > 0)
    {
        for (int i = 1; x-i >= 0; i++)
        {
            if (theFile[y][x] <= theFile[y][x-i])
            {
                currentCellVisibilty ++;
                break;
            }
            else
            {
                currentCellVisibilty ++;
            }
        }
    }

    treesVisibleLeft[y, x] += currentCellVisibilty;
    currentCellVisibilty = 0;
}

void CheckVisibiltyRight (int y, int x)
{   
    if (x < theFile[0].Length)
    {
        for (int i = 1; x+i < theFile[0].Length; i++)
        {
            if (theFile[y][x] <= theFile[y][x+i])
            {
                currentCellVisibilty ++;
                break;
            }
            else
            {
                currentCellVisibilty ++;
            }
        }
    }

    treesVisibleRight[y, x] += currentCellVisibilty;
    currentCellVisibilty = 0;
}

void CheckVisibiltyTop (int y, int x)
{   
    if (y > 0)
    {
        for (int i = 1; y-i >= 0; i++)
        {
            if (theFile[y][x] <= theFile[y-i][x])
            {
                currentCellVisibilty ++;
                break;
            }
            else
            {
                currentCellVisibilty ++;
            }
        }
    }

    treesVisibleTop[y, x] += currentCellVisibilty;
    currentCellVisibilty = 0;
}

void CheckVisibiltyBase (int y, int x)
{   
    if (y < theFile.Length)
    {
        for (int i = 1; y+i < theFile.Length; i++)
        {
            if (theFile[y][x] <= theFile[y+i][x])
            {
                currentCellVisibilty ++;
                break;
            }
            else
            {
                currentCellVisibilty ++;
            }
        }
    }

    treesVisibleBase[y, x] += currentCellVisibilty;
    currentCellVisibilty = 0;
}

bool VerifyIfEdge (int y, int x)
{
    if (
        x == 0 || x == theFile[0].Length - 1 ||
        y == 0 || y == theFile.Length - 1) 
    {
        return true;
    }

    return false;
}
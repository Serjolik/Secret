
public class Grid
{
    public int width { get; private set; }
    public int height { get; private set; }

    private (int, int) player;

    enum keys
    {
        None = 0,
        Object = 1,
        Target = 2,
        Border = 10
    };

    private keys[,] gridArray;
    
    public Grid(int width, int height)
    {
        this.width = width + 2;
        this.height = height + 2;

        gridArray = new keys[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    gridArray[x, y] = keys.Border;
                else
                    gridArray[x, y] = keys.None;
            }
        }
    }

    public void moveObject(int x, int y, int newX, int newY)
    {
        gridArray[x, y] = keys.None;
        gridArray[newX, newY] = keys.Object;
    }

    public void movePlayer((int, int) newPosition)
    {
        player.Item1 += newPosition.Item1;
        player.Item2 += newPosition.Item2;
    }

    public void SetPlayer((int, int) position)
    {
        player = position;
    }


    public int checkValue(int x, int y)
    {
        return (int)gridArray[x, y];
    }

    public int checkValueForPlayer(int x, int y)
    {
        return (int)gridArray[player.Item1 + x, player.Item2 + y];
    }

}

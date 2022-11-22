public class Exploring
{
    Player player = new();
    bool[,] map = new bool[9, 9];

//places the rooms
    public Exploring()
    {
        map[2, 3] = true;
        map[3, 3] = true;
        map[4, 3] = true;
        map[5, 3] = true;
    }

//Draws the map and where the player is
    public void DrawMap()
    {
        for (var y = 0; y < map.GetLength(1); y++)
        {
            for (var x = 0; x < map.GetLength(0); x++)
            {
                if (map[x, y] == true)
                {
                    if (player.playerX == x && player.playerY == y)
                    {
                        Console.Write("8");
                    }
                    else
                    {

                        Console.Write("0");
                    }
                }
                else
                {
                    Console.Write("#");
                }
            }
            Console.WriteLine();
        }
    }

//Checks movement and sends the player to fight 
    public void Update()
    {
        // om flyttar åt höger
        // Kolla om det finns ett rum där.
        // x++
    }
}
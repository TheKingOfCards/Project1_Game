public class Exploring
{
    Player player = new();
    GameManager gM;
    bool[,] map = new bool[8, 8];
    public bool tutorialDone = false;
    Random generator = new();


    public Exploring(GameManager gM)
    {
        this.gM = gM;

//The players y and x cords
        player.playerX = 1;
        player.playerY = 6;

//places the rooms
        map[1, 1] = true;
        map[2, 1] = true;
        map[3, 1] = true;
        map[4, 1] = true;
        map[5, 1] = true;
        map[5, 1] = true;
        map[5, 3] = true;
        map[4, 3] = true;
        map[3, 3] = true;
        map[2, 3] = true;
        map[2, 3] = true;
        map[6, 3] = true;
        map[6, 2] = true;
        map[6, 1] = true;
        map[4, 6] = true;
        map[4, 5] = true;
        map[4, 4] = true;
        map[1, 5] = true;
        map[2, 5] = true;
        map[3, 5] = true;
        map[1, 6] = true;
        map[5, 5] = true;
        map[6, 5] = true;

    }


    public void Start()
    {
        Console.WriteLine("You will now start exploring");
        Console.ReadKey();
        gM.fighting.isFighting = false;
        gM.ClearConsole();
        this.DrawMap();
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
                        Console.Write("1");
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
        
        if(tutorialDone == true)
        {
            this.Update();
        }
    }


    int monsterCountdown = 2;
    public void Update()
    {
        string text = gM.player.playerText;
        int monsterChance;

    
//Checks movement and moves the player to the right room 
        bool isMoving = true;
        while(isMoving == true)
        {
            text = Console.ReadKey().KeyChar.ToString();

            if(text.ToLower() == "w")
            {
                if(map[player.playerX,player.playerY - 1] == true)
                {
                    player.playerY--;
                    if(monsterCountdown <= 0)
                    {
                        monsterChance = generator.Next(0,4);
                        if(monsterChance == 0)
                        {
                            monsterCountdown = 2;
                            gM.currentState = GameManager.States.fighting;
                            gM.SetState();
                        }
                    }else
                    {
                        monsterCountdown--;
                    }
                    gM.ClearConsole();
                    this.DrawMap();
                }else 
                {
                    Console.WriteLine("You can't go that way");
                }
            }else if(text.ToLower() == "s")
            {
                if(map[player.playerX,player.playerY + 1] == true)
                {
                    player.playerY++;
                    if(monsterCountdown <= 0)
                    {
                        monsterChance = generator.Next(0,4);
                        if(monsterChance == 0)
                        {
                            monsterCountdown = 2;
                            gM.currentState = GameManager.States.fighting;
                            gM.SetState();
                        }
                    }else
                    {
                        monsterCountdown--;
                    }
                    gM.ClearConsole();
                    this.DrawMap();
                }else 
                {
                    Console.WriteLine("You can't go that way");
                }
            }else if(text.ToLower() == "d")
            {
                if(map[player.playerX + 1,player.playerY] == true)
                {
                    player.playerX++;
                    if(monsterCountdown <= 0)
                    {
                        monsterChance = generator.Next(0,4);
                        if(monsterChance == 0)
                        {
                            monsterCountdown = 2;
                            gM.currentState = GameManager.States.fighting;
                            gM.SetState();
                        }
                    }else
                    {
                        monsterCountdown--;
                    }
                    gM.ClearConsole();
                    this.DrawMap();
                }else 
                {
                    Console.WriteLine("You can't go that way");
                }
            }else if(text.ToLower() == "a")
            {
                if(map[player.playerX - 1,player.playerY] == true)
                {
                    player.playerX--;
                    if(monsterCountdown <= 0)
                    {
                        monsterChance = generator.Next(0,4);
                        if(monsterChance == 0)
                        {
                            monsterCountdown = 2;
                            gM.currentState = GameManager.States.fighting;
                            gM.SetState();
                        }
                    }else
                    {
                        monsterCountdown--;
                    }
                    gM.ClearConsole();
                    this.DrawMap();
                }else 
                {
                    Console.WriteLine("\nYou can't go that way");
                }
            }else if(text.ToLower() == "i")
            {
                gM.stats.Update();
            }else
            {
                Console.WriteLine("Try something else");
            }
        }
    }
}

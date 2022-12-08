public class Fighting
{
    GameManager gM;
    string[] enemyNames = {"Troll", "Human", "Vampire", "Goblin"};
    Random generator = new();
    public bool isFighting;
    bool bloodlossSuccess;


    public Fighting(GameManager gM)
    {
        this.gM = gM;
    }

    


    public void Start()
    {
        //Assign enemy name
        int i = generator.Next(enemyNames.Length);
        gM.enemy.name = enemyNames[i];
        isFighting = true;
        Console.BackgroundColor = ConsoleColor.DarkRed;


        //Creating enemy based on name
        if(gM.enemy.name == "Troll")
        {
            gM.enemy.hp = 25;
            gM.enemy.minDamage = 8;
            gM.enemy.maxDamage = 11;
            gM.enemy.troll = true;
        }else if(gM.enemy.name == "Human")
        {
            gM.enemy.hp = 10;
            gM.enemy.minDamage = 3;
            gM.enemy.maxDamage = 6;
            gM.enemy.werewolfSwitch = true;
        }else if(gM.enemy.name == "Vampire")
        {
            gM.enemy.hp = 15;
            gM.enemy.minDamage = 1;
            gM.enemy.maxDamage = 4;
            gM.enemy.bloodLoss = true;
        }else
        {
            gM.enemy.hp = 10;
            gM.enemy.minDamage = 3;
            gM.enemy.maxDamage = 5;
            gM.enemy.xpSteal = true;
        }
        

        gM.ClearConsole();
        Console.WriteLine($"\nA {gM.enemy.name} stands before you");

        if(gM.enemy.name == "Troll")
        {
            Console.WriteLine("Trolls have a lot of hp and does massive damage however it is slow so you have 2 turns before it attacks");
        }else if(gM.enemy.name == "Human")
        {
            Console.WriteLine("Just a human like you but you feel a horrible aura around him, is it just a human?");
        }else if(gM.enemy.name == "Vampire")
        {
            Console.WriteLine("You definitely don't want to get close to those fangs, being bitten by them will make you bleed and lose hp over time");
        }else
        {
            Console.WriteLine("A goblin, known for their greed, every attack it will steal some of your xp");
        } 

        Console.WriteLine("Type your action");
        this.PlayerTurn();
    }


    //Players turn
        void PlayerTurn()
        {
            string text;   
            int trollCountdown = 1;
            int missChance = generator.Next(0,100);
            int critical = generator.Next(0,100);
            int damage = generator.Next(gM.player.minDamage, gM.player.maxDamage);
            


            if(bloodlossSuccess == true)
            {
                gM.player.hp -= 2;
            }

             if(gM.player.hp <= 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    gM.currentState = GameManager.States.dead;
                    gM.SetState();
                }


    //Players action
            bool playerAction = true;
            while(playerAction == true)
            {
                gM.player.playerText = Console.ReadLine();
                text = gM.player.playerText;
                if(text.ToLower() == "attack") //Normal attack start
                {
                    if(missChance >= gM.player.normalMissChance)
                    {
                        if(critical > gM.player.critChance)
                        {
                            gM.enemy.hp -= damage * 2;
                            Console.WriteLine($"A cirtical hit! You dealt the monster {damage}");
                            playerAction = false;
                        }else{
                            gM.enemy.hp -= damage;
                            Console.WriteLine($"You dealt the monster {damage} damage");
                            playerAction = false;
                        }
                    }else
                    {
                        Console.WriteLine("You missed the monster");
                        playerAction = false;
                    }
                }else if(text.ToLower() == "heavy") //Heavy attack start
                {
                    if(missChance <= gM.player.heavyMissChance)
                    {
                        if(critical > gM.player.critChance)
                        {
                            gM.enemy.hp -= damage * 2;
                            Console.WriteLine($"A cirtical hit! You dealt the monster {damage}");
                            playerAction = false; 
                        }else
                        {
                            gM.enemy.hp -= damage; 
                            Console.WriteLine($"You dealt the monster {damage} damage");
                            playerAction = false;
                        }
                    }else
                    {
                        Console.WriteLine("You missed the monster");
                        playerAction = false;
                    }        
                }else if(text.ToLower() == "heal" && gM.player.healthpotions != 0) //Heal start
                {
                    gM.player.hp = gM.player.baseHP;
                    gM.player.healthpotions--;
                    playerAction = false;
                    Console.WriteLine("You fully healed yourself");
                }else if(text.ToLower() == "heal" && gM.player.healthpotions == 0)
                {
                    Console.WriteLine("You don't have any healthpotions left");
                }else
                {
                    Console.WriteLine("Try something else");
                }
         //Countdown if player is fighting a troll
            if(trollCountdown == 0 && gM.enemy.troll == true)
            {
                
                this.EnemyTurn();
            }else
            {
                playerAction = true;
                trollCountdown--;
                Console.ReadKey();
                gM.ClearConsole();
            }
            }

        
            if(gM.enemy.troll == false)
            {
                this.EnemyTurn();
            }
        }

    
    //Enemys turn
        void EnemyTurn()
        {
            int enemyDamage = generator.Next(gM.enemy.minDamage, gM.enemy.maxDamage);
            int enemyAbilityChance = generator.Next(0,100);


    //checks if bloodloss was succesfull and checks if player died becuase of it
            if(bloodlossSuccess == true)
            {
                gM.player.hp -= 2;

                if(gM.player.hp <= 0)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Clear();
                    gM.currentState = GameManager.States.dead;
                    gM.SetState();
                }
            }
        

    //Checks if the enemy is dead and sends the player back to exploring
            if(gM.enemy.hp <= 0)
            {
                gM.enemy.hp = 0;
                gM.ClearConsole();
                Console.BackgroundColor = ConsoleColor.Black;
                int xpGivePlayer = generator.Next(10,16);
                
                Console.WriteLine("You killed the monster");
                Console.WriteLine($"You received {xpGivePlayer} xp");
                gM.player.xp += xpGivePlayer;
                Console.ReadKey();
                gM.currentState = GameManager.States.exploring;
                gM.SetState();
            }else
            {
                Console.ReadKey();
                gM.ClearConsole();
            }


    //Checks if player is dead
            if(gM.player.hp <= 0)
            {
                Console.WriteLine("You have died");
                Console.ReadKey();
                gM.currentState = GameManager.States.dead;
                gM.SetState();
            }

    
    //Enemy damaging player and setting effect on player depending on monster
            if(gM.player.playerText == "block")
            {
                enemyDamage -= gM.player.blockAmount;
                gM.player.hp -= enemyDamage;
                Console.WriteLine($"You use your shield to block {gM.player.blockAmount} damage dealt");
                Console.WriteLine($"The monster attacked you dealing {enemyDamage}");
            }else 
            {
                gM.player.hp -= enemyDamage;
                Console.WriteLine($"The monster attacked you dealing {enemyDamage}");

                if(gM.enemy.bloodLoss == true)
                {
                
                    if(enemyAbilityChance < 20) //10% chance
                    {
                        Console.WriteLine("When the vampire attacked you he also bit you and applied the effect bloodloss");
                        Console.WriteLine("You will now lose a small amount of health every round");
                        bloodlossSuccess = true;
                    }

                }
            }


            if(gM.enemy.werewolfSwitch == true)
            {
                if(enemyAbilityChance < 10)
                {

                }
            }else if(gM.enemy.xpSteal == true) 
            {
                if(enemyAbilityChance < 20)
                {
                    Console.WriteLine("When the goblin attacks you he also stole some of your xp");
                    int xpStealAmount = generator.Next(5,11);
                    gM.player.xp -= xpStealAmount;
                }
            }
            

            Console.ReadKey();
            gM.ClearConsole();
            Console.WriteLine("\nYour turn");
            this.PlayerTurn();
        }
}
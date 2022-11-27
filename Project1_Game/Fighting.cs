public class Fighting
{
    GameManager gM;
    string[] enemyNames = {"troll", "human", "vampire", "goblin"};
    Random generator = new();


    public Fighting(GameManager gM)
    {
        this.gM = gM;
    }


    public void Start()
    {
        //Assign enemy name
        int i = generator.Next(enemyNames.Length);
        gM.enemy.name = enemyNames[i];

        //Creating enemy based on name
        if(gM.enemy.name == "troll")
        {
            gM.enemy.hp = 25;
            gM.enemy.damage = 10;
            gM.enemy.berserk = true;
        }else if(gM.enemy.name == "human")
        {
            gM.enemy.hp = 10;
            gM.enemy.damage = 5;
            gM.enemy.werewolfSwitch = true;
        }else if(gM.enemy.name == "vampire")
        {
            gM.enemy.hp = 15;
            gM.enemy.damage = 5;
            gM.enemy.bloodSuck = true;
        }else
        {
            gM.enemy.hp = 10;
            gM.enemy.damage = 5;
            gM.enemy.xpSteal = true;
        }
        
        this.Update();
    }


    public void Update()
    {
        string text = gM.player.playerText;

        Console.WriteLine($"A {gM.enemy.name} stands before you");

        if(gM.enemy.name == "troll")
        {
            Console.WriteLine("Trolls have a lot of hp and does massive damage however it is slow so you have 2 turns before it attacks");
        }else if(gM.enemy.name == "human")
        {
            Console.WriteLine("Just a human like you but you feel a horrible aura around him, is it just a human?");
        }else if(gM.enemy.name == "vampire")
        {
            Console.WriteLine("A vampire, you definitely don't want to get close to does fangs");
        }else
        {
            Console.WriteLine("A goblin, known for their greed, every attack it will steal some of your xp");
        } 

        Console.WriteLine("Type your action");

//Players turn
        void PlayerTurn()
        {
            int luck = generator.Next(0,100);
            text = Console.ReadLine();

//Players action
            if(text.ToLower() == "attack")
            {
                if(gM.player.weapon == "sword")
                {
                    if(luck <= gM.player.normalMissChance)
                    {

                    }
                }else if(gM.player.weapon == "axe")
                {
                    if(luck <= gM.player.normalMissChance)
                    {
                        
                    }
                }else{

                }
            }else if(text.ToLower() == "heavy")
            {
                if(gM.player.weapon == "sword")
                {

                }else if(gM.player.weapon == "axe")
                {

                }else{
                    
                }
            }else if(text.ToLower() == "heal")
            {

            }else if(text.ToLower() == "block")
            {

            }else
            {
                Console.WriteLine("Try something else");
            }

        }

//Enemys turn
        void EnemyTurn()
        {

        }
    }
    
}
public class Start{
    GameManager gM;
    public Start(GameManager gM){
        this.gM = gM;
    }


    public void Update(){
    //Titlescreen
    System.Console.WriteLine("Welcome to an unfinished game");
    System.Console.WriteLine("Write \"start\" too continue");
    bool startedGame = true;
    
    while(startedGame == true){
        gM.player.playerText = Console.ReadLine();
        if(gM.player.playerText.ToLower() == "start"){
            Console.Clear();
            startedGame = false;
        }else{
            System.Console.WriteLine("Try something else");
        }
    }
    

    //Name
    System.Console.WriteLine("Please enter your name");
    while(gM.player.name == "")
    {
        gM.player.name = Console.ReadLine();
        if(gM.player.name == ""){
            Console.WriteLine("Please name your character something");
        }
    }
    System.Console.WriteLine($"Hello {gM.player.name}!");
    Console.ReadKey();
    Console.Clear();


    //Weapon choosing
    System.Console.WriteLine("Choose your weapon by writing the name of it");
    System.Console.WriteLine("\nThe Axe: A heavy hitter dealing high damage but it has a change of missing \nit's target becasue of the heavy wheight. It also has a low crit chance");
    System.Console.WriteLine("\nThe Dagger: Dealing low damge but will always hit the target on a normal attack.\nIt also has a high crit chance and the crits deal more damage");
    System.Console.WriteLine("\nThe Sword: Being a middle ground of the previous weapons, it deals middle \ndamage and has a low chance of missing. It has a less crit chance then \nthe dagger but higher than the axe");
    
    bool weaponChoosing = true;
    while(weaponChoosing == true){
        gM.player.playerText = Console.ReadLine();
        
//Saveing choice and givngin the right stats depending on chosed weapon
        if(gM.player.playerText.ToLower() == "sword"){
            gM.player.weapon = "sword";
            System.Console.WriteLine("You chose the sword");
            weaponChoosing = false;
            gM.player.minDamage = 4;
            gM.player.maxDamage = 7;
            gM.player.normalMissChance = 10;
            gM.player.heavyMissChance = 20;
            gM.player.critMultiplayier = 2;
        }    
        else if(gM.player.playerText.ToLower() == "axe"){
            gM.player.weapon = "axe";
            System.Console.WriteLine("You chose the axe");
            weaponChoosing = false;
            gM.player.minDamage = 8;
            gM.player.maxDamage = 11;
            gM.player.normalMissChance = 20;
            gM.player.heavyMissChance = 40;
            gM.player.critMultiplayier = 2;
        }
        else if(gM.player.playerText.ToLower() == "dagger"){
            gM.player.weapon = "dagger";
            System.Console.WriteLine("You chose the dagger");
            weaponChoosing = false;
            gM.player.minDamage = 2;
            gM.player.maxDamage = 5;
            gM.player.normalMissChance = 0;
            gM.player.heavyMissChance = 10;
            gM.player.critMultiplayier = 3;
        }
        else{
            System.Console.WriteLine("Try something else");
        }
    }
    Tutorial();
    

    //Tutorial
    void Tutorial()
    {
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("First we start with what you can do (do not type anything just press a key when you are done reading)");
        Console.WriteLine("Write \"attack\" to attack the monster");
        Console.WriteLine("\nWrite \"heavy\" to make a heavy attack, however these have a chance to miss and cannot crit");
        Console.WriteLine("\nWrite \"block\" to use the shield");
        Console.WriteLine("\nWrite \"heal\" to use healing items (you start out with 2 healpotions that replenish every fight)");
        Console.WriteLine("\nWhen you are fighting you also have 5 stamina points, a normal attack costs 1 stamina and a heavy costs 2, blocking \ncosts none and you also restore your stamina while doing it");
        Console.ReadKey();
        Console.Clear();
        gM.exploring.DrawMap();
        Console.WriteLine("\nThis is the map");
        Console.WriteLine("1 = you\n0 = rooms\n# = no room");
        Console.WriteLine("Write \"w\" to go up, \"s\" to go down, \"a\" to go left, \"d\" to go right");
        Console.WriteLine("When you are exploring you can press \"i\" to see which stats you can upgrade (this will not work during fights)");
        Console.WriteLine("When you are exploring you might encounter diffrent monsters, kill them to keep moving forward");
    }


    //Start of game
    Console.ReadKey();
    Console.Clear();
    System.Console.WriteLine($"You are {gM.player.name}, you need to go through this dungeon and kill the boss for your village");
    System.Console.WriteLine($"You have a {gM.player.weapon}");
    System.Console.WriteLine("A shield (blocks 3 damage)");
    System.Console.WriteLine("And some armour ");
    Console.ReadKey();

    gM.currentState = GameManager.States.exploring;
    gM.exploring.tutorialDone = true;
    gM.SetState();
    }
}
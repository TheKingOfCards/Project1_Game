public class Start{
    GameManager gS;
    public Start(GameManager gS){
        this.gS = gS;
    }


    public void Update(){
    //Titlescreen
    System.Console.WriteLine("Welcome to an unfinished game");
    System.Console.WriteLine("Write start too continue");
    bool startedGame = true;
    
    while(startedGame == true){
        gS.player.playerText = Console.ReadLine();
        if(gS.player.playerText.ToLower() == "start"){
            Console.Clear();
            startedGame = false;
        }else{
            System.Console.WriteLine("Try something else");
        }
    }
    

    //Name
    System.Console.WriteLine("Please enter your name");
    gS.player.name = Console.ReadLine();
    System.Console.WriteLine($"Hello {gS.player.name}!");
    Console.ReadKey();
    Console.Clear();


    //Weapon choosing
    System.Console.WriteLine("Choose your weapon by writing the name of it");
    System.Console.WriteLine("\nThe Axe: A heavy hitter dealing 10 damage but it has a change of missing \nit's target becasue of the heavy wheight. It also has a low crit chance");
    System.Console.WriteLine("\nThe Dagger: Only dealing 3 damge a hit but will alwas hit the target.\nIt also has a high crit chance and the crits deal more damge");
    System.Console.WriteLine("\nThe Sword: Being a middle ground of the previous weapons, it deals 5 \ndamage and will always hit the target. It has a less crit chance then \nthe dagger but higher than the axe");
    
    bool weaponChoosing = true;
    while(weaponChoosing == true){
        gS.player.playerText = Console.ReadLine();
        
        if(gS.player.playerText.ToLower() == "sword"){
            gS.player.weapon = "sword";
            System.Console.WriteLine("You chose the sword");
            weaponChoosing = false;
            gS.player.critAmount = 2;
        }    
        else if(gS.player.playerText.ToLower() == "axe"){
            gS.player.weapon = "axe";
            System.Console.WriteLine("You chose the axe");
            weaponChoosing = false;
            gS.player.critAmount = 1.5f;
        }
        else if(gS.player.playerText.ToLower() == "dagger"){
            gS.player.weapon = "dagger";
            System.Console.WriteLine("You chose the dagger");
            weaponChoosing = false;
            gS.player.critAmount = 3;
        }
        else{
            System.Console.WriteLine("Try something else");
        }
    }
    

    //Start of game
    Console.ReadKey();
    Console.Clear();
    System.Console.WriteLine($"You are {gS.player.name}, you need to go through this dungeon and kill the boss for your village");
    System.Console.WriteLine($"You have a {gS.player.weapon}");
    System.Console.WriteLine("A shield (blocks 3 damage)");
    System.Console.WriteLine("And some armour ");
    Console.ReadKey();
    Tutorial();
    }


    public void Tutorial(){
        Console.WriteLine("Tutorial start");
    }


}
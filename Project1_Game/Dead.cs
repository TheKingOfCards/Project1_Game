public class Dead{

    GameManager gM;


    public Dead(GameManager gM)
    {
        this.gM = gM;
    }

    public void Update(){
        Console.WriteLine("You have died");
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine("Thanks for playing unfinished game");
        Console.ReadKey();
        Environment.Exit(0);
    }
}
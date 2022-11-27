public class GameManager{
//Creates an instance of every class
    public Player player = new();
    public Enemy enemy = new();
    public Fighting fighting;
    public Exploring exploring;
    public Start start;
    public Dead dead = new();
    public States currentState = States.start;

    public GameManager()
    {
        start = new(this);
        fighting = new(this);
        exploring = new(this);
    }


//Sends the player to the correct state depending on the variebal currentstate
    public void SetState()
    {
        while(1!=2)
        {
        if(currentState == States.start)
        {
            start.Update();
        }else if(currentState == States.exploring)
        {
            exploring.Start();
        }else if(currentState == States.fighting)
        {
            fighting.Start();
        }else
        {
            dead.Update(); 
        }
        }   
    }


//Clears the console and shows the stats of player and enemy (enemy only shows while in fight)
    public void ClearConsole()
    {
        Console.Clear();
    }


//The diffrent states the player can be in
    public enum States
    {
    dead, exploring, fighting, start
    }

}
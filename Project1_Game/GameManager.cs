public class GameManager{
//Creates an instance of every class
    public Player player = new();
    public Fighting fighting = new();
    public Exploring exploring = new();
    public Start start = new();
    public Dead dead = new();
    public States currentState = States.start;
    

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
            exploring.Update();
        }else if(currentState == States.fighting)
        {
            fighting.Update();
        }else
        {
            dead.Update(); 
        }
        }   
    }

//The diffrent states the player can be in
    public enum States
    {
    dead, exploring, fighting, start
    }

}
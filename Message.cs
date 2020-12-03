public class Message
{    
    // Properties 
    private string _name;
    public string Name 
    {
        get 
        { 
            return this._name; 
        } 
        set 
        { 
            this._name = value; 
        } 
    }
    
    private string _msg;
    public string Msg 
    { 
        get 
        { 
            return this._msg; 
        } 
        set 
        { 
            this._msg = value; 
        } 
    }

    // public Message(string name, string message)
    // {
    //     Name = name;
    //     Msg = message;
    // }
}

using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Utilities;



public class Guestbook
{
    public static List<Message> _messages = new List<Message>();

    public static void GetMessages()
    {
        string json;

        json = File.ReadAllText("guestbook.json");
        
        _messages = JsonSerializer.Deserialize<List<Message>>(json);
        
        foreach (var message in _messages){
            WriteLine("[{0}] {1, -15} {2}", _messages.IndexOf(message), message.Name, message.Msg);
        }
    }



    public static void CreateMessage()
    {
        string name;
        string message;

        Clear();

        do {
            Clear();
            WriteLine("Name");
            name = ReadLine();
        } while (!IsValidString(name));

        do {
            Clear();
            WriteLine($"Name\n{name}");
            WriteLine("Message");
            message = ReadLine();
        } while (!IsValidString(message));
        
        _messages.Add(new Message() 
        { 
            Name = name, 
            Msg = message 
        });

        JsonSerializeMessages(_messages);
    }



    public static void DeleteMessage()
    {
        char key;
        int messageCount = _messages.Count;

        if (messageCount > 0)
        {
            do
            {
                Clear();
                WriteLine("Delete Message By Index");
                WriteLine($"\nProvide a number between 0 - {messageCount-1}\n");
                GetMessages();
                key = ReadKey().KeyChar;
            } while(!IsValidInt(key, messageCount));

            _messages.RemoveAt(Int16.Parse(key.ToString()));
            JsonSerializeMessages(_messages); 
        }
    }
}

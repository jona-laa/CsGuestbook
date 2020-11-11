using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static Utilities;
using System.Threading;
using static Program;




public class Guestbook
{
    public static List<Message> _messages = new List<Message>();

    public static void GetMessages()
    {
        string json;

        // Read JSON File
        json = File.ReadAllText("guestbook.json");
        
        // Deserialize into List and Print to Console
        _messages = JsonSerializer.Deserialize<List<Message>>(json);

        if (_messages.Count > 0)
        {
            foreach (var message in _messages){
                WriteLine("[{0}] {1, -15} {2}", _messages.IndexOf(message), message.Name, message.Msg);
            }
        }
        else {
            WriteLine("Guestbook is Empty");
        }
    }



    public static void CreateMessage()
    {
        string name;
        string message;

        Clear();

        // Ask for name and message input until valid
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
        
        // Create instance of Message
        _messages.Add(new Message() 
        { 
            Name = name, 
            Msg = message 
        });

        // Serializes and Writes to file
        SerializeAndWrite(_messages);

        WriteLine("\nMessage Created");
        Thread.Sleep(1000); 
    }



    public static void DeleteMessage()
    {
        char key;
        int messageCount = _messages.Count;

        // Ask for input until valid
        if (messageCount > 0)
        {
            do
            {
                Clear();

                WriteLine("Delete Message By Index");
                WriteLine($"Provide a number between 0 - {messageCount-1}\n");

                GetMessages();

                WriteLine("\nC. Cancel\n");

                key = ReadKey().KeyChar;
            } while(!IsValidInt(key, messageCount));

            // If input key was C, Cancel, else delete chosen index
            if(key.ToString().ToUpper() == "C")
            {                
                MenuChoice();
            } 
            else {
                _messages.RemoveAt(Int16.Parse(key.ToString()));

                SerializeAndWrite(_messages);

                WriteLine("\n\nMessage Deleted");
                Thread.Sleep(1000); 
            }
        }
    }
}

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
    public static List<Message> Messages { get; set; }

    public Guestbook()
    {
        Messages = new List<Message>();
    }

    public static void GetMessages()
    {
        string json;

        // Read JSON File
        json = File.ReadAllText("guestbook.json");
        
        // Deserialize into List and Print to Console
        Messages = JsonSerializer.Deserialize<List<Message>>(json);

        if (Messages.Count > 0)
        {
            foreach (var message in Messages){
                WriteLine("[{0}] {1, -15} {2}", Messages.IndexOf(message), message.Name, message.Msg);
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
        Messages.Add(new Message() 
        { 
            Name = name, 
            Msg = message 
        });

        // Serializes and Writes to file
        SerializeAndWrite(Messages);

        WriteLine("\nMessage Created");
        Thread.Sleep(1000); 
    }



    public static void DeleteMessage()
    {
        char key;
        int messageCount = Messages.Count;

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
                Messages.RemoveAt(Int16.Parse(key.ToString()));

                SerializeAndWrite(Messages);

                WriteLine("\n\nDeleting message...");
                Thread.Sleep(1000); 
            }
        }
    }
}

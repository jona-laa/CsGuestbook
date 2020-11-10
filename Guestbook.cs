using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

using System.Text.Json.Serialization;


public class Guestbook
{
    public static List<Message> _messages = new List<Message>();

    // Get messages
    public static void GetMessages()
    {
        // 1. Read File Content to vaiable
        var json = File.ReadAllText("guestbook.json");
        
        // 2. Deserialize JSON -> Store in _messages
        _messages = JsonSerializer.Deserialize<List<Message>>(json);
        
        // 3. Read each message [index] - Message with loop
        foreach (var message in _messages){
            WriteLine("[{0}] {1, -15} {2}", _messages.IndexOf(message), message.Name, message.Msg);
        }
    }

    // Write message
    public static void CreateMessage()
    {
        Clear();

        //1. Create Message
        WriteLine("Name?");
        var name = ReadLine();

        WriteLine("Message");
        var message = ReadLine();

        // 2. Check for empty input

        // 3. Get and deserialize JSON to Object in _messages?? Might not be necessary
        
        // 4. Add New message to List
        _messages.Add(new Message() 
        { 
            Name = name, 
            Msg = message 
        });

        // 5. Serialize to JSON
        string json = JsonSerializer.Serialize(_messages);

        // 6. Write JSON to file
        File.WriteAllText("guestbook.json", json);
    }

    // Delete message
    public static void DeleteMessage()
    {
        Clear();
        WriteLine("Delete Message By Index\n");
        GetMessages();


        // 1. Get index to delete
        // var key = Int16.Parse(ReadKey().KeyChar.ToString());
        var key = ReadKey().KeyChar;

        Int16 result;
        var messageCount = _messages.Count;
        string json;

        // 2. Validate?
        if (Int16.TryParse(key.ToString(), out result))
        {
            if (result >= 0 && result < messageCount)
            {
                // 3. Delete index from _messages
                _messages.RemoveAt(result);

                // 4. Serialize to JSON
                json = JsonSerializer.Serialize(_messages);

                // 5. Write JSON to file
                File.WriteAllText("guestbook.json", json);
            }
            else
            {
                WriteLine($"\n{result} is not within the range, my man");
                ReadLine();
            }
        }

    }
}

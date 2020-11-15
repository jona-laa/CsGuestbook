using System;
using static System.Console;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Utilities
{
    /// <summary>
    /// Makes sure Message strings are not empty
    /// </summary>
    public static bool IsValidString(string str)
    {
        return (string.IsNullOrEmpty(str) | String.IsNullOrWhiteSpace(str))  ? false : true;
    }



    /// <summary>
    /// Serializes and Writes Messages to json-file 
    /// </summary>
    public static void SerializeAndWrite(List<Message> _messages)
    {
        try
        {
            using(var sr = new StreamWriter(@"guestbook.json"))
            {
                string json = JsonSerializer.Serialize(_messages);
                sr.Write(json);
            }
        }
        catch
        {
            WriteLine("Could not save message...");
        }
    }



    /// <summary>
    /// Checks for valid integer, or C, when in Delete menu
    /// </summary>
    public static bool IsValidInt(char key, int messageCount)
    {
        Int16 inputNumber;
        if (Int16.TryParse(key.ToString(), out inputNumber))
        {
            return (inputNumber >= 0 && inputNumber < messageCount) ? true : false;
        }
        else if (key.ToString().ToUpper() == "C")
        {
            return true;
        }
        else {
            return false;
        }
    }
}

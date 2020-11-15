using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Utilities
{
    /// Makes sure Message strings are not empty
    public static bool IsValidString(string str)
    {
        return (str == null | str == "")  ? false : true;
    }



    /// Serializes and Writes Messages to json-file 
    public static void SerializeAndWrite(List<Message> _messages)
    {
        string json;

        json = JsonSerializer.Serialize(_messages);
        File.WriteAllText("guestbook.json", json); 
    }



    // Checks for valid integer, or C, when in Delete menu
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

using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public class Utilities
{
    /// Makes sure Message strings are not empty
    public static bool IsValidString(string str)
    {
        if (str == null | str == "")
        {
            return false;
        }
        return true;
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
            if (inputNumber >= 0 && inputNumber < messageCount)
            {
                return true;
            }
            else
            {
                return false;
            }
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

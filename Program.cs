﻿/* Written by Jonathan Laasonen */

using System;
using System.Threading;
using static System.Console;

class Program
{
    static ConsoleKeyInfo pressedKey;

    static void Main(string[] args)
    {
        ForegroundColor = ConsoleColor.DarkGreen;
        
        while(true) {
            MenuChoice();
        };
    }



    /// <summary>
    /// Runs the application menu
    /// </summary>
    public static void MenuChoice()
    {
        Clear();
        // Print Menu Choices
        WriteLine("C O N S O L E  G U E S T B O O K\n");
        WriteLine("# MENU");
        WriteLine("1. Write Message");
        WriteLine("2. Delete Message");
        WriteLine("Q. Quit\n");

        // Get Messages
        WriteLine("# MESSAGES");
        Guestbook.GetMessages();
        
        // Ask for user input
        pressedKey = ReadKey();

        // Run cases depending on input
        switch(pressedKey.Key)
        {
            case ConsoleKey.D1:
                Guestbook.CreateMessage();
                break;

            case ConsoleKey.D2:
                Guestbook.DeleteMessage();
                break;

            case ConsoleKey.Q:
                Clear();
                WriteLine("\nQuitting... \nHave a nice day!"); 
                Thread.Sleep(1000);
                Console.ResetColor();
                Environment.Exit(0);
                break;

            default:
                break;
        }
    }    
}

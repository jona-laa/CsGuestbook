using System;
using System.Threading;
using static System.Console;

class Program
{
    public static ConsoleKeyInfo pressedKey;

    static void Main(string[] args)
    {
        do {
            MenuChoice();

            // Get Messages
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

                case ConsoleKey.X:
                    WriteLine("\nQuitting..."); 
                    Thread.Sleep(1000);
                    Environment.Exit(0);
                    break;
            }
        } while (pressedKey.Key != ConsoleKey.X);
    }

    public static void MenuChoice()
    {
        Clear();

        WriteLine("C O N S O L E  G U E S T B O O K\n");
        WriteLine("1. Write Message");
        WriteLine("2. Delete Message");
        WriteLine("\nX. Quit\n");
    }    
}

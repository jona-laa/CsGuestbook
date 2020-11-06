using System;
using static Menu;

namespace Guestbook
{
    class Program
    {
        static void Main(string[] args)
        {
            

            MenuChoice();

            while(!ValidateChoice()) {
                MenuChoice();
            }

            System.Console.WriteLine("Valid input!");
        }
    }
}

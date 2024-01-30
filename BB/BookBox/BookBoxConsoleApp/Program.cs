using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBoxConsoleApp.View;

namespace BookBoxConsoleApp
{
    internal class Program
    { 

        static void Main(string[] args)
        {
            Information();
            Screen screen = new Screen();
        }
        static void Information()
        {
            Console.WriteLine(new string('-', 95));
            Console.WriteLine(new string(' ', 5) + "oooooooooo                          oooo        oooooooooo                          " + new string(' ', 5));
            Console.WriteLine(new string(' ', 5) + " 888    888   ooooooo     ooooooo    888  ooooo  888    888   ooooooo   oooo   oooo " + new string(' ', 5));
            Console.WriteLine(new string(' ', 5) + " 888oooo88  888     888 888     888  888o888     888oooo88  888     888   888o888   " + new string(' ', 5));
            Console.WriteLine(new string(' ', 5) + " 888    888 888     888 888     888  8888 88o    888    888 888     888   o88 88o   " + new string(' ', 5));
            Console.WriteLine(new string(' ', 5) + "o888ooo888    88ooo88     88ooo88   o888o o888o o888ooo888    88ooo88   o88o   o88o " + new string(' ', 5));
            Console.WriteLine();
            Console.WriteLine(new string(' ', 45) + "BookBox" + new string(' ', 45));
            Console.WriteLine(new string(' ', 30) + "Created by Mihael, Plamen and Dimitrina" + new string(' ', 30));
            Console.WriteLine(new string('-', 95));
            Console.WriteLine("Press a random key...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}

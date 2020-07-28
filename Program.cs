using Blackjack.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            var playerName = Console.ReadLine();
            var game = new Game();
            game.StartGame(playerName);
        }
    }
}

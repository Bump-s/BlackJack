using System;
using System.Dynamic;
using System.Reflection.Metadata.Ecma335;

namespace Blackjack
{
    class Game
    {
        private Player FirstHand(String name, Deck deck)
        {
            var player = new Player(name);
            while (player.Hand.Count - 1 < 1)
            {
                player.AddCard(deck.GetCard());
                player.CountValue();
                Console.WriteLine($"{player.Name} got a {player.Hand[player.Hand.Count - 1].Value} of {player.Hand[player.Hand.Count - 1].Suit}");
            }
            return player;
        }

        private void PlayerGetCard(Player player, Deck deck)
        {
            player.AddCard(deck.GetCard());
            player.CountValue();
            Console.WriteLine($"{player.Name} got a {player.Hand[player.Hand.Count - 1].Value} of {player.Hand[player.Hand.Count - 1].Suit}");
        }

        private void SimulateGame(Player player1, Player player2, Deck deck)
        {
            var blackJack = 21;
            while (player1.Value <= blackJack && player2.Value <= blackJack)
            {
                if (player1.Value < blackJack && player2.Value <= blackJack)
                {
                    PlayerGetCard(player1, deck);
                }
                if (player2.Value < blackJack && player1.Value <= blackJack)
                {
                    PlayerGetCard(player2, deck);
                }
                if (player1.Value == blackJack && player2.Value == blackJack)
                {
                    break;
                }
            }
        }

        private void SG(Player player1, Player player2, Deck deck)
        {
            var blackJack = 21;
            var checkKey = "y";
            while (player1.Value <= blackJack && player2.Value <= blackJack)
            {
                if (string.Equals(checkKey, "y", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("One more card?\n'Y' - yes 'N' - no");
                    var key = Console.ReadLine();
                    checkKey = key;
                }
                if (string.Equals(checkKey, "y", StringComparison.InvariantCultureIgnoreCase) && (player1.Value < blackJack && player2.Value <= blackJack))
                {
                    PlayerGetCard(player1, deck);
                }
                if (player2.Value < blackJack && player1.Value <= blackJack)
                {
                    PlayerGetCard(player2, deck);
                }
                if (player1.Value == blackJack && player2.Value == blackJack)
                {
                    break;
                }
            }
        }

        private void CountWhoWin(Player player1, Player player2)
        {
            var blackJack = 21;
            int selection = 0;
            if (player1.Value > blackJack && player2.Value <= blackJack)
            {
                selection = 1;
            }
            if (player1.Value <= blackJack && player2.Value > blackJack)
            {
                selection = 2;
            }
            switch (selection)
            {
                case (1):
                    Console.WriteLine($"Winner's {player2.Name} with {player2.Value} points");
                    break;
                case (2):
                    Console.WriteLine($"Winner's {player1.Name} with {player1.Value} points");
                    break;
                default:
                    Console.WriteLine($"Draw, all of players got {player1.Value}");
                    break;
            }
        }

        public void StartGame()
        {
            Console.WriteLine("Select the game mode\n'1' for Bot vs Bot '2' for Player vs Bot");
            var mode = Console.ReadLine();
            var deck = new Deck();
            var player1 = new Player("Bot Blak");
            var player2 = new Player("Bot Jack");
            switch (int.Parse(mode))
            {
                case (1):
                    player1 = FirstHand("Bot Black", deck);
                    player2 = FirstHand("Bot Jack", deck);
                    SimulateGame(player1, player2, deck);
                    CountWhoWin(player1, player2);
                    Console.WriteLine("Y - to New game \nN - to Exit");
                    var key = Console.ReadLine();

                    if (string.Equals(key, "y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        StartGame();
                    }
                    break;

                case (2):
                    Console.WriteLine("Enter your name");
                    var name = Console.ReadLine();
                    player1 = FirstHand(name, deck);
                    player2 = FirstHand("Bot Jack", deck);
                    SG(player1, player2, deck);
                    CountWhoWin(player1, player2);
                    Console.WriteLine("Y - to New game \nN - to Exit");
                    key = Console.ReadLine();

                    if (string.Equals(key, "y", StringComparison.InvariantCultureIgnoreCase))
                    {
                        StartGame();
                    }
                    break;

                default:
                    Console.WriteLine("Wrong game mode. Try again.");
                    StartGame();
                    break;
            }
        }
    }
}

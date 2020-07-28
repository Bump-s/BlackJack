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

        private void SimulateGameBotVSBot(Player player1, Player player2, Deck deck)
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

        private void SimulateGamePlayerVSBot(Player player1, Player player2, Deck deck)
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

        private void GameModeBotVSBot(Deck deck, string playerName)
        {
            var player1 = FirstHand("Bot Black", deck);
            var player2 = FirstHand("Bot Jack", deck);
            SimulateGameBotVSBot(player1, player2, deck);
            CountWhoWin(player1, player2);
            RestartGame(playerName);
        }

        private void GameModePlayerVSBot(Deck deck, string playerName)
        {
            
            var player1 = FirstHand(playerName, deck);
            var player2 = FirstHand("Bot Jack", deck);
            SimulateGamePlayerVSBot(player1, player2, deck);
            CountWhoWin(player1, player2);
            RestartGame(playerName);
        }

        private void RestartGame(string playerName)
        {
            Console.WriteLine("Y - to New game \nN - to Exit");
            var key = Console.ReadLine();

            if (string.Equals(key, "y", StringComparison.InvariantCultureIgnoreCase))
            {
                StartGame(playerName);
            }
        }
        public void StartGame(string playerName)
        {
            Console.WriteLine("Select the game mode\n'1' for Bot vs Bot '2' for Player vs Bot");
            var mode = Console.ReadLine();
            var deck = new Deck();
            if (int.Parse(mode) == 1)
            {
                GameModeBotVSBot(deck, playerName);
            }
            if (int.Parse(mode) == 2)
            {
                GameModePlayerVSBot(deck, playerName);
            }
            if (int.Parse(mode) != 1 && int.Parse(mode) != 2)
            {
                Console.WriteLine("Wrong game mode. Try again.");
                StartGame(playerName);
            }
        }
    }
}

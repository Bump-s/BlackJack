using Blackjack.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blackjack
{
	class Game
	{
		private Player FirstHand(String name, Deck deck)
        {
			var player = new Player(name);
            while (player.Hand.Count -1  < 1)
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
			while ((player1.Value <= 21 && player2.Value <= 21))
			{
				if ((player1.Value < 21 && player2.Value <= 21) && player2.Value <= 21)
				{
					PlayerGetCard(player1, deck);
				}
				if ((player2.Value < 21 && player1.Value <= 21) && player1.Value <= 21)
				{
					PlayerGetCard(player2, deck);
				}
				if (player1.Value == 21 && player2.Value == 21)
				{
					break;
				}
			}
		}
		private void CountWhoWin(Player player1, Player player2)
		{
			int selection = 0;
			if (player1.Value > 21 && player2.Value <= 21)
			{
				selection = 1;
			}
			if (player1.Value <= 21 && player2.Value > 21)
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
		private String BlackJackGame(String key)
		{
			var deck = new Deck();
			deck.GenerateDeck();
			deck.ShuffleDeck();
			bool stop = true;
			if (key == "n" || key == "N")
			{
				stop = false;
			}
			while (stop)
			{
				var player1 = FirstHand("Player1", deck);
                var player2 = FirstHand("Player2", deck);
				SimulateGame(player1, player2, deck);
                stop = false;
				if (!stop)
				{
					CountWhoWin(player1, player2);
				}
				Console.WriteLine("Y - to New game \nn - to Exit");
				key = Console.ReadLine();
			}
			return key;
		}
		public void StartGame()
		{
			string key = "";

			while (key != "n" || key != "N")
			{
				 key = BlackJackGame(key);
			}
		}
	}
}

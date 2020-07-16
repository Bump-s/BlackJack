using Blackjack.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Blackjack
{
	class Game
	{
		private List<Card> GenerateDeck(List<Card> deck)
		{
			for (int numberOfValue = 2; numberOfValue < 15; numberOfValue++)
			{
				for (int numberOfSuit = 0; numberOfSuit < 4; numberOfSuit++)
				{
					Card card = new Card();
					card.Value = (Value)numberOfValue;
					card.Suit = (Suit)numberOfSuit;
					deck.Add(card);
				}
			}
			return deck;
		}
		private void ShuffleDeck(List<Card> deck)
		{
			Random random = new Random();
			for (int i = deck.Count() - 1; i >= 1; i--)
			{
				int j = random.Next(i + 1);
				var temp = deck[j];
				deck[j] = deck[i];
				deck[i] = temp;
			}
		}
		private Card GetCard(List<Card> deck)
		{
			Card container = new Card();
			ShuffleDeck(deck);
			container = deck[0];
			deck.RemoveAt(0);
			return container;
		}
		private Player PlayerGetCard(String name)
		{
			var player = new Player(name);
			var deck = new List<Card>();
			GenerateDeck(deck);
			while (player.Value < 21)
			{
				player.AddCard(GetCard(deck));
				player.CountValue();
				Console.WriteLine($"{player.Name} got a {player.Hand[player.Hand.Count - 1].Value} of {player.Hand[player.Hand.Count - 1].Suit}");
			}
			return player;
		}
		private void CountWhoWin(Player player1, Player player2)
		{
			int selection = 0;
			int winner = player1.Value - player2.Value;
			if (winner < 0)
			{
				selection = 1;
			}
			if (winner > 0)
			{
				selection = 2;
			}
			if (player1.Value <= 21 || player2.Value <= 21)
			{
				switch (selection)
				{
					case (1):
						Console.WriteLine($"Winner's {player1.Name} with {player1.Value} points");
						break;
					case (2):
						Console.WriteLine($"Winner's {player2.Name} with {player2.Value} points");
						break;
					default:
						Console.WriteLine($"Draw, all of players got {player1.Value}");
						break;
				}
			}
			else
			{
				Console.WriteLine($"Lose, {player1.Name} have {player1.Value} and {player2.Name} have {player2.Value}");
			}
		}
		private String SimulateGame(String key)
		{

			bool stop = true;
			if(key == "n" || key == "N")
			{
				stop = false;
			}
			while (stop)
			{
				var player1 = PlayerGetCard("Player1");
				var player2 = PlayerGetCard("Player2");

				if (player1.Value >= 21 && player2.Value >= 21)
				{
					stop = false;
				}

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
				 key = SimulateGame(key);
			}
		}
	}
}

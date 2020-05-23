using Blackjack.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Blackjack
{
	class Program
	{
		//public static Card GetCard()
		//{
		//	Card card = new Card();
		//	Random random = new Random();
		//	card.Value = (Value)random.Next(12);
		//	card.Suit = (Suit)random.Next(4);
		//	return card;
		//}

		public static List<Card> GenerateDeck(List<Card> deck)
		{
			for (int i = 2; i < 15; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					Card card = new Card();
					card.Value = (Value)i;
					card.Suit = (Suit)j;
					deck.Add(card);
				}
			}
			return deck;
		}

		public static void ShuffleDeck(List<Card> deck)
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

		public static Card GetCard(List<Card> deck)
		{
			Card container = new Card();
			ShuffleDeck(deck);
			container = deck[0];
			deck.RemoveAt(0);
			return container;
		}

		static void Main(string[] args)
		{
			string key = "";

			while (key != "n" || key != "N")
			{
				Player player1 = new Player("Player1");
				Player player2 = new Player("Player2");
				bool stop = true;
				var deck = new List<Card>();
				GenerateDeck(deck);
				while (stop)
				{
					while(player1.Value < 21)
					{
						player1.AddCard(GetCard(deck));
						player1.CountValue();
						Console.WriteLine($"{player1.Name} got a {player1.Hand[player1.Hand.Count-1].Value} of {player1.Hand[player1.Hand.Count-1].Suit}");
					}

					while (player2.Value < 21)
					{
						player2.AddCard(GetCard(deck));
						player2.CountValue();
						Console.WriteLine($"{player2.Name} got a {player2.Hand[player2.Hand.Count - 1].Value} of {player2.Hand[player2.Hand.Count - 1].Suit}");
					}

					if (player1.Value >= 21 && player2.Value >= 21)
					{
						stop = false;
					}

					if (!stop)
					{
						int winner = player1.Value - player2.Value;
						if (player1.Value <= 21 || player2.Value <= 21)
						{
							if(winner < 0)
							{
								Console.WriteLine($"Winner's {player1.Name} with {player1.Value} points");
							}
							else if (winner > 0)
							{
								Console.WriteLine($"Winner's {player2.Name} with {player2.Value} points");
							}
							else
							{
								Console.WriteLine($"Draw, all of players got {player1.Value}");
							}
						}
						else
						{
							Console.WriteLine($"Lose, {player1.Name} have {player1.Value} and {player2.Name} have {player2.Value}");
						}
					}

						Console.WriteLine("Y - to New game \nn - to Exit");
						key = Console.ReadLine();
				}
			}
		}
	}
}

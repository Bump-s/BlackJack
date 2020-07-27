using System.Collections.Generic;

namespace Blackjack
{
    class Player
    {
		public string Name { get; set; }
		public List<Card> Hand { get; set; }
		public int Value { get; set; }

		public Player(string name)
		{
			Name = name;
			Hand = new List<Card>();
		}

		public void AddCard(Card card)
		{
			Hand.Add(card);
		}

		public void CountValue()
		{
			Value = 0;
			foreach (var item in Hand)
			{
				if ((int)item.Value == 14)
				{
					Value += 11;
				}
				else if(((int)item.Value > 10) && ((int)item.Value != 14))
				{
					Value += 10;
				}
				else
				{
					Value += (int)item.Value;
				}
			}
		}
	}
}

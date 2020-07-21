using System;
using System.Collections.Generic;
using System.Text;
using Blackjack.Enums;
using System.Linq;

namespace Blackjack
{
    class Deck
    {
        private List<Card> MainDeck { get; set; }
        public Deck()
        {
            MainDeck = new List<Card>();
        }
        public void GenerateDeck()
        {
            int minCardVAlue = 2;
            int maxCardValue = 15;
            int minCardSuit = 0;
            int maxCarSuit = 4;
            for (int cardValue = minCardVAlue; cardValue < maxCardValue; cardValue++)
            {
                for (int cardSuit = minCardSuit; cardSuit < maxCarSuit; cardSuit++)
                {
                    var card = new Card((Value)cardValue, (Suit)cardSuit);
                    MainDeck.Add(card);
                }
            }
        }

        public void ShuffleDeck()
        {
            Random random = new Random();
            for (int deckCounter = MainDeck.Count() - 1; deckCounter >= 1; deckCounter--)
            {
                int randomizer = random.Next(deckCounter + 1);
                var temp = MainDeck[randomizer];
                MainDeck[randomizer] = MainDeck[deckCounter];
                MainDeck[deckCounter] = temp;
            }
        }

        public Card GetCard()
        {
            int minValue = 2;
            int minSuit = 0;
            var container = new Card((Value)minValue, (Suit)minSuit);
            container = MainDeck[0];
            MainDeck.RemoveAt(0);
            return container;
        }
    }
}

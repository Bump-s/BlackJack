using System;
using System.Collections.Generic;
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
            GenerateDeck();
            ShuffleDeck();
        }

        private void GenerateDeck()
        {
            var minCardVAlue = 2;
            var maxCardValue = 15;
            var minCardSuit = 0;
            var maxCarSuit = 4;
            for (var cardValue = minCardVAlue; cardValue < maxCardValue; cardValue++)
            {
                for (var cardSuit = minCardSuit; cardSuit < maxCarSuit; cardSuit++)
                {
                    var card = new Card((Value)cardValue, (Suit)cardSuit);
                    MainDeck.Add(card);
                }
            }
        }

        private void ShuffleDeck()
        {
            var random = new Random();
            for (var deckCounter = MainDeck.Count() - 1; deckCounter >= 1; deckCounter--)
            {
                var randomizer = random.Next(deckCounter + 1);
                var temp = MainDeck[randomizer];
                MainDeck[randomizer] = MainDeck[deckCounter];
                MainDeck[deckCounter] = temp;
            }
        }

        public Card GetCard()
        {
            var card = MainDeck.Last();
            MainDeck.Remove(card);
            return card;
        }
    }
}

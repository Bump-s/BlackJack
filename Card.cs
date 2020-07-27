using Blackjack.Enums;

namespace Blackjack
{
    class Card
    {
        public Value Value { get; set; }
        public Suit Suit { get; set; }

        public Card (Value value,Suit suit)
        {
            this.Value = value;
            this.Suit = suit;
        }
        
    }
}

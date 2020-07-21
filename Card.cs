using Blackjack.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

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

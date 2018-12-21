using System;
using System.Collections.Generic;
using System.Text;

namespace PokerProject
{
    public enum Suit
    {
        HEARTS,
        SPADES,
        DIAMONDS,
        CLUBS
    }

    public enum CardValue
    {
        TWO, THREE, FOUR, FIVE, SIX, SEVEN,
        EIGHT, NINE, TEN, JACK, QUEEN, KING, ACE
    }

    class Card
    {
        public Suit suit { get; set; }
        public CardValue value { get; set; }
    }
}

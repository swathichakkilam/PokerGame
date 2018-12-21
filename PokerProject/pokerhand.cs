using System;
using System.Collections.Generic;
using System.Text;

namespace PokerProject
{
    public enum PokerHand
    {
        Nothing,
        OnePair,
        TwoPairs,
        ThreeKind,
        Straight,
        Flush,
        FullHouse,
        FourKind
    }


    public struct HandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

}

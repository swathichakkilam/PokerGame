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

    public struct pokerHandValue
    {
        public int Total { get; set; }
        public int HighCard { get; set; }
    }

}

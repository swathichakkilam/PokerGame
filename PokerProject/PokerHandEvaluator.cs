namespace PokerProject
{
    class PokerHandEvaluator : Card
    {
        private int totalHeartsValue;
        private int totalDiamondValue;
        private int totalClubValue;
        private int totalSpadeValue;
        private Card[] cards;
        private pokerHandValue pokerHandValue;

        public PokerHandEvaluator(Card[] sortedHand)
        {
            totalHeartsValue = 0;
            totalDiamondValue = 0;
            totalClubValue = 0;
            totalSpadeValue = 0;
            cards = new Card[5];
            Cards = sortedHand;
            pokerHandValue = new pokerHandValue();
        }

        public pokerHandValue pokerHandValues
        {
            get { return pokerHandValue; }
            set { pokerHandValue = value; }
        }

        public Card[] Cards
        {
            get { return cards; }
            set
            {
                cards[0] = value[0];
                cards[1] = value[1];
                cards[2] = value[2];
                cards[3] = value[3];
                cards[4] = value[4];
            }
        }

        /// <summary>
        /// Evaluates Poker Hand, which gives us the best combination based  on the card values and suits.
        /// </summary>
        /// <returns>One of the PokerHands or nothing.</returns>
        public PokerHand EvaluatePokerHand()
        {
            //get the number of each suit on hand
            computeSuitTotals();
            if (FourOfKind())
                return PokerHand.FourKind;
            else if (FullHouse())
                return PokerHand.FullHouse;
            else if (Flush())
                return PokerHand.Flush;
            else if (Straight())
                return PokerHand.Straight;
            else if (ThreeOfKind())
                return PokerHand.ThreeKind;
            else if (TwoPairs())
                return PokerHand.TwoPairs;
            else if (OnePair())
                return PokerHand.OnePair;

            //if the hand is nothing, than the player with highest card wins
            pokerHandValue.HighCard = (int)cards[4].value;
            return PokerHand.Nothing;
        }

        /// <summary>
        /// Computes the total value of different suits.
        /// </summary>
        private void computeSuitTotals()
        {
            foreach (var card in Cards)
            {
                if (card.suit == Suit.HEARTS)
                    totalHeartsValue++;
                else if (card.suit == Suit.DIAMONDS)
                    totalDiamondValue++;
                else if (card.suit == Suit.CLUBS)
                    totalClubValue++;
                else if (card.suit == Suit.SPADES)
                    totalSpadeValue++;
            }
        }

        /// <summary>
        /// Check if the hand is a four of a kind
        /// </summary>
        /// <returns>True if four of a kind.</returns>
        private bool FourOfKind()
        {
            //if the first 4 cards, add values of the four cards and last card is the highest
            if (cards[0].value == cards[1].value && cards[0].value == cards[2].value && cards[0].value == cards[3].value)
            {
                pokerHandValue.Total = (int)cards[1].value * 4;
                pokerHandValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[1].value == cards[2].value && cards[1].value == cards[3].value && cards[1].value == cards[4].value)
            {
                pokerHandValue.Total = (int)cards[1].value * 4;
                pokerHandValue.HighCard = (int)cards[0].value;
                return true;
            }

            return false;
        }


        /// <summary>
        /// Check if the hand is Full House
        /// </summary>
        /// <returns>True if full house.</returns>
        private bool FullHouse()
        {
            //the first three cars and last two cards are of the same value
            //first two cards, and last three cards are of the same value
            if ((cards[0].value == cards[1].value && cards[0].value == cards[2].value && cards[3].value == cards[4].value) ||
                (cards[0].value == cards[1].value && cards[2].value == cards[3].value && cards[2].value == cards[4].value))
            {
                pokerHandValue.Total = (int)(cards[0].value) + (int)(cards[1].value) + (int)(cards[2].value) +
                    (int)(cards[3].value) + (int)(cards[4].value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the hand is flush.
        /// </summary>
        /// <returns>True if flush.</returns>
        private bool Flush()
        {
            //if all suits are the same
            if (totalHeartsValue == 5 || totalDiamondValue == 5 || totalClubValue == 5 || totalSpadeValue == 5)
            {
                //if flush, the player with higher cards win
                //whoever has the last card the highest, has automatically all the cards total higher
                pokerHandValue.Total = (int)cards[4].value;
                return true;
            }

            return false;
        }


        /// <summary>
        /// Check if the hand is straight.
        /// </summary>
        /// <returns>True if straight.</returns>
        private bool Straight()
        {
            //if 5 consecutive values
            if (cards[0].value + 1 == cards[1].value &&
                cards[1].value + 1 == cards[2].value &&
                cards[2].value + 1 == cards[3].value &&
                cards[3].value + 1 == cards[4].value)
            {
                //player with the highest value of the last card wins
                pokerHandValue.Total = (int)cards[4].value;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the hand is threeofkind.
        /// </summary>
        /// <returns>True if three of a kind.</returns>
        private bool ThreeOfKind()
        {
            //if the 1,2,3 cards are the same OR
            //2,3,4 cards are the same OR
            //3,4,5 cards are the same
            //3rds card will always be a part of Three of A Kind
            if ((cards[0].value == cards[1].value && cards[0].value == cards[2].value) ||
            (cards[1].value == cards[2].value && cards[1].value == cards[3].value))
            {
                pokerHandValue.Total = (int)cards[2].value * 3;
                pokerHandValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[2].value == cards[3].value && cards[2].value == cards[4].value)
            {
                pokerHandValue.Total = (int)cards[2].value * 3;
                pokerHandValue.HighCard = (int)cards[1].value;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the hand is two pairs.
        /// </summary>
        /// <returns>True if two pairs.</returns>
        private bool TwoPairs()
        {
            //if 1,2 and 3,4
            //if 1.2 and 4,5
            //if 2.3 and 4,5
            //with two pairs, the 2nd card will always be a part of one pair 
            //and 4th card will always be a part of second pair
            if (cards[0].value == cards[1].value && cards[2].value == cards[3].value)
            {
                pokerHandValue.Total = ((int)cards[1].value * 2) + ((int)cards[3].value * 2);
                pokerHandValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[0].value == cards[1].value && cards[3].value == cards[4].value)
            {
                pokerHandValue.Total = ((int)cards[1].value * 2) + ((int)cards[3].value * 2);
                pokerHandValue.HighCard = (int)cards[2].value;
                return true;
            }
            else if (cards[1].value == cards[2].value && cards[3].value == cards[4].value)
            {
                pokerHandValue.Total = ((int)cards[1].value * 2) + ((int)cards[3].value * 2);
                pokerHandValue.HighCard = (int)cards[0].value;
                return true;
            }
            return false;
        }


        /// <summary>
        /// CHeck if the hand has one pair.
        /// </summary>
        /// <returns>True if the hand has a pair.</returns>
        private bool OnePair()
        {
            //if 1,2 -> 5th card has the highest value
            //2.3
            //3,4
            //4,5 -> card #3 has the highest value
            if (cards[0].value == cards[1].value)
            {
                pokerHandValue.Total = (int)cards[0].value * 2;
                pokerHandValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[1].value == cards[2].value)
            {
                pokerHandValue.Total = (int)cards[1].value * 2;
                pokerHandValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[2].value == cards[3].value)
            {
                pokerHandValue.Total = (int)cards[2].value * 2;
                pokerHandValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[3].value == cards[4].value)
            {
                pokerHandValue.Total = (int)cards[3].value * 2;
                pokerHandValue.HighCard = (int)cards[2].value;
                return true;
            }

            return false;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace PokerProject
{
    class PokerHandEvaluator : Card
    {
        private int heartsSum;
        private int diamondSum;
        private int clubSum;
        private int spadesSum;
        private Card[] cards;
        private HandValue handValue;

        public PokerHandEvaluator(Card[] sortedHand)
        {
            heartsSum = 0;
            diamondSum = 0;
            clubSum = 0;
            spadesSum = 0;
            cards = new Card[5];
            Cards = sortedHand;
            handValue = new HandValue();
        }

        public HandValue HandValues
        {
            get { return handValue; }
            set { handValue = value; }
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

        public PokerHand EvaluatePokerHand()
        {
            //get the number of each suit on hand
            getNumberOfSuit();
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
            handValue.HighCard = (int)cards[4].value;
            return PokerHand.Nothing;
        }

        private void getNumberOfSuit()
        {
            foreach (var element in Cards)
            {
                if (element.suit == Suit.HEARTS)
                    heartsSum++;
                else if (element.suit == Suit.DIAMONDS)
                    diamondSum++;
                else if (element.suit == Suit.CLUBS)
                    clubSum++;
                else if (element.suit == Suit.SPADES)
                    spadesSum++;
            }
        }

        private bool FourOfKind()
        {
            //if the first 4 cards, add values of the four cards and last card is the highest
            if (cards[0].value == cards[1].value && cards[0].value == cards[2].value && cards[0].value == cards[3].value)
            {
                handValue.Total = (int)cards[1].value * 4;
                handValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[1].value == cards[2].value && cards[1].value == cards[3].value && cards[1].value == cards[4].value)
            {
                handValue.Total = (int)cards[1].value * 4;
                handValue.HighCard = (int)cards[0].value;
                return true;
            }

            return false;
        }

        private bool FullHouse()
        {
            //the first three cars and last two cards are of the same value
            //first two cards, and last three cards are of the same value
            if ((cards[0].value == cards[1].value && cards[0].value == cards[2].value && cards[3].value == cards[4].value) ||
                (cards[0].value == cards[1].value && cards[2].value == cards[3].value && cards[2].value == cards[4].value))
            {
                handValue.Total = (int)(cards[0].value) + (int)(cards[1].value) + (int)(cards[2].value) +
                    (int)(cards[3].value) + (int)(cards[4].value);
                return true;
            }

            return false;
        }

        private bool Flush()
        {
            //if all suits are the same
            if (heartsSum == 5 || diamondSum == 5 || clubSum == 5 || spadesSum == 5)
            {
                //if flush, the player with higher cards win
                //whoever has the last card the highest, has automatically all the cards total higher
                handValue.Total = (int)cards[4].value;
                return true;
            }

            return false;
        }

        private bool Straight()
        {
            //if 5 consecutive values
            if (cards[0].value + 1 == cards[1].value &&
                cards[1].value + 1 == cards[2].value &&
                cards[2].value + 1 == cards[3].value &&
                cards[3].value + 1 == cards[4].value)
            {
                //player with the highest value of the last card wins
                handValue.Total = (int)cards[4].value;
                return true;
            }

            return false;
        }

        private bool ThreeOfKind()
        {
            //if the 1,2,3 cards are the same OR
            //2,3,4 cards are the same OR
            //3,4,5 cards are the same
            //3rds card will always be a part of Three of A Kind
            if ((cards[0].value == cards[1].value && cards[0].value == cards[2].value) ||
            (cards[1].value == cards[2].value && cards[1].value == cards[3].value))
            {
                handValue.Total = (int)cards[2].value * 3;
                handValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[2].value == cards[3].value && cards[2].value == cards[4].value)
            {
                handValue.Total = (int)cards[2].value * 3;
                handValue.HighCard = (int)cards[1].value;
                return true;
            }
            return false;
        }

        private bool TwoPairs()
        {
            //if 1,2 and 3,4
            //if 1.2 and 4,5
            //if 2.3 and 4,5
            //with two pairs, the 2nd card will always be a part of one pair 
            //and 4th card will always be a part of second pair
            if (cards[0].value == cards[1].value && cards[2].value == cards[3].value)
            {
                handValue.Total = ((int)cards[1].value * 2) + ((int)cards[3].value * 2);
                handValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[0].value == cards[1].value && cards[3].value == cards[4].value)
            {
                handValue.Total = ((int)cards[1].value * 2) + ((int)cards[3].value * 2);
                handValue.HighCard = (int)cards[2].value;
                return true;
            }
            else if (cards[1].value == cards[2].value && cards[3].value == cards[4].value)
            {
                handValue.Total = ((int)cards[1].value * 2) + ((int)cards[3].value * 2);
                handValue.HighCard = (int)cards[0].value;
                return true;
            }
            return false;
        }

        private bool OnePair()
        {
            //if 1,2 -> 5th card has the highest value
            //2.3
            //3,4
            //4,5 -> card #3 has the highest value
            if (cards[0].value == cards[1].value)
            {
                handValue.Total = (int)cards[0].value * 2;
                handValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[1].value == cards[2].value)
            {
                handValue.Total = (int)cards[1].value * 2;
                handValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[2].value == cards[3].value)
            {
                handValue.Total = (int)cards[2].value * 2;
                handValue.HighCard = (int)cards[4].value;
                return true;
            }
            else if (cards[3].value == cards[4].value)
            {
                handValue.Total = (int)cards[3].value * 2;
                handValue.HighCard = (int)cards[2].value;
                return true;
            }

            return false;
        }

    }

}

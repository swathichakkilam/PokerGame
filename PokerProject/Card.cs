using System;
using System.Collections.Generic;
using System.Text;

namespace PokerProject
{
    class Card
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
            one,two,three,four,five,six,seven,
            eight,nine,ten,Jack,Queen,King,Ace
        }
        #region Card Properties
        /// <summary>
        /// CurrSuitVal is a property of type Suit which is an enum 
        /// where CurrSuitVal is a way to retrieve the current suit value and store it in CurrSuitVal
        /// </summary>
        public Suit CurrSuitVal { get; set; }

        /// <summary>
        /// CurrentCardVal is a property of type CardValue which is an enum
        /// where CurrentCardVal holds the current card value at that moment 
        /// </summary>
        //used camel casing for property names for readability 
       public CardValue CurrentCardVal { get; set; }
        #endregion



    }
}

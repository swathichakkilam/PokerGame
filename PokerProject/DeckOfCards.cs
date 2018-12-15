using System;
using System.Collections.Generic;
using System.Text;

namespace PokerProject
{
    class DeckOfCards : Card
    {
        const int Numofcards = 52;
        /// <summary>
        /// deckofcards is an array of type Card where Card is a reference type so both suit value
        /// and card number or cardvalue exist within each index of the array of type Card[]
        /// </summary>
        private Card[] deckofcards;

        public DeckOfCards()
            {
            /*allocating memory space via new keyword in memory 
            for the private array deck and accessing it via Constructor*/
            this.deckofcards = new Card[Numofcards];
            }
    }
}

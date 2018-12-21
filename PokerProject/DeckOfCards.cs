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
        /// <summary>
        /// To retrieve the deck at the current moment from the array (we do not set it at this point)
        /// we write a property called getdeck which reads the deck at the current moment
        /// to give to user and then deck of cards is one card less  when card is given to the system 
        /// getter reads from a private variable
        /// as constructor cannot be used to return the value of the private variable
        /// </summary>
        public Card[] getdeck { get { return deckofcards; } }
        /// <summary>
        /// Populating the array with cards having suit and card value using the method Setdeck
        /// All cards will be populated in an unshuffled manner
        /// Enum class consists of a method called GetValues
        /// which returns an array of values i.e the underlying number or value associated with each field in the particular enum 
        /// </summary>
        public void Setdeck()
        {
            int i = 0;
            //specifying that the enum is of type Suit enum 
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
                {
                //specifying that the enum is of type CardValue enum
                foreach(CardValue v in Enum.GetValues(typeof(CardValue)))
                {
                    deckofcards[i] = new Card { suit = s, value = v };
                    i++;
                }
            }

            Shufflecards();

        }
        /// <summary>
        /// Method to shuffle the cards by taking inner for loop and 
        ///using Random function to help shuffle thouroughly
        /// </summary>
        public void Shufflecards()
        {
            Random rand = new Random();
            Card temp;
            for(int numofshuffles =0; numofshuffles <100; numofshuffles++ )
            {
                for(int i=0;i<Numofcards;i++)
                {
                    //swapping the cards
                    int secondcrdidx = rand.Next(13);
                    temp = deckofcards[i];
                    deckofcards[i] = deckofcards[secondcrdidx];
                    deckofcards[secondcrdidx] = temp;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerProject
{
    class DealerDrawCards: DeckOfCards
    {
        private Card[] playerHand;
        private Card[] computerHand;
        private Card[] sortedPlayerHand;
        private Card[] sortedComputerHand;

        public DealerDrawCards()
        {
            playerHand = new Card[5];
            sortedPlayerHand = new Card[5];
            computerHand = new Card[5];
            sortedComputerHand = new Card[5];
        }

        public void Deal()
        {
            Setdeck(); //create the deck of cards and shuffle them
            getHand();
            sortCards();
            displayCards();
            evaluateHands();
        }

        public void getHand()
        {
            //5 cards for the player
            for (int i = 0; i < 5; i++)
                playerHand[i] = getdeck[i];

            //5 cards for the computer
            for (int i = 5; i < 10; i++)
                computerHand[i - 5] = getdeck[i];
        }
        /// <summary>
        /// Method to sort the cards based on low to high ranks
        /// using LINQ and built in function such as OrderBy
        /// </summary>
        public void sortCards()
        {
            var queryPlayer = playerHand.OrderBy(item => item.value).ToList();

            var queryComputer = computerHand.OrderBy(item => item.value).ToList();

            var index = 0;
            foreach (var element in queryPlayer)
            {
                sortedPlayerHand[index] = element;
                index++;
            }

            index = 0;
            foreach (var element in queryComputer)
            {
                sortedComputerHand[index] = element;
                index++;
            }
        }
        /// <summary>
        /// method to display cards in an order based on co-ordinates 
        /// </summary>
        public void displayCards()
        {
            Console.Clear();
            int x = 0; //x position of the cursor. We move it left and right
            int y = 1;//y position of the cursor, we move up and down

            //display player hand
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("PLAYER'S HAND");
            for (int i = 0; i < 5; i++)
            {
                DrawCardsonScreen.Cardillustration(x, y);
                DrawCardsonScreen.DrawSuitValue(sortedPlayerHand[i], x, y);
                x++;//move to the right
            }
            y = 15; //move the row of computer cards below the player's cards
            x = 0; //reset x position
            Console.SetCursorPosition(x, 14);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("COMPUTER'S HAND");
            for (int i = 5; i < 10; i++)
            {
                DrawCardsonScreen.Cardillustration(x, y);
                DrawCardsonScreen.DrawSuitValue(sortedComputerHand[i - 5], x, y);
                x++;//move to the right
            }

        }
        /// <summary>
        /// Trying to create players and computers hand objects
        /// Mthod to get the player and computers hand
        /// </summary>
        public void evaluateHands()
        {
           
            PokerHandEvaluator playerHandEvaluator = new PokerHandEvaluator(sortedPlayerHand);
            PokerHandEvaluator computerHandEvaluator = new PokerHandEvaluator(sortedComputerHand);

            
            PokerHand playerHand = playerHandEvaluator.EvaluatePokerHand();
            PokerHand computerHand = computerHandEvaluator.EvaluatePokerHand();

            //display each hand
            Console.WriteLine("\n\n\n\n\nPlayer's Hand: " + playerHand);
            Console.WriteLine("\nComputer's Hand: " + computerHand);

            //evaluate hands
            if (playerHand > computerHand)
            {
                Console.WriteLine("Player WINS!");
            }
            else if (playerHand < computerHand)
            {
                Console.WriteLine("Computer WINS!");
            }
            else //if the hands are the same, evaluate the values
            {
                if (playerHandEvaluator.HandValues.Total > computerHandEvaluator.HandValues.Total)
                    Console.WriteLine("Player WINS!");
                else if (playerHandEvaluator.HandValues.Total < computerHandEvaluator.HandValues.Total)
                    Console.WriteLine("Computer WINS!");
                //if both have the same poker hand (for example, both have a pair of queens), 
                //then the player with the next higher card wins
                else if (playerHandEvaluator.HandValues.HighCard > computerHandEvaluator.HandValues.HighCard)
                    Console.WriteLine("Player WINS!");
                else if (playerHandEvaluator.HandValues.HighCard < computerHandEvaluator.HandValues.HighCard)
                    Console.WriteLine("Computer WINS!");
                else
                    Console.WriteLine("DRAW, no one wins!");
            }
        }
    }
}

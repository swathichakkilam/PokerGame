using System;
using System.Linq;

namespace PokerProject
{
    class DealerDrawCards : DeckOfCards
    {
        private Card[] playersHandCards;
        private Card[] computersHandCards;
        private Card[] sortedPlayersHandCards;
        private Card[] sortedComputersHandCards;

        public DealerDrawCards()
        {
            playersHandCards = new Card[5];
            sortedPlayersHandCards = new Card[5];
            computersHandCards = new Card[5];
            sortedComputersHandCards = new Card[5];
        }

        /// <summary>
        /// Distribute the cards, and evaluates the hands between player and the computer
        /// </summary>
        public void Deal()
        {
            Setdeck(); //Creates a new deck of cards, and shuffles the cards.
            DistributeCards(); // Distributes the cards to both the player and computer.
            ArrangeCards(); // Sorts the cards for evaluation.
            DisplayHands(); // Displays the cards on screen.
            EvaluateAndJudge(); // Evaluates the players and computers hand and decides the winner.
        }

        /// <summary>
        /// 
        /// </summary>
        public void DistributeCards()
        {
            //5 cards for the player
            for (int i = 0; i < 5; i++)
                playersHandCards[i] = getdeck[i];

            //5 cards for the computer
            for (int i = 5; i < 10; i++)
                computersHandCards[i - 5] = getdeck[i];
        }
        /// <summary>
        /// Method to sort the cards based on low to high ranks
        /// using LINQ and built in function such as OrderBy
        /// </summary>
        public void ArrangeCards()
        {
            var queryPlayer = playersHandCards.OrderBy(item => item.value).ToList();

            var queryComputer = computersHandCards.OrderBy(item => item.value).ToList();

            var index = 0;
            foreach (var element in queryPlayer)
            {
                sortedPlayersHandCards[index] = element;
                index++;
            }

            index = 0;
            foreach (var element in queryComputer)
            {
                sortedComputersHandCards[index] = element;
                index++;
            }
        }
        /// <summary>
        /// Method to display cards in an order based on co-ordinates 
        /// </summary>
        public void DisplayHands()
        {
            Console.Clear();
            int x = 0;
            int y = 1;


            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("PLAYER'S POKER HAND");
            for (int i = 0; i < 5; i++)
            {
                DrawCardsonScreen.Cardillustration(x, y);
                DrawCardsonScreen.DrawSuitValue(sortedPlayersHandCards[i], x, y);
                x++;
            }
            y = 15;
            x = 0;
            Console.SetCursorPosition(x, 14);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("COMPUTER'S POKER HAND");
            for (int i = 5; i < 10; i++)
            {
                DrawCardsonScreen.Cardillustration(x, y);
                DrawCardsonScreen.DrawSuitValue(sortedComputersHandCards[i - 5], x, y);
                x++;
            }

        }
        /// <summary>
        /// Trying to create players and computers hand objects
        /// Method to get the player and computers hand
        /// </summary>
        public void EvaluateAndJudge()
        {

            PokerHandEvaluator playersHandCardsEvaluator = new PokerHandEvaluator(sortedPlayersHandCards);
            PokerHandEvaluator computersHandCardsEvaluator = new PokerHandEvaluator(sortedComputersHandCards);


            PokerHand playersHandCards = playersHandCardsEvaluator.EvaluatePokerHand();
            PokerHand computersHandCards = computersHandCardsEvaluator.EvaluatePokerHand();


            Console.WriteLine("\n\n\n\n\nPlayer's Hand: " + playersHandCards);
            Console.WriteLine("\nComputer's Hand: " + computersHandCards);


            if (playersHandCards > computersHandCards)
            {
                Console.WriteLine("Player Hand WINS!");
            }
            else if (playersHandCards < computersHandCards)
            {
                Console.WriteLine("Computer Hand WINS!");
            }
            else
            {
                if (playersHandCardsEvaluator.pokerHandValues.Total > computersHandCardsEvaluator.pokerHandValues.Total)
                    Console.WriteLine("Player Hand WINS!");
                else if (playersHandCardsEvaluator.pokerHandValues.Total < computersHandCardsEvaluator.pokerHandValues.Total)
                    Console.WriteLine("Computer Hand WINS!");
                //if both player and computer have the same poker hand then the player with the next higher card wins
                else if (playersHandCardsEvaluator.pokerHandValues.HighCard > computersHandCardsEvaluator.pokerHandValues.HighCard)
                    Console.WriteLine("Player Hand WINS!");
                else if (playersHandCardsEvaluator.pokerHandValues.HighCard < computersHandCardsEvaluator.pokerHandValues.HighCard)
                    Console.WriteLine("Computer Hand WINS!");
                else
                    Console.WriteLine("No one wins!");
            }
        }
    }
}

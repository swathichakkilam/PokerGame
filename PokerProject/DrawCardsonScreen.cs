using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
    class DrawCardsonScreen
    {
        /// <summary>
        /// Method's Code written to create a card shape manually to depict all cards on computer screen
        /// Static keyword used as both player and system use the same shared memory space internally
        /// to display the cards on screen 
        /// </summary>
        /// <param name="xcoordinate"></param>
        /// <param name="ycoordinate"></param>
        public static void Cardillustration(int xcoordinate, int ycoordinate)
        {
            Console.ForegroundColor = ConsoleColor.White;
            /*in order to draw each card without overlapping side by side multiplying
            xcoordinate by 12 hence x2 starts 12 points after first card creation on the screen*/
            int x = xcoordinate * 12;
            int y = ycoordinate;
            //trying to set the position of the card at the top left position on the screen
            Console.SetCursorPosition(x, y);
            Console.Write("_____________\n");//top borderline of the card being virtually displayed on the computer screen
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x, y + 1 + i);
                if (i != 9)
                    Console.WriteLine("|          |");
                else
                    //bottom edge of the card illustration on screen
                    Console.WriteLine("|__________|");

            }



        }


        //displays suit and value of the card inside its outline
        public static void DrawSuitValue(Card card, int xcoor, int ycoor)
        {
            char cardSuit = ' ';
            int x = xcoor * 12;
            int y = ycoor;

            //Encode each byte array from the CodePage437 into a character
            //hears and diamonds are red, clubs and spades are black
            switch (card.suit)
            {
                case Suit.HEARTS:
                    cardSuit = 'H';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.DIAMONDS:
                    cardSuit = 'D';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.CLUBS:
                    cardSuit = 'C';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case Suit.SPADES:
                    cardSuit = 'S';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            //display the encoded character and value of the card
            Console.SetCursorPosition(x + 5, y + 5);
            Console.Write(cardSuit);
            Console.SetCursorPosition(x + 4, y + 7);
            Console.Write(card.value);

        }
    }


}


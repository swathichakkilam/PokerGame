using System;
using System.Collections.Generic;
using System.Text;

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

        /// <summary>
        /// This Method displays the suit and card value inside the 
        /// borders of the card
        /// It involves encoding the suit and value for each card in the deck of cards
        /// </summary>
        /// <param name="card"></param>
        /// <param name="xcoordinate"></param>
        /// <param name="ycoordinate"></param>
        //public static void DrawCardsuitvalue(Card card,int xcoordinate, int ycoordinate)
        //{

        //}
        }

        
    }


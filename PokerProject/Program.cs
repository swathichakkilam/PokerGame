using System;

namespace PokerProject
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(63, 35);
            // remove scroll bars by setting the buffer to the actual window size
            Console.BufferWidth = 65;
            Console.BufferHeight = 40;
            Console.Title = "Poker Game";
            DealerDrawCards dc = new DealerDrawCards();
            bool quit = false;

            while (!quit)
            {
                dc.Deal();

                char selection = ' ';
                while (!selection.Equals('Y') && !selection.Equals('N'))
                {
                    Console.WriteLine("Do you want to try again? Y-N");
                    selection = Convert.ToChar(Console.ReadLine().ToUpper());

                    if (selection.Equals('Y'))
                        quit = false;
                    else if (selection.Equals('N'))
                        quit = true;
                    else
                        Console.WriteLine("Selection is not valid. Please try again.");
                }
            }

            Console.ReadKey();
        }
    }
}

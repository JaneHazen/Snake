using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interfaces;

namespace Snake
{
    /// <summary>
    /// Draw the board to the screen
    /// </summary>
    public class Board : IBoard
    {
        //set up the height and width of the board
        public int Boardwidth { get; private set; }
        public int Boardheight { get; private set; }
        public char BoardComposition { get; private set; }

        // initialize the board with a specific height and width
        // set the composition of the board (what will the boarder look like)
        // Draw the board
        public Board()
        {
            Boardwidth = Console.WindowWidth;
            Boardheight = Console.WindowHeight;
            BoardComposition = 'X';
        }

        public void DrawBoard()
        {
            WriteHorizontalBorders();
            WriteVerticalBorders();
        }

        // Draw the horizontal border with pound signs
        // Draw the horizontal border with pound signs

        public void WriteHorizontalBorders()

        {

            // loop through the boardwidth to make horizontal pounds

            for (int i = 1; i < Boardwidth; i++)

            {

                // Set the cursor to each position on the x axis that is less than the boardwidth and write a #

                Console.SetCursorPosition(i, 1);

                Console.Write(BoardComposition);

                // Set the cursor to each position on the y axis that is less than the boardheight and write a # 

                Console.SetCursorPosition(i, Boardheight - 1);

                Console.Write(BoardComposition);

            }

        }



        //Draw vertical border with pound signs

        public void WriteVerticalBorders()

        {

            // loop through the boardheight to make vertical pounds

            for (int i = 0; i < Boardheight; i++)

            {

                // Set the cursor to each position on the y axis that is less than the boardheight and write a #

                Console.SetCursorPosition(1, i);

                Console.WriteLine(BoardComposition);

                // Set the cursor to each position on the x axis that is less than the boardwidth and write a # 

                Console.SetCursorPosition(Boardwidth - 1, i);

                Console.WriteLine(BoardComposition);



            }

        }

    }
}

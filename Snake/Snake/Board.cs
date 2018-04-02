using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    /// <summary>
    /// Draw the board to the screen
    /// </summary>
    public class Board
    {
        //set up the height and width of the board
        public static int Boardwidth;
        public static int Boardheight;

        // initialize the board with a specific height and width
        // Draw the board
        public Board()
        {
            Boardwidth = 70;
            Boardheight = 40;
            WriteHorizontalBorders();
            WriteVerticalBorders();
        }

        // Draw the horizontal border with pound signs
        public void WriteHorizontalBorders()
        {
            // loop through the boardwidth to make horizontal pounds
            for(int i = 0; i < Boardwidth; i++)
            {
                // Set the cursor to each position on the x axis that is less than the boardwidth and write a #
                Console.SetCursorPosition(i, 1);
                Console.Write("#");
                // Set the cursor to each position on the y axis that is less than the boardheight and write a # 
                Console.SetCursorPosition(i, Boardheight-1);
                Console.Write("#");
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
                Console.WriteLine("#");
                // Set the cursor to each position on the x axis that is less than the boardwidth and write a # 
                Console.SetCursorPosition(Boardwidth-1, i);
                Console.WriteLine("#");

            }
        }

    }
}

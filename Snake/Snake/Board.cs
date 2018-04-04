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
        public int Boardwidth { get; private set; }
        public int Boardheight { get; private set; }
        public static char BoardComposition { get; private set; }

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
        public void WriteHorizontalBorders()
        {
            // loop through the boardwidth to make horizontal pounds
            string row = new String(BoardComposition, Boardwidth );
            Console.SetCursorPosition(0, 0);
            Console.Write(row);
            Console.SetCursorPosition(0, Boardheight - 2);
            Console.Write(row);
        }

        //Draw vertical border with pound signs
        public void WriteVerticalBorders()
        {
            // loop through the boardheight to make vertical pounds
            for (int borderY = 0; borderY < Boardheight - 2; borderY++)
            {
                Console.SetCursorPosition(0, borderY);
                Console.Write(BoardComposition.ToString());
                Console.SetCursorPosition(Boardwidth - 1, borderY);
                Console.Write(BoardComposition.ToString());
            }
        }

    }
}

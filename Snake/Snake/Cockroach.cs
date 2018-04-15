using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interfaces;


namespace Snake
{
    class Cockroach : ICockroach
    {
        public int XPosition { get; private set; }
        public int YPosition { get; private set; }
        public char Icon { get; private set; } 
        public Board board; 

        public Cockroach(Board b)
        {
            Random random = new Random();
            this.board = b; 
            XPosition = random.Next(1, b.Boardwidth-2);
            YPosition = random.Next(1, b.Boardheight - 2);
            Icon = '$';
        }

        public void GenerateNewPosition()
        {
            Random random = new Random();
            XPosition = random.Next(1, board.Boardwidth - 2);
            YPosition = random.Next(1, board.Boardheight - 2);
        }

        public void DrawCockroach()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.Write(Icon.ToString());
        }

         
    }

}

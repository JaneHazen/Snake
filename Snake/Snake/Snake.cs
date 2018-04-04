using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{

    public class Snake
    {
        public int XPosition;
        public int YPosition;
        public int Length;
        public string SnakeHead;
        public string SnakeBody;

       public Snake()
        {
            XPosition = 0;
            YPosition = 0;
            Length = 1;
            SnakeHead = "0";
            SnakeBody = "~";
        }

        public void DrawSnake()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.WriteLine(SnakeHead);
        }

        public void AddToSnake()
        {
            SnakeHead += SnakeBody;
        }
    }
}

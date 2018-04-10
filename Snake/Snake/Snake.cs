using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interfaces;

namespace Snake
{

    public class Snake : ISnake 
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Length { get; set; }
        public string SnakeHead { get; private set; }
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

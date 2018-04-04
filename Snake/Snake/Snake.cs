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
        public string SnakeHead;
        public char SnakeBody;

       public Snake()
        {
            XPosition = 0;
            YPosition = 0;
            SnakeHead = "囧";
            SnakeBody = '\u0472';
        }

        public void DrawSnake()
        {
            Console.SetCursorPosition(XPosition, YPosition);
            Console.WriteLine(SnakeHead);
        }

        public void AddToSnake()
        {
            SnakeHead += SnakeBody.ToString();
        }
    }
}

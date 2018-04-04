using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Program
    {
   
        public Snake snake;
        public Board board;
        
        public static void Main(string[] args)
        {
            Board board = new Board();
            Snake snake = new Snake();
            Game game = new Game(snake, board);
        }
      

    }
}

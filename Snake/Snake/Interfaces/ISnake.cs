using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Interfaces
{
    public interface ISnake
    {
        //gets xposition
        int XPosition { get; set; }
        //gets yposition
        int YPosition { get; set; }
        //gets length
        int Length { get; set;  }
        //gets snake icon
        string SnakeHead { get; }

        //draws snake
        void DrawSnake();
    }
}

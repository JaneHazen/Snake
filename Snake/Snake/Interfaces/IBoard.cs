using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Interfaces
{
    public interface IBoard
    {
        /// <summary>
        /// gets board width 
        /// </summary>
        int Boardwidth { get; }

        //gets board height
        int Boardheight { get; }

        // gets board composition icon
        char BoardComposition { get; }

        //draws board
        void DrawBoard();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interfaces;

namespace Snake
{
    class ConsoleOutputProvider : IOutputProvider
    {
        //writes line to console
        public void Write(string output)
        {
            Console.Write(output);
        }


        /// Write the output with a new line
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }

        // Create Title Bar
        public void CreateTitle(string output)
        {
            Console.Title = output;
        }

        // Set Foreground Color
        public void SetForegroundColor(ConsoleColor output)
        {
            Console.ForegroundColor = output; 
        }

        // Set Background Color
        public void SetBackgroundColor(ConsoleColor output)
        {
            Console.BackgroundColor = output;
        }

        // Set Cursor Position
        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        /// Write an empty new line
        public void WriteLine()
        {
            Console.WriteLine();
        }

        /// Clears console
        public void Clear()
        {
            Console.Clear();
        }
    }
}

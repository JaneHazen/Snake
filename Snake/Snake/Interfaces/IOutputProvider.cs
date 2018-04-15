using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Interfaces
{
    public interface IOutputProvider
    {

        /// Write the output
        void Write(string output);

        /// Write the output with a new line
        void WriteLine(string output);

        //Create a title
        void CreateTitle(string output);

        //Set Foreground Color
        void SetForegroundColor(ConsoleColor output);

        //Set Background Color
        void SetBackgroundColor(ConsoleColor output);

        //Set cursor position 
        void SetCursorPosition(int left, int top);

        /// Write an empty new line
        void WriteLine();

        /// Clear the output
        void Clear();
    }
}

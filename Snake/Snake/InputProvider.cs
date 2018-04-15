using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Interfaces;

namespace Snake
{
    class InputProvider : IInputProvider
    {
        public string Read()
        {
            // This function should read a line from the console and return it
            var input = Console.ReadLine();
            return input;
        }
    }
}

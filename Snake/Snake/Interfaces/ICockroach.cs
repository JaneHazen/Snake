using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Interfaces
{
    interface ICockroach
    {
        int XPosition { get;  }
        int YPosition { get; }
        char Icon { get;  }
        void GenerateNewPosition();
        void DrawCockroach();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLiveCommandLine
{
    struct CellStruct
    {
        private readonly int x, y;
        private readonly int? state;

        public CellStruct(int x, int y, int? state)
        {
            this.x = x;
            this.y = y;
            this.state = state;
        }

        public int GetX() 
        {
            return x;
        }

        public int GetY() 
        {
            return y;
        }

        public int? GetState() 
        {
            return state;
        }
    }
}

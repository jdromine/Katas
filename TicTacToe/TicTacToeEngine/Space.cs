using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeEngine
{
    public class Space
    {
        public int X { get; set;}

        public int Y {get; set; }

        public Player SpaceHolder { get; set; }

        public Space(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeTest.Model
{
    public class CubeSquare
    {
        public int X;
        public int Y;
        public string Colour;

        public CubeSquare(
            int x,
            int y,
            string colour)
        {
            X = x;
            Y= y;  
            Colour = colour;
        }
    }
}

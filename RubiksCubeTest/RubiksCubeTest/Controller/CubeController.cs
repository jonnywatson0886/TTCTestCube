using RubiksCubeTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeTest.Controller
{
    public class CubeController
    {
        private Cube cube;

        public CubeController()
        {
            cube = new Cube();
        }

        /// <summary>
        /// This will be used to move a row/column of squares in the direction passed in.
        /// </summary>
        /// <param name="side">The face used as the pivot</param>
        /// <param name="angle">The amount times to rotate to use</param>
        /// <param name="direction">The direction the user wants to go e.g. clockwise/anti clockwise</param>
        public void Rotate(
            FaceLocation side,
            int turns,
            string direction)
        {
            for (int itr = 1; itr <= turns; itr++)
            {
                if (direction == "ClockWise")
                {
                    cube.RotateClock(side);
                }
                else
                {
                    //cube = RotateAntiClock(side);
                }
            }
        }

        /// <summary>
        /// prints the cube to the console
        /// </summary>
        public void PrintCube()
        {
            PrintCubeFace(FaceLocation.Top);
            PrintMiddle();
            PrintCubeFace(FaceLocation.Bottom);
            Console.WriteLine();
            Console.WriteLine();
        }

        /// <summary>
        /// prints out a 3x3 grid with all the colours of the face as a letter to the console
        /// </summary>
        /// <param name="Face">the location on the cube to be printed</param>
        /// <exception cref="Exception">will throw if a square is missing from the face</exception>
        private void PrintCubeFace(FaceLocation Face)
        {
            var face = cube.GetFace(Face);
            for (int x = 0; x <= 2; x++)
            {
                System.Console.Write("   ");
                for (int y = 0; y <= 2; y++)
                {
                    var cubeSquare = face.Squares.Find(square => square.X == x && square.Y == y) ?? throw new Exception("SquareMissing");
                    System.Console.Write(cubeSquare.Colour);
                }
                if (x != 2)
                {
                    Console.WriteLine();
                }
            }
        }

        private void PrintMiddle()
        {
            var sides = new List<CubeFace>();
            sides.Add(cube._faces.Find(face => face.Location == FaceLocation.Left));
            sides.Add(cube._faces.Find(face => face.Location == FaceLocation.Front));
            sides.Add(cube._faces.Find(face => face.Location == FaceLocation.Right));
            sides.Add(cube._faces.Find(face => face.Location == FaceLocation.Back));
            Console.WriteLine();
            for (int itr = 0; itr <= 2; itr++)
            {                
                var adjustmentValue = itr * 3;
                foreach (var side in sides)
                {
                    for (int itr2 = 0; itr2 <= 2; itr2++)
                    {
                        var sqaureIndex = itr2 + adjustmentValue;
                        Console.Write($"{side.Squares[sqaureIndex].Colour}");
                    } 
                }
                Console.WriteLine();
            }
        }
    }
}

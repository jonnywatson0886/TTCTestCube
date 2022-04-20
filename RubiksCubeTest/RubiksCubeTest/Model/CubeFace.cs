using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeTest.Model
{
    /// <summary>
    /// The object used to store all the squares on one side of the cube at any given time
    /// </summary>
    public class CubeFace
    {
        public FaceLocation Location;

        public CubeFace? JoinedTop;
        public CubeFace? JoinedBottom;
        public CubeFace? JoinedLeft;
        public CubeFace? JoinedRight;

        public List<CubeSquare> Squares;

        public CubeFace(
               FaceLocation Location,
            string Colour)
        {
            this.Location = Location;
            Squares = new List<CubeSquare>();
            //this creates a 3x3 grid of squares as a single colour
            for (int x = 0; x <= 2 ; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    Squares.Add(new CubeSquare(x,y,Colour));   
                }
            }
        }

        public CubeFace(CubeFace oldFace)
        { 
            this.Squares = oldFace.Squares;
            this.Location = oldFace.Location;
            this.JoinedBottom = oldFace.JoinedBottom;
            this.JoinedTop = oldFace.JoinedTop;
            this.JoinedLeft = oldFace.JoinedLeft;
            this.JoinedRight = oldFace.JoinedRight;
        }
        /// <summary>
        /// uses a case switch to set the other faces a face would be connect to
        /// when looking at the said face head on
        /// </summary>
        public void SetJoinedSides(Cube cube)
        {
            switch (Location)
            { 
                case FaceLocation.Front:
                    JoinedTop = cube.GetFace(FaceLocation.Top);
                    JoinedBottom = cube.GetFace(FaceLocation.Bottom);
                    JoinedRight = cube.GetFace(FaceLocation.Right);
                    JoinedLeft = cube.GetFace(FaceLocation.Left);
                    break;

               case FaceLocation.Top:
                    JoinedTop = cube.GetFace(FaceLocation.Back);
                    JoinedBottom = cube.GetFace(FaceLocation.Front);
                    JoinedRight = cube.GetFace(FaceLocation.Right);
                    JoinedLeft = cube.GetFace(FaceLocation.Left);
                    break;

                case FaceLocation.Bottom:
                    JoinedTop = cube.GetFace(FaceLocation.Back);
                    JoinedBottom = cube.GetFace(FaceLocation.Front);  
                    JoinedRight = cube.GetFace(FaceLocation.Left);
                    JoinedLeft = cube.GetFace(FaceLocation.Right);
                    break;

                case FaceLocation.Left:
                    JoinedTop = cube.GetFace(FaceLocation.Top);
                    JoinedBottom = cube.GetFace(FaceLocation.Bottom);
                    JoinedRight = cube.GetFace(FaceLocation.Front);
                    JoinedLeft = cube.GetFace(FaceLocation.Back);
                    break;

                case FaceLocation.Right:
                    JoinedTop = cube.GetFace(FaceLocation.Top);
                    JoinedBottom = cube.GetFace(FaceLocation.Bottom);
                    JoinedRight = cube.GetFace(FaceLocation.Back);
                    JoinedLeft = cube.GetFace(FaceLocation.Front);
                    break;

                case FaceLocation.Back:
                    JoinedTop = cube.GetFace(FaceLocation.Top);
                    JoinedBottom = cube.GetFace(FaceLocation.Bottom);
                    JoinedRight = cube.GetFace(FaceLocation.Left);
                    JoinedLeft = cube.GetFace(FaceLocation.Right);
                    break;
            }
        }
    }
}

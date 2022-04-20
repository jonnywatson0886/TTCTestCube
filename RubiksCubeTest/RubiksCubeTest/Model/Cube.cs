namespace RubiksCubeTest.Model
{
    public class Cube
    {
        public List<CubeFace> _faces;

        public Cube()
        {
            _faces = CreateCubeFaces();
            SetFacesJoinedFaces();
        }

        private void SetFacesJoinedFaces()
        {
            foreach (var face in _faces)
            {
                face.SetJoinedSides(this);
            }
        }

        /// <summary>
        /// Creates a new cube in the solved state
        /// </summary>
        /// <returns>A list of cube Faces with colours</returns>
        private List<CubeFace> CreateCubeFaces()
        {
            var sides = new List<CubeFace>();
            sides.Add(new CubeFace(FaceLocation.Front, "G"));
            sides.Add(new CubeFace(FaceLocation.Right, "R"));
            sides.Add(new CubeFace(FaceLocation.Left, "O"));
            sides.Add(new CubeFace(FaceLocation.Top, "W"));
            sides.Add(new CubeFace(FaceLocation.Bottom, "Y"));
            sides.Add(new CubeFace(FaceLocation.Back, "B"));
            return sides;
        }

        public CubeFace GetFace(FaceLocation side)
        {
            return _faces.First(x => x.Location == side);
        }


        public void RotateClock(FaceLocation face)
        {
            var cubeFace = GetFace(face);            
            var changes = new List<ChangeColourInstruction>();

            //top
            changes.Add(CreateChangeInstruction(cubeFace.JoinedTop, 7, cubeFace.JoinedLeft, 1));
            changes.Add(CreateChangeInstruction(cubeFace.JoinedTop, 8, cubeFace.JoinedLeft, 4));
            changes.Add(CreateChangeInstruction(cubeFace.JoinedTop, 9, cubeFace.JoinedLeft, 7));

            //right
            changes.Add(CreateChangeInstruction(cubeFace.JoinedRight, 1, cubeFace.JoinedTop, 7));
            changes.Add(CreateChangeInstruction(cubeFace.JoinedRight, 4, cubeFace.JoinedTop, 8));
            changes.Add(CreateChangeInstruction(cubeFace.JoinedRight, 7, cubeFace.JoinedTop, 9));

            //left
            changes.Add(CreateChangeInstruction(cubeFace.JoinedLeft, 3, cubeFace.JoinedBottom, 7));
            changes.Add(CreateChangeInstruction(cubeFace.JoinedLeft, 6, cubeFace.JoinedBottom, 8));
            changes.Add(CreateChangeInstruction(cubeFace.JoinedLeft, 9, cubeFace.JoinedBottom, 9));

            //bottom
            changes.Add(CreateChangeInstruction(cubeFace.JoinedBottom, 1, cubeFace.JoinedRight, 1));
            changes.Add(CreateChangeInstruction(cubeFace.JoinedBottom, 2, cubeFace.JoinedRight, 4));
            changes.Add(CreateChangeInstruction(cubeFace.JoinedBottom, 3, cubeFace.JoinedRight, 7));

            ImplmentChanges(changes);             
        }

        private void ImplmentChanges(List<ChangeColourInstruction> changes)
        {
            foreach (var change in changes)
            {
                var face = GetFace(change.location);
                face.Squares[change.SquareIndex].Colour = change.Colour;
            }
        }

        /// <summary>
        /// sets the colour of the index square on a face to the colour of the source face indexed square
        /// </summary>
        /// <param name="targetFace">The face being changed</param>
        /// <param name="targetIndex">The index of the square being changed on the target face</param>
        /// <param name="SourceFace">The face being referanced</param>
        /// <param name="sourceIndex">The index of the square being referanced on the source face</param>
        private ChangeColourInstruction CreateChangeInstruction(
            CubeFace targetFace,
            int targetIndex,
            CubeFace SourceFace,
            int sourceIndex)
        { 
            var source = SourceFace.Squares[sourceIndex -1];

            return new ChangeColourInstruction()
            {
                location = targetFace.Location,
                SquareIndex = targetIndex -1,
                Colour = source.Colour,
            };
        }
    }

    internal class ChangeColourInstruction
    {
        public FaceLocation location { get; set; }
        public int SquareIndex { get; set; }
        public string Colour { get; set; }
    }
}

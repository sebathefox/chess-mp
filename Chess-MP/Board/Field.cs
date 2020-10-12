using Chess_MP.Pieces;

namespace Chess_MP.Board
{
    public class Field
    {
        private IPiece _occupant;

        public Field()
        {
            _occupant = null;
        }

        public IPiece Piece => _occupant;
    }
}
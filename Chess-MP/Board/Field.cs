using Chess_MP.Pieces;

namespace Chess_MP.Board
{
    /**
     * Contains the logic for fields.
     * @author Sebastain Davaris
     * @date 12-10-2020
     */
    public class Field
    {
        private IPiece _piece;

        public Field()
        {
            _piece = null;
        }

        /**
         * Gets the piece currently on the field.
         * @author Sebastian Davaris
         * @date 12-10-2020
         */
        public IPiece Piece => _piece;
    }
}
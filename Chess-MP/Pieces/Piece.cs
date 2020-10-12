using System.Collections.Generic;
using Chess_MP.Board;

namespace Chess_MP.Pieces
{
    public abstract class Piece
    {
        /**
         * Gets the fields this piece can move to.
         * @author Sebastian Davaris
         * @date 12-10-2020
         * @returns The possible moves.
         */
        protected abstract IEnumerable<Field> GetPossibleFields();

        /**
         * Returns the piece's colour
         * @author Sebastian Davaris
         * @date 12-10-2020
         */
        public GameColor Color { get; }
    }
}
using System.Collections.Generic;
using Chess_MP.Board;

namespace Chess_MP.Pieces
{
    /**
     * Interface containing all of the public properties and methods of a piece.
     * @author Sebastian Davaris
     * @date 12-10-2020
     */
    public interface IPiece
    {
        /**
         * Gets the fields this piece can move to.
         * @author Sebastian Davaris
         * @date 12-10-2020
         * @returns The possible moves.
         */
        IEnumerable<Field> GetPossibleFields();

        /**
         * Returns the piece's colour
         * @author Sebastian Davaris
         * @date 12-10-2020
         */
        GameColor Color { get; }
    }
}
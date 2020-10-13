using System.Collections.Generic;
using Chess_MP.Board;
using Chess_MP.Pieces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP
{
    public class TestPiece : Piece
    {
        /// <inheritdoc />
        public TestPiece(Game1 game, Texture2D texture, Vector2 position) : base(game, texture, position)
        {
        }

        /// <inheritdoc />
        protected override IEnumerable<Field> GetPossibleFields()
        {
            throw new System.NotImplementedException();
        }
    }
}
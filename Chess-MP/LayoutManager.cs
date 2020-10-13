using System.Collections.Generic;
using Chess_MP.Pieces;
using Microsoft.Xna.Framework;

namespace Chess_MP
{
    public static class LayoutManager
    {
        public static IEnumerable<Piece> Generate(Game1 game, Player player)
        {
            List<Piece> pieces = new List<Piece>();
            pieces.Add(new TestPiece(game, player, game.AssetManager.GetTexture("white-rook"), Vector2.One));

            return pieces;
        }
    }
}
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
            // pieces.Add(new TestPiece(game, player, game.AssetManager.GetTexture("white-rook"), Vector2.One));
            
            pieces.Add(new Pawn(game, player, new Vector2(0, 1)));

            return pieces;
        }
    }
}
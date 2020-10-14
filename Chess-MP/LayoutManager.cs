using System.Collections.Generic;
using System.Linq;
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
            
            // Start at top.
            if (player.Color == GameColor.Black)
            {
                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(game, player, new Vector2(i, 1)));
                    game[new Vector2(i, 1)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(i, 1)));
                }
            }
            // Start at bottom
            else if (player.Color == GameColor.White)
            {
                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(game, player, new Vector2(i, 6)));
                    game[new Vector2(i, 6)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(i, 6)));

                }
            }

            return pieces;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Chess_MP.Pieces;
using Chess_MP.States;
using Microsoft.Xna.Framework;

namespace Chess_MP
{
    public static class LayoutManager
    {
        public static IEnumerable<Piece> Generate(GameController game, Player player)
        {
            InGameState state = game.State as InGameState;

            List<Piece> pieces = new List<Piece>();
            // pieces.Add(new TestPiece(game, player, game.AssetManager.GetTexture("white-rook"), Vector2.One));
            
            // Start at top.
            if (player.Color == GameColor.Black)
            {
                pieces.Add(new King(game, player, new Vector2(4, 0)));

                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(game, player, new Vector2(i, 1)));
                    state[new Vector2(i, 1)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(i, 1)));
                }
            }
            // Start at bottom
            else if (player.Color == GameColor.White)
            {
                pieces.Add(new King(game, player, new Vector2(4, 7)));

                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(game, player, new Vector2(i, 6)));
                    state[new Vector2(i, 6)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(i, 6)));

                }
            }

            return pieces;
        }
    }
}
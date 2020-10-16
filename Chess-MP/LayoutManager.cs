using System;
using System.Collections.Generic;
using System.Linq;
using Chess_MP.Pieces;
using Chess_MP.States;
using Microsoft.Xna.Framework;

namespace Chess_MP
{
    public static class LayoutManager
    {
        public static IEnumerable<Piece> Generate(GameController gameController, GameColor color)
        {
            if (!gameController.IsInState<InGameState>())
            {
                throw new NotSupportedException("The game MUST be in the correct state to use run!");
            }
            
            InGameState state = gameController.State as InGameState;

            List<Piece> pieces = new List<Piece>();
            
            // Start at top.
            if (color == GameColor.Black)
            {
                pieces.Add(new King(gameController, color, new Vector2(4, 0)));
                state[new Vector2(4, 0)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(4, 0)));
                
                pieces.Add(new Rook(gameController, color, new Vector2(0, 0)));
                state[new Vector2(0, 0)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(0, 0)));
                
                pieces.Add(new Rook(gameController, color, new Vector2(7, 0)));
                state[new Vector2(7, 0)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(7, 0)));

                pieces.Add(new Knight(gameController, color, new Vector2(1, 0)));
                state[new Vector2(1, 0)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(1, 0)));

                pieces.Add(new Knight(gameController, color, new Vector2(6, 0)));
                state[new Vector2(6, 0)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(6, 0)));

                pieces.Add(new Bishop(gameController, color, new Vector2(5, 0)));
                state[new Vector2(5, 0)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(5, 0)));
                
                pieces.Add(new Bishop(gameController, color, new Vector2(2, 0)));
                state[new Vector2(2, 0)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(2, 0)));
                

                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(gameController, color, new Vector2(i, 1)));
                    state[new Vector2(i, 1)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(i, 1)));
                }
            }
            // Start at bottom
            else if (color == GameColor.White)
            {
                pieces.Add(new King(gameController, color, new Vector2(4, 7)));
                state[new Vector2(4, 7)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(4, 7)));

                pieces.Add(new Knight(gameController, color, new Vector2(1, 7)));
                state[new Vector2(1, 7)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(1, 7)));

                pieces.Add(new Knight(gameController, color, new Vector2(6, 7)));
                state[new Vector2(6, 7)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(6, 7)));

                pieces.Add(new Rook(gameController, color, new Vector2(0, 7)));
                state[new Vector2(0, 7)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(0, 7)));
                
                pieces.Add(new Rook(gameController, color, new Vector2(7, 7)));
                state[new Vector2(7, 7)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(7, 7)));
                
                pieces.Add(new Bishop(gameController, color, new Vector2(2, 7)));
                state[new Vector2(2, 7)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(2, 7)));
                
                pieces.Add(new Bishop(gameController, color, new Vector2(5, 7)));
                state[new Vector2(5, 7)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(5, 7)));
                
                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(gameController, color, new Vector2(i, 6)));
                    state[new Vector2(i, 6)].SetPiece(pieces.Find(piece => piece.Position == new Vector2(i, 6)));

                }
            }

            return pieces;
        }
    }
}
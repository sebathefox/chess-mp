using System;
using System.Collections.Generic;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    class Queen : Piece
    {
        public Queen(GameController gameController, GameColor color, Vector2 position) : base(gameController, color, gameController.Game.AssetManager.GetTexture(color.ToString().ToLower() + "-queen"), position)
        { }

        protected override IEnumerable<Hover> GetPossibleFields()
        {

            if (!GameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }

            InGameState state = GameController.State as InGameState;

            // Vector2 upLeft = state.PieceManager.OneUpLeft(position);
            // Vector2 upRight = state.PieceManager.OneUpRight(position);
            // Vector2 right = state.PieceManager.OneRight(position);
            // Vector2 down = state.PieceManager.OneDown(position);
            // Vector2 left = state.PieceManager.OneLeft(position);
            // Vector2 up = state.PieceManager.OneUp(position);
            // Vector2 downLeft = state.PieceManager.OneDownLeft(position);
            // Vector2 downRight = state.PieceManager.OneDownRight(position);
            //
            // while (state[right] != null)
            // {
            //     if (state[right].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, right));
            //     }
            //     else if (state.PieceManager.IsEnemies(this, state[right].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, right));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     right = state.PieceManager.OneRight(right);
            // }
            //
            // while (state[left] != null)
            // {
            //     if (state[left].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, left));
            //     }
            //     else if (state.PieceManager.IsEnemies(this, state[left].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, left));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     left = state.PieceManager.OneLeft(left);
            // }
            //
            // while (state[up] != null)
            // {
            //     if (state[up].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, up));
            //     }
            //     else if (state.PieceManager.IsEnemies(this, state[up].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, up));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     up = state.PieceManager.OneUp(up);
            // }
            //
            // while (state[down] != null)
            // {
            //     if (state[down].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, down));
            //     }
            //     else if (state.PieceManager.IsEnemies(this, state[down].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, down));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     down = state.PieceManager.OneDown(down);
            // }
            //
            // while (state[upLeft] != null)
            // {
            //     if (state[upLeft].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, upLeft));
            //     }
            //     else if (state.PieceManager.IsEnemies(this, state[upLeft].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, upLeft));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     upLeft = state.PieceManager.OneUpLeft(upLeft);
            // }
            //
            // while (state[upRight] != null)
            // {
            //     if (state[upRight].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, upRight));
            //     }
            //     else if (state.PieceManager.IsEnemies(this, state[upRight].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, upRight));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     upRight = state.PieceManager.OneUpRight(upRight);
            // }
            //
            // while (state[downLeft] != null)
            // {
            //     if (state[downLeft].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, downLeft));
            //     }
            //     else if (state.PieceManager.IsEnemies(this, state[downLeft].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, downLeft));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     downLeft = state.PieceManager.OneDownLeft(downLeft);
            // }
            //
            // while (state[downRight] != null)
            // {
            //     if (state[downRight].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, downRight));
            //     }
            //     else if (state.PieceManager.IsEnemies(this, state[downRight].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, downRight));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     downRight = state.PieceManager.OneDownRight(downRight);
            // }

            return hovers;
        }
    }
}

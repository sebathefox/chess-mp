using System;
using System.Collections.Generic;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class Rook : Piece
    {
        private bool _hasMoved;
        
        /// <inheritdoc />
        public Rook(GameController gameController, GameColor color, Vector2 position) : base(gameController, color, gameController.Game.AssetManager.GetTexture(color.ToString().ToLower() + "-rook"), position)
        {
            _hasMoved = false;
        }

        /// <inheritdoc />
        protected override IEnumerable<Hover> GetPossibleFields()
        {
            List<Hover> hovers = new List<Hover>();
            
            if (!GameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }
            
            InGameState state = GameController.State as InGameState;

            // Vector2 pos = Position;
            //
            // Vector2 right = state.PieceManager.OneRight(pos);
            // Vector2 left = state.PieceManager.OneLeft(pos);
            // Vector2 down = state.PieceManager.OneDown(pos);
            // Vector2 up = state.PieceManager.OneUp(pos);
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
            //
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
            //
            //     left = state.PieceManager.OneLeft(left);
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
            //
            //     down = state.PieceManager.OneDown(down);
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
            //
            //     up = state.PieceManager.OneUp(up);
            // }


            Vector2 pos = position;

            foreach (var VARIABLE in state.PieceManager.CanMoveUntil(new Vector2(0, 1), position, Vector2.Zero))
            {
                
            }
            
            return hovers;
        }
    }
}
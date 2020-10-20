using System;
using System.Collections.Generic;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class Bishop : Piece
    {
        /// <inheritdoc />
        public Bishop(GameController gameController, GameColor color, Vector2 position) : base(gameController, color, gameController.Game.AssetManager.GetTexture(color.ToString().ToLower() + "-bishop"), position)
        {
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
            // PieceManager man = state.PieceManager;
            //
            // Vector2 rightUp = man.OneUpRight(pos);
            // Vector2 leftUp = man.OneUpLeft(pos);
            // Vector2 rightDown = man.OneDownRight(pos);
            // Vector2 leftDown = man.OneDownLeft(pos);
            //
            // while (state[rightUp] != null)
            // {
            //     if (state[rightUp].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, rightUp));
            //     }
            //     else if (man.IsEnemies(this, state[rightUp].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, rightUp));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     rightUp = man.OneUpRight(rightUp);
            // }
            //
            // while (state[leftUp] != null)
            // {
            //     if (state[leftUp].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, leftUp));
            //     }
            //     else if (man.IsEnemies(this, state[leftUp].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, leftUp));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     leftUp = man.OneUpLeft(leftUp);
            // }
            //
            // while (state[rightDown] != null)
            // {
            //     if (state[rightDown].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, rightDown));
            //     }
            //     else if (man.IsEnemies(this, state[rightDown].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, rightDown));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     rightDown = man.OneDownRight(rightDown);
            // }
            //
            // while (state[leftDown] != null)
            // {
            //     if (state[leftDown].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, leftDown));
            //     }
            //     else if (man.IsEnemies(this, state[leftDown].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, leftDown));
            //         break;
            //     }
            //     else
            //     {
            //         break;
            //     }
            //     leftDown = man.OneDownLeft(leftDown);
            // }
            
            return hovers;
        }
    }
}
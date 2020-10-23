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

            foreach (Vector2 vector in state.PieceManager.CanMoveUntil(state.PieceManager.DownLeft, position))
            {
                hovers.Add(new Hover(GameController.Game, vector));
            }

            foreach (Vector2 vector in state.PieceManager.CanMoveUntil(state.PieceManager.UpLeft, position))
            {
                hovers.Add(new Hover(GameController.Game, vector));
            }

            foreach (Vector2 vector in state.PieceManager.CanMoveUntil(state.PieceManager.UpRight, position))
            {
                hovers.Add(new Hover(GameController.Game, vector));
            }

            foreach (Vector2 vector in state.PieceManager.CanMoveUntil(state.PieceManager.DownRight, position))
            {
                hovers.Add(new Hover(GameController.Game, vector));
            }

            return hovers;
        }
    }
}
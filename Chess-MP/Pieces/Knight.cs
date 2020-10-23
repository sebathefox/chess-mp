using System;
using System.Collections.Generic;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    class Knight : Piece
    {
        public Knight(GameController gameController, GameColor color, Vector2 position) : base(gameController, color, gameController.Game.AssetManager.GetTexture(color.ToString().ToLower() + "-knight"), position)
        { }

        protected override IEnumerable<Hover> GetPossibleFields()
        {
            List<Hover> hovers = new List<Hover>();
            if (!GameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }

            InGameState state = GameController.State as InGameState;

           Hover hover;
            if ((hover = state.PieceManager.CanMove(state.PieceManager.KnUpLeft, position)) != null)
            {
                hovers.Add(hover);
            }

            if ((hover = state.PieceManager.CanMove(state.PieceManager.KnUpRight, position)) != null)
            {
                hovers.Add(hover);
            }

            if ((hover = state.PieceManager.CanMove(state.PieceManager.KnLeftUp, position)) != null)
            {
                hovers.Add(hover);
            }

            if ((hover = state.PieceManager.CanMove(state.PieceManager.KnLeftDown, position)) != null)
            {
                hovers.Add(hover);
            }

            if ((hover = state.PieceManager.CanMove(state.PieceManager.KnDownRight, position)) != null)
            {
                hovers.Add(hover);
            }

            if ((hover = state.PieceManager.CanMove(state.PieceManager.KnDownLeft, position)) != null)
            {
                hovers.Add(hover);
            }

            if ((hover = state.PieceManager.CanMove(state.PieceManager.KnRightDown, position)) != null)
            {
                hovers.Add(hover);
            }

            if ((hover = state.PieceManager.CanMove(state.PieceManager.KnRightUp, position)) != null)
            {
                hovers.Add(hover);
            }

            return hovers;
        }
    }
}

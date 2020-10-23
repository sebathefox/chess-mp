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

            foreach (Vector2 vector in state.PieceManager.CanMoveUntil(state.PieceManager.Down, position))
            {
                hovers.Add(new Hover(GameController.Game, vector));
            }
            
            foreach (Vector2 vector in state.PieceManager.CanMoveUntil(state.PieceManager.Left, position))
            {
                hovers.Add(new Hover(GameController.Game, vector));
            }
            
            foreach (Vector2 vector in state.PieceManager.CanMoveUntil(state.PieceManager.Up, position))
            {
                hovers.Add(new Hover(GameController.Game, vector));
            }
            
            foreach (Vector2 vector in state.PieceManager.CanMoveUntil(state.PieceManager.Right, position))
            {
                hovers.Add(new Hover(GameController.Game, vector));
            }
            
            return hovers;
        }

        protected override void OnHoverClicked(object sender, Vector2 pos)
        {
            base.OnHoverClicked(sender, pos);
            _hasMoved = true;
        }
    }
}
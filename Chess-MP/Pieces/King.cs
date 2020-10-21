using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class King : Piece, ISerializable
    {

        private bool _hasMoved;

        public King(GameController gameController, GameColor color, Vector2 position) : base(gameController, color, gameController.Game.AssetManager.GetTexture(color.ToString().ToLower() + "-king"), position)
        {
            _hasMoved = false;
        }

        

        protected override IEnumerable<Hover> GetPossibleFields()
        {
            List<Hover> hovers = new List<Hover>();
            if (!GameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }
            
            InGameState state = GameController.State as InGameState;


            Hover hover;
            if ((hover = state.PieceManager.CanMove(state.PieceManager.Up, position)) != null)
                hovers.Add(hover);

            if ((hover = state.PieceManager.CanMove(state.PieceManager.UpLeft, position)) != null)
                hovers.Add(hover);

            if ((hover = state.PieceManager.CanMove(state.PieceManager.Left, position)) != null)
                hovers.Add(hover);

            if ((hover = state.PieceManager.CanMove(state.PieceManager.DownLeft, position)) != null)
                hovers.Add(hover);

            if ((hover = state.PieceManager.CanMove(state.PieceManager.Down, position)) != null)
                hovers.Add(hover);

            if ((hover = state.PieceManager.CanMove(state.PieceManager.DownRight, position)) != null)
                hovers.Add(hover);

            if ((hover = state.PieceManager.CanMove(state.PieceManager.Right, position)) != null)
                hovers.Add(hover);

            if ((hover = state.PieceManager.CanMove(state.PieceManager.UpRight, position)) != null)
                hovers.Add(hover);

            return hovers;
        }

       

        protected override void OnHoverClicked(object sender, Vector2 pos)
        {
            base.OnHoverClicked(sender, pos);
            _hasMoved = true;
        }
    }
}

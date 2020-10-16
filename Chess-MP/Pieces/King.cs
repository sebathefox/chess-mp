using System;
using System.Collections.Generic;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class King : Piece
    {

        private bool _hasMoved;

        public King(GameController gameController, GameColor color, Vector2 position) : base(gameController, color, gameController.Game.AssetManager.GetTexture(color.ToString().ToLower() + "-king"), position)
        {
            _hasMoved = false;
        }


        protected override IEnumerable<Hover> GetPossibleFields()
        {
            if (!GameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }
            
            InGameState state = GameController.State as InGameState;
            
            List<Hover> hovers = new List<Hover>();

            if (state.PieceManager.IsOnTop(this.position) && state.PieceManager.IsOnRight(this.position))
            {
                
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDown(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneLeft(position)));

                
            }
            else if (state.PieceManager.IsOnTop(position) && state.PieceManager.IsOnLeft(position))
            {
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDown(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneRight(position)));
            }
            else if (state.PieceManager.IsOnBottom(position) && state.PieceManager.IsOnRight(position))
            {
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUp(position)));
            }
            else if (state.PieceManager.IsOnBottom(position) && state.PieceManager.IsOnLeft(position))
            {
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUp(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpRight(position)));
            }
            else if (state.PieceManager.IsOnRight(position))
            {
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUp(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDown(position)));
            }
            else if (state.PieceManager.IsOnLeft(position))
            {
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUp(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDown(position)));
            }
            else if (state.PieceManager.IsOnTop(position))
            {
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDown(position)));
            }
            else if (state.PieceManager.IsOnBottom(position))
            {
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUp(position)));
            }
            else
            {
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDown(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUp(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpLeft(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownRight(position)));
                hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownLeft(position)));
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

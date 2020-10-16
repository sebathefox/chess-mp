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

            Vector2 left = state.PieceManager.OneLeft(position);
            Vector2 right = state.PieceManager.OneRight(position);
            Vector2 up = state.PieceManager.OneUp(position);
            Vector2 down = state.PieceManager.OneDown(position);
            Vector2 upLeft = state.PieceManager.OneUpLeft(position);
            Vector2 upRight = state.PieceManager.OneUpRight(position);
            Vector2 downLeft = state.PieceManager.OneDownLeft(position);
            Vector2 downRight = state.PieceManager.OneDownRight(position);

            List<Hover> hovers = new List<Hover>();

            if (!(state.PieceManager.IsOnTop(this.position) && state.PieceManager.IsOnRight(this.position)))
            {
                if(state[upRight].Piece == null || state.PieceManager.IsEnemies(this, state[upRight].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpRight(position)));
                }   
            }
            if (!(state.PieceManager.IsOnTop(this.position) && state.PieceManager.IsOnLeft(this.position)))
            {
                if (state[upLeft].Piece == null || state.PieceManager.IsEnemies(this, state[upLeft].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUpLeft(position)));
                }
            }
            if (!(state.PieceManager.IsOnTop(this.position)))
            {
                if (state[up].Piece == null || state.PieceManager.IsEnemies(this, state[up].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, state.PieceManager.OneUp(position)));
                }
            }
            if (!(state.PieceManager.IsOnRight(this.position)))
            {
                if (state[right].Piece == null || state.PieceManager.IsEnemies(this, state[right].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, state.PieceManager.OneRight(position)));
                }
            }
            if (!(state.PieceManager.IsOnBottom(this.position) && state.PieceManager.IsOnRight(this.position)))
            {
                if (state[downRight].Piece == null || state.PieceManager.IsEnemies(this, state[downRight].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownRight(position)));
                }
            }
            if (!(state.PieceManager.IsOnBottom(this.position)))
            {
                if (state[down].Piece == null || state.PieceManager.IsEnemies(this, state[down].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDown(position)));
                }
            }
            if (!(state.PieceManager.IsOnBottom(this.position) && state.PieceManager.IsOnLeft(this.position)))
            {
                if (state[downLeft].Piece == null || state.PieceManager.IsEnemies(this, state[downLeft].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, state.PieceManager.OneDownLeft(position)));
                }
            }
            if (!(state.PieceManager.IsOnLeft(this.position)))
            {
                if (state[left].Piece == null || state.PieceManager.IsEnemies(this, state[left].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, state.PieceManager.OneLeft(position)));
                }

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

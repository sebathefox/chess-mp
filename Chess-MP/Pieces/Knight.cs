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

            if (!GameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }

            InGameState state = GameController.State as InGameState;

            // Vector2 upLeft = state.PieceManager.KnUpLeft(position);
            // Vector2 upRight = state.PieceManager.KnUpRight(position);
            // Vector2 rightUp = state.PieceManager.KnRightUp(position);
            // Vector2 rightDown = state.PieceManager.KnRightDown(position);
            // Vector2 leftUp = state.PieceManager.KnLeftUp(position);
            // Vector2 leftDown = state.PieceManager.KnLeftDown(position);
            // Vector2 downLeft = state.PieceManager.KnDownLeft(position);
            // Vector2 downRight = state.PieceManager.KnDownRight(position);
            //
            // List<Hover> hovers = new List<Hover>();
            //
            // if (!(state.PieceManager.IsOnTop(this.position, 1) && state.PieceManager.IsOnLeft(this.position)))
            // {
            //     if (state[upLeft].Piece == null || state.PieceManager.IsEnemies(this, state[upLeft].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, state.PieceManager.KnUpLeft(position)));
            //     }
            // }
            //
            // if (!(state.PieceManager.IsOnTop(this.position, 1) && state.PieceManager.IsOnRight(this.position)))
            // {
            //     if (state[upRight].Piece == null || state.PieceManager.IsEnemies(this, state[upRight].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, state.PieceManager.KnUpRight(position)));
            //     }
            // }
            //
            // if (!(state.PieceManager.IsOnTop(this.position) && state.PieceManager.IsOnRight(this.position, 1)))
            // {
            //     if (state[rightUp].Piece == null || state.PieceManager.IsEnemies(this, state[rightUp].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, state.PieceManager.KnRightUp(position)));
            //     }
            // }
            //
            // if (!(state.PieceManager.IsOnBottom(this.position) && state.PieceManager.IsOnRight(this.position, 1)))
            // {
            //     if (state[rightDown].Piece == null || state.PieceManager.IsEnemies(this, state[rightDown].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, state.PieceManager.KnRightDown(position)));
            //     }
            // }
            //
            // if (!(state.PieceManager.IsOnBottom(this.position, 1) && state.PieceManager.IsOnRight(this.position)))
            // {
            //     if (state[downRight].Piece == null || state.PieceManager.IsEnemies(this, state[downRight].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, state.PieceManager.KnDownRight(position)));
            //     }
            // }
            //
            // if (!(state.PieceManager.IsOnBottom(this.position, 1) && state.PieceManager.IsOnLeft(this.position)))
            // {
            //     if (state[downLeft].Piece == null || state.PieceManager.IsEnemies(this, state[downLeft].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, state.PieceManager.KnDownLeft(position)));
            //     }
            // }
            //
            // if (!(state.PieceManager.IsOnBottom(this.position) && state.PieceManager.IsOnLeft(this.position, 1)))
            // {
            //     if (state[leftDown].Piece == null || state.PieceManager.IsEnemies(this, state[leftDown].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, state.PieceManager.KnLeftDown(position)));
            //     }
            // }
            //
            // if (!(state.PieceManager.IsOnTop(this.position) && state.PieceManager.IsOnLeft(this.position, 1)))
            // {
            //     if (state[leftUp].Piece == null || state.PieceManager.IsEnemies(this, state[leftUp].Piece))
            //     {
            //         hovers.Add(new Hover(GameController.Game, state.PieceManager.KnLeftUp(position)));
            //     }
            // }

            return hovers;
        }
    }
}

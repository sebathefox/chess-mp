using System;
using System.Collections.Generic;
using System.Linq;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    public class Pawn : Piece
    {
        private bool _hasMoved;
        
        /// <inheritdoc />
        public Pawn(GameController gameController, GameColor color, Vector2 position) : base(gameController, color, gameController.Game.AssetManager.GetTexture(color.ToString().ToLower() + "-pawn"), position)
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

            // Vector2 front = state.PieceManager.OneFront(position);

            Vector2 front = position;
            Vector2 frontPlus = front;

            switch (Color)
            {
                case GameColor.Black:
                    front = new Vector2(0, 1);
                    frontPlus = new Vector2(0, 2);
                    break;
                case GameColor.White:
                    front = new Vector2(0, -1);
                    frontPlus = new Vector2(0, -2);
                    break;
            }

            //
            // Vector2 left = state.PieceManager.OneLeft(front);
            // Vector2 right = state.PieceManager.OneRight(front);
            //
            // // Console.WriteLine(front.ToString());
            //
            // if (!(state.PieceManager.IsOnBottom(this.position) || state.PieceManager.IsOnTop(this.position)) && state[front].Piece == null)
            // {
            //     hovers.Add(new Hover(GameController.Game, front));
            //
            //     switch (Color)
            //     {
            //         case GameColor.Black:
            //             front = new Vector2(front.X, front.Y + 1);
            //             break;
            //         case GameColor.White:
            //             front = new Vector2(front.X, front.Y - 1);
            //             break;
            //     }
            //
            //     if (!_hasMoved  && state[front].Piece == null)
            //     {
            //         hovers.Add(new Hover(GameController.Game, front));
            //     }
            // }
            //
            // if (!(state.PieceManager.IsOnBottom(this.position) || state.PieceManager.IsOnTop(this.position)) && !state.PieceManager.IsOnLeft(this.position) && state[left].Piece != null && state.PieceManager.IsEnemies(this, state[left].Piece))
            // {
            //     hovers.Add(new Hover(GameController.Game, left));
            // }
            //
            // if (!(state.PieceManager.IsOnBottom(this.position) || state.PieceManager.IsOnTop(this.position)) && !state.PieceManager.IsOnRight(this.position) && state[right].Piece != null && state.PieceManager.IsEnemies(this, state[right].Piece))
            // {
            //     hovers.Add(new Hover(GameController.Game, right));
            // }


            // int i = 0;
            // foreach (Vector2 vector in state.PieceManager.CanMoveUntil(front, position))
            // {
            //     Console.WriteLine(vector);
            //     hovers.Add(new Hover(GameController.Game, vector));
            //
            //     if (i >= 2)
            //     {
            //         break;
            //     }
            //     
            //     i++;
            // }

            hovers.Add(state.PieceManager.CanMove(front, position));
            hovers.Add(state.PieceManager.CanMove(frontPlus, position));
            
            Hover hover;
            if((hover = state.PieceManager.CanMove(new Vector2(-1, 0), position + front, true)) != null)
            {
                hovers.Add(hover);                
            }
            
            if((hover = state.PieceManager.CanMove(new Vector2(1, 0), position + front, true)) != null)
            {
                hovers.Add(hover);                
            }
            
            return hovers;
        }

        /// <inheritdoc />
        protected override void OnHoverClicked(object sender, Vector2 pos)
        {
            base.OnHoverClicked(sender, pos);
            _hasMoved = true;
        }
    }
}
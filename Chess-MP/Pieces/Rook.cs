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

            Vector2 pos = Position;

            Vector2 right = new Vector2(pos.X + 1, pos.Y);
            Vector2 left = new Vector2(pos.X - 1, pos.Y);
            Vector2 down = new Vector2(pos.X, pos.Y + 1);
            Vector2 up = new Vector2(pos.X, pos.Y - 1);
            
            while (state[right] != null)
            {
                if (state[right].Piece == null)
                {
                    hovers.Add(new Hover(GameController.Game, right));
                }
                else if (state.PieceManager.IsEnemies(this, state[right].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, right));
                    break;
                }
                else
                {
                    break;
                }
                right.X += 1;
            }
            
            while (state[left] != null)
            {
                if (state[left].Piece == null)
                {
                    hovers.Add(new Hover(GameController.Game, left));
                }
                else if (state.PieceManager.IsEnemies(this, state[left].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, left));
                    break;
                }
                else
                {
                    break;
                }
                left.X -= 1;
            }
            
            while (state[down] != null)
            {
                if (state[down].Piece == null)
                {
                    hovers.Add(new Hover(GameController.Game, down));
                }
                else if (state.PieceManager.IsEnemies(this, state[down].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, down));
                    break;
                }
                else
                {
                    break;
                }
                down.Y += 1;
            }
            
            while (state[up] != null)
            {
                if (state[up].Piece == null)
                {
                    hovers.Add(new Hover(GameController.Game, up));
                }
                else if (state.PieceManager.IsEnemies(this, state[up].Piece))
                {
                    hovers.Add(new Hover(GameController.Game, up));
                    break;
                }
                else
                {
                    break;
                }
                up.Y -= 1;
            }

            return hovers;
        }
    }
}
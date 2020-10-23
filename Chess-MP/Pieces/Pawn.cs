using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Chess_MP.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Chess_MP.Pieces
{
    [Serializable]
    public class Pawn : Piece, ISerializable
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
            
            Hover hover;
            if (state.Fields.First(field => field.Id == position + front).Piece == null)
            {
                if ((hover = state.PieceManager.CanMove(front, position)) != null)
                {
                    hovers.Add(hover);
                }

                if (!_hasMoved && state.Fields.First(field => field.Id == position + frontPlus).Piece == null)
                {
                    if ((hover = state.PieceManager.CanMove(frontPlus, position)) != null)
                    {
                        hovers.Add(hover);
                    }
                }
            }

            if ((hover = state.PieceManager.CanMove(new Vector2(-1, 0), position + front, true)) != null)
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
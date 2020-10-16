using System;
using System.Collections.Generic;
using System.Linq;
using Chess_MP.Board;
using Chess_MP.Pieces;
using Chess_MP.States;
using Microsoft.Xna.Framework;

namespace Chess_MP
{
    public class PieceManager
    {
        private GameController _gameController;
        private Dictionary<GameColor, List<Piece>> _playerPieces;

        public PieceManager(GameController controller)
        {
            _gameController = controller;
            
            _playerPieces = new Dictionary<GameColor, List<Piece>>();
            _playerPieces.Add(GameColor.White, new List<Piece>(LayoutManager.Generate(controller, GameColor.White)));
            _playerPieces.Add(GameColor.Black, new List<Piece>(LayoutManager.Generate(controller, GameColor.Black)));
        }

        public void MovePiece(Piece piece, Vector2 targetPosition)
        {
            if (!_gameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }
            
            InGameState state = _gameController.State as InGameState;

            // First we remove the piece from the old position.
            state[piece.Position].SetPiece(null);
            
            // Then places it on the new one.
            Field field = state.Fields.First(field1 => field1.Id == targetPosition);
            
            field.SetPiece(piece);
        }

        public void KillPiece(Piece piece)
        {
            if (!_gameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }
            
            InGameState state = _gameController.State as InGameState;

            _playerPieces[piece.Color].Remove(piece);
            piece.ClearHovers();
            piece.Disable();
            
            state[piece.Position].SetPiece(null);
        }
        
        public Piece GetPieceOnPosition(Vector2 position)
        {
            if (!_gameController.IsInGame())
            {
                throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }
            
            InGameState state = _gameController.State as InGameState;

            return state[position].Piece;
        }
        
        #region Stuff
        
        /**
         * Validates if the other piece is a enemy.
         * @param other The other Piece.
         * @author Sebastian Davaris
         * @date 15-10-2020
         */
        public bool IsEnemies(Piece first, Piece other)
        {
            if (other == null)
                return false;
            
            return first.Color != other.Color;
        }
        
        // protected Vector2 OneFront(Vector2 @base)
        // {
        //     switch (direction)
        //     {
        //         case Direction.Down:
        //             return new Vector2(@base.X, @base.Y + 1);
        //         default:
        //             return new Vector2(@base.X, @base.Y - 1);
        //     }
        // }
        
        public Vector2 OneLeft(Vector2 @base)
        {
            if (@base.X < 1)
                return @base;
            
            return new Vector2(@base.X - 1, @base.Y);
        }
        
        public Vector2 OneRight(Vector2 @base)
        {
            if (@base.X >= 7)
                return @base;
            
            return new Vector2(@base.X + 1, @base.Y);
        }
        
        public Vector2 OneUp(Vector2 @base)
        {
            if (@base.Y < 1)
                return @base;
        
            return new Vector2(@base.X, @base.Y - 1);
        }
        
        public Vector2 OneDown(Vector2 @base)
        {
            if (@base.Y >= 7)
                return @base;
        
            return new Vector2(@base.X, @base.Y + 1);
        }
        
        public Vector2 OneUpLeft(Vector2 @base)
        {
            if (@base.Y < 1 || @base.X < 1)
                return @base;
        
            return new Vector2(@base.X - 1, @base.Y - 1);
        }
        
        public Vector2 OneUpRight(Vector2 @base)
        {
            if (@base.Y < 1 || @base.X >= 7)
                return @base;
        
            return new Vector2(@base.X + 1, @base.Y - 1);
        }
        
        public Vector2 OneDownLeft(Vector2 @base)
        {
            if (@base.Y >= 7 || @base.X < 1)
                return @base;
        
            return new Vector2(@base.X - 1, @base.Y + 1);
        }
        
        public Vector2 OneDownRight(Vector2 @base)
        {
            if (@base.Y >= 7 || @base.X >= 7)
                return @base;
        
            return new Vector2(@base.X + 1, @base.Y + 1);
        }
        
        public bool IsOnLeft(Vector2 position)
        {
            return position.X <= 0;
        }
        
        public bool IsOnRight(Vector2 position)
        {
            return position.X >= 7;
        }
        
        public bool IsOnTop(Vector2 position)
        {
            return position.Y <= 0;
        }
        
        public bool IsOnBottom(Vector2 position)
        {
            return position.Y >= 7;
        }
        
        #endregion
    }
}
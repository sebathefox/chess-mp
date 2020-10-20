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

        private Piece _currentPiece;
        
        public PieceManager(GameController controller)
        {
            _gameController = controller;
            
            _playerPieces = new Dictionary<GameColor, List<Piece>>();
            _playerPieces.Add(GameColor.White, new List<Piece>(LayoutManager.Generate(controller, GameColor.White)));
            _playerPieces.Add(GameColor.Black, new List<Piece>(LayoutManager.Generate(controller, GameColor.Black)));

            _currentPiece = null;
        }

        public void MovePiece(Piece piece, Vector2 targetPosition)
        {
            if (!_gameController.IsInGame())
            {
                return;
                // throw new NotSupportedException("You MUST be in the correct state to move a piece!");
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
                return;
                // throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }
            
            InGameState state = _gameController.State as InGameState;

            
            
            _playerPieces[piece.Color].Remove(piece);
            piece.ClearHovers();
            piece.Disable();
            
            state[piece.Position].SetPiece(null);
            
            if (piece is King)
            {
                state.GameEnded();
            }
        }
        
        public Piece GetPieceOnPosition(Vector2 position)
        {
            if (!_gameController.IsInGame())
            {
                return null;
                // throw new NotSupportedException("You MUST be in the correct state to move a piece!");
            }
            
            InGameState state = _gameController.State as InGameState;

            return state[position].Piece;
        }

        public Piece CurrentPiece
        {
            get => _currentPiece;
            set
            {
                if(_currentPiece != null || _currentPiece == value)
                   _currentPiece.ClearHovers();
                _currentPiece = value;
            }
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

        public List<Vector2> CanMoveUntil(Vector2 direction, Vector2 normal, Vector2 max)
        {
            List<Vector2> list = new List<Vector2>();
            
            while (normal.X < 8 &&
                   normal.X >= 0 &&
                   normal.Y < 8 &&
                   normal.Y >= 0)
            {
                
                normal += direction;
                
                if ((normal.X == max.X &&
                     normal.Y == max.Y) ||
                    GetPieceOnPosition(normal) != null)
                {
                    break;
                }

                if (GetPieceOnPosition(normal) == null)
                {
                    list.Add(normal);
                }
            }

            return list;
        }
        
        public Vector2 Up = new Vector2(0, 1);
        public Vector2 UpLeft = new Vector2(1, 1);
        public Vector2 Left = new Vector2(1, 0);
        public Vector2 DownLeft = new Vector2(-1, 1);
        public Vector2 Down = new Vector2(-1, 0);
        public Vector2 DownRight = new Vector2(-1, -1);
        public Vector2 Right = new Vector2(0, -1);
        public Vector2 UpRight = new Vector2(1, -1);

        // public Vector2 OneLeft(Vector2 @base)
        // {
        //     // if (@base.X < 1)
        //     //     return @base;
        //     
        //     return new Vector2(@base.X - 1, @base.Y);
        // }
        //
        // public Vector2 OneRight(Vector2 @base)
        // {
        //     // if (@base.X >= 7)
        //     //     return @base;
        //     
        //     return new Vector2(@base.X + 1, @base.Y);
        // }
        //
        // public Vector2 OneUp(Vector2 @base)
        // {
        //     // if (@base.Y < 1)
        //     //     return @base;
        //
        //     return new Vector2(@base.X, @base.Y - 1);
        // }
        //
        // public Vector2 OneDown(Vector2 @base)
        // {
        //     // if (@base.Y >= 7)
        //     //     return @base;
        //
        //     return new Vector2(@base.X, @base.Y + 1);
        // }
        //
        // public Vector2 OneUpLeft(Vector2 @base)
        // {
        //     // if (@base.Y < 1 || @base.X < 1)
        //     //     return @base;
        //
        //     return new Vector2(@base.X - 1, @base.Y - 1);
        // }
        //
        // public Vector2 OneUpRight(Vector2 @base)
        // {
        //     // if (@base.Y < 1 || @base.X >= 7)
        //     //     return @base;
        //
        //     return new Vector2(@base.X + 1, @base.Y - 1);
        // }
        //
        // public Vector2 OneDownLeft(Vector2 @base)
        // {
        //     // if (@base.Y >= 7 || @base.X < 1)
        //     //     return @base;
        //
        //     return new Vector2(@base.X - 1, @base.Y + 1);
        // }
        //
        // public Vector2 OneDownRight(Vector2 @base)
        // {
        //     // if (@base.Y >= 7 || @base.X >= 7)
        //     //     return @base;
        //
        //     return new Vector2(@base.X + 1, @base.Y + 1);
        // }
        //
        // public bool IsOnLeft(Vector2 position, int offset = 0)
        // {
        //     return position.X - offset <= 0;
        // }
        //
        // public bool IsOnRight(Vector2 position, int offset = 0)
        // {
        //     return position.X + offset >= 7;
        // }
        //
        // public bool IsOnTop(Vector2 position, int offset = 0)
        // {
        //     return position.Y - offset <= 0;
        // }
        //
        // public bool IsOnBottom(Vector2 position, int offset = 0)
        // {
        //     return position.Y + offset >= 7;
        // }

        public Vector2 KnUpLeft(Vector2 @base)
        {
            if (@base.Y < 2 || @base.X < 1)
                return @base;

            return new Vector2(@base.X - 1, @base.Y - 2);
        }

        public Vector2 KnUpRight(Vector2 @base)
        {
            if (@base.Y < 2 || @base.X >= 7)
                return @base;

            return new Vector2(@base.X + 1, @base.Y - 2);
        }

        public Vector2 KnDownRight(Vector2 @base)
        {
            if (@base.Y >= 6 || @base.X >= 7)
                return @base;

            return new Vector2(@base.X + 1, @base.Y + 2);
        }

        public Vector2 KnDownLeft(Vector2 @base)
        {
            if (@base.Y >= 6 || @base.X < 1)
                return @base;

            return new Vector2(@base.X - 1, @base.Y + 2);
        }

        public Vector2 KnLeftDown(Vector2 @base)
        {
            if (@base.Y >= 7 || @base.X < 2)
                return @base;

            return new Vector2(@base.X - 2, @base.Y + 1);
        }

        public Vector2 KnLeftUp(Vector2 @base)
        {
            if (@base.Y < 1 || @base.X < 2)
                return @base;

            return new Vector2(@base.X - 2, @base.Y - 1);
        }


        public Vector2 KnRightUp(Vector2 @base)
        {
            if (@base.Y < 1 || @base.X >= 6)
                return @base;

            return new Vector2(@base.X + 2, @base.Y - 1);
        }

        public Vector2 KnRightDown(Vector2 @base)
        {
            if (@base.Y >= 7 || @base.X >= 6)
                return @base;

            return new Vector2(@base.X + 2, @base.Y + 1);
        }

        public void Clear()
        {
            foreach (KeyValuePair<GameColor,List<Piece>> pair in _playerPieces)
            {
                foreach (Piece piece in pair.Value)
                {
                    piece.Delete();
                }
            }
            
            _currentPiece = null;
            _playerPieces = null;
        }

        #endregion
    }
}
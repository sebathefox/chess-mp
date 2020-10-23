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

        public List<Vector2> CanMoveUntil(Vector2 direction, Vector2 normal)
        {
            List<Vector2> list = new List<Vector2>();
            
            normal += direction;
            
            while (normal.X < 8 &&
                   normal.X >= 0 &&
                   normal.Y < 8 &&
                   normal.Y >= 0)
            {

                if (GetPieceOnPosition(normal) == null)
                {
                    list.Add(normal);
                }
                
                if (GetPieceOnPosition(normal) != null && GetPieceOnPosition(normal).Color != _currentPiece.Color)
                {
                    list.Add(normal);
                    break;
                }
                else if (GetPieceOnPosition(normal) != null && GetPieceOnPosition(normal).Color == _currentPiece.Color)
                {
                    break;
                }

                
                normal += direction;
            }
            
            return list;
        }

        public Hover CanMove(Vector2 direction, Vector2 position, bool needEnemy = false)
        {
            position += direction;

            if(position.X < 8 &&
                   position.X >= 0 &&
                   position.Y < 8 &&
                   position.Y >= 0)
            {
                if ((GetPieceOnPosition(position) == null && !needEnemy) ||
                (needEnemy && GetPieceOnPosition(position) != null && GetPieceOnPosition(position).Color != _currentPiece.Color))
                {
                    return new Hover(_gameController.Game, position);
                }
                else if(GetPieceOnPosition(position) != null && GetPieceOnPosition(position).Color != _currentPiece.Color)
                {
                    return new Hover(_gameController.Game, position);
                }
            }
                
            return null;
        }

        //used for all pieces except knight
        public Vector2 Up = new Vector2(0, -1);
        public Vector2 UpLeft = new Vector2(-1, -1);
        public Vector2 Left = new Vector2(-1, 0);
        public Vector2 DownLeft = new Vector2(-1, 1);
        public Vector2 Down = new Vector2(1, 0);
        public Vector2 DownRight = new Vector2(1, 1);
        public Vector2 Right = new Vector2(0, 1);
        public Vector2 UpRight = new Vector2(1, -1);

        //used only for the knight piece
        public Vector2 KnUpRight = new Vector2(1, -2);
        public Vector2 KnUpLeft = new Vector2(-1, -2);
        public Vector2 KnLeftUp = new Vector2(-2, -1);
        public Vector2 KnLeftDown = new Vector2(-2, 1);
        public Vector2 KnDownLeft = new Vector2(-1, 2);
        public Vector2 KnDownRight = new Vector2(1, 2);
        public Vector2 KnRightDown = new Vector2(2, 1);
        public Vector2 KnRightUp = new Vector2(2, -1);

       #endregion

        public List<Piece> GetPiecesWithColor(GameColor color)
        {
            return _playerPieces[color];
        }
    }
}
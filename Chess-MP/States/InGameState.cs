#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Chess_MP.Board;
using Chess_MP.Pieces;
using Microsoft.Xna.Framework;

namespace Chess_MP.States
{
    public class InGameState : State
    {
        private Player[] _players;
        private List<Field> _fields;
        private PieceManager _pieceManager;

        private Player _currentPlayer;
        private int _playerIndex;
        
        /// <inheritdoc />
        public InGameState(GameController gameController) : base(gameController)
        {
        }

        /// <inheritdoc />
        public override void EnterState()
        {
            _fields = new List<Field>();

            for (int xIndex = 0; xIndex < 8; xIndex++)
            {
                for (int y = 0; y < 8; y++)
                {
                    _fields.Add(new Field(_gameController, new Vector2(xIndex, y)));
                }
            }

            _players = new Player[]
            {
                new Player(_gameController, 1, "Sebastian", GameColor.Black),
                new Player(_gameController, 2, "Grøn", GameColor.White)
            };
            
            _pieceManager = new PieceManager(_gameController);

            _currentPlayer = _players.First(player => player.Color == GameColor.White);
            _playerIndex = 1;
        }

        /// <inheritdoc />
        public override void ExitState()
        {
            _playerIndex = 0;
            _players = new Player[2];
            _fields.Clear();
            _pieceManager.Clear();
        }

        public void ChangeTurn()
        {
            // King whiteKing = _pieceManager.GetPiecesWithColor(GameColor.White).First(piece => piece is King) as King ?? throw new InvalidOperationException();
            // King blackKing = _pieceManager.GetPiecesWithColor(GameColor.Black).First(piece => piece is King) as King ?? throw new InvalidOperationException();

            if (++_playerIndex > _players.Length - 1)
            {
                _playerIndex = 0;
            }
            
            _currentPlayer = _players[_playerIndex];
        }

        public void GameEnded()
        {
            ExitState();
            _gameController.State = new EndGameState(_gameController, _currentPlayer.Color);
            _gameController.State.EnterState();
                        
            _gameController = null;
        }

        /**
         * Gets the field in the specific position.
         * @returns The specified Piece.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public Field? this[Vector2 position]
        {
            get
            {
                if (!_fields.Exists(field => field.Id == position))
                    return null;
                return  _fields.First(field => field.Id == position);
            }
        }
        
        /**
         * Returns the list of Fields as readonly.
         * @returns The Fields.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public List<Field> Fields => _fields;

        public Player[] Players => _players;

        public PieceManager PieceManager => _pieceManager;

        public Player CurrentPlayer => _currentPlayer;
    }
}
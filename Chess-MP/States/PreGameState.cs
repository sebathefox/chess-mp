using System;
using System.Collections.Generic;
using Chess_MP.MainMenu;
using Microsoft.Xna.Framework;

namespace Chess_MP.States
{
    public class PreGameState : State
    {
        private List<Button> _buttons;

        /// <inheritdoc />
        public PreGameState(GameController gameController) : base(gameController)
        {
        }

        /// <inheritdoc />
        public override void EnterState()
        {
            Point center = _gameController.Game.Window.ClientBounds.Center;
            
            _buttons = new List<Button>()
            {
                new Button(_gameController, "Play", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(191, 128, 130, 64)),
                new Button(_gameController, "Fun Version", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(136, 256, 240, 64)),
                new Button(_gameController, "Exit", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(191, 384, 130, 64))
            };

            foreach (Button button in _buttons)
            {
                button.OnClick += OnKeyPressed;
            }
        }

        /// <inheritdoc />
        public override void ExitState()
        {
        }

        private void OnKeyPressed(object sender, EventArgs args)
        {
            Button btn = sender as Button;

            if (btn.Text.ToLower().Equals("exit"))
            {
                _gameController.Game.Exit();
            }

            if (btn.Text.ToLower().Equals("play"))
            {
                // White
                _gameController.Game.AssetManager.LoadTexture("white-pawn", "normal/white_pawn");
                _gameController.Game.AssetManager.LoadTexture("white-knight", "normal/white_knight");
                _gameController.Game.AssetManager.LoadTexture("white-rook", "normal/white_castle");
                _gameController.Game.AssetManager.LoadTexture("white-bishop", "normal/white_bishop");
                _gameController.Game.AssetManager.LoadTexture("white-king", "normal/white_king");
                _gameController.Game.AssetManager.LoadTexture("white-queen", "normal/white_queen");

                // Black
                _gameController.Game.AssetManager.LoadTexture("black-pawn", "normal/black_pawn");
                _gameController.Game.AssetManager.LoadTexture("black-knight", "normal/black_knight");
                _gameController.Game.AssetManager.LoadTexture("black-rook", "normal/black_castle");
                _gameController.Game.AssetManager.LoadTexture("black-bishop", "normal/black_bishop");
                _gameController.Game.AssetManager.LoadTexture("black-king", "normal/black_king");
                _gameController.Game.AssetManager.LoadTexture("black-queen", "normal/black_queen");
            }
            else if (btn.Text.ToLower().Equals("fun version"))
            {
                // White
                _gameController.Game.AssetManager.LoadTexture("white-pawn", "meme/white_pawn");
                _gameController.Game.AssetManager.LoadTexture("white-knight", "meme/white_knight");
                _gameController.Game.AssetManager.LoadTexture("white-rook", "meme/white_castle");
                _gameController.Game.AssetManager.LoadTexture("white-bishop", "meme/white_bishop");
                _gameController.Game.AssetManager.LoadTexture("white-king", "meme/white_king");
                _gameController.Game.AssetManager.LoadTexture("white-queen", "meme/white_queen");

                // Black
                _gameController.Game.AssetManager.LoadTexture("black-pawn", "meme/black_pawn");
                _gameController.Game.AssetManager.LoadTexture("black-knight", "meme/black_knight");
                _gameController.Game.AssetManager.LoadTexture("black-rook", "meme/black_castle");
                _gameController.Game.AssetManager.LoadTexture("black-bishop", "meme/black_bishop");
                _gameController.Game.AssetManager.LoadTexture("black-king", "meme/black_king");
                _gameController.Game.AssetManager.LoadTexture("black-queen", "meme/black_queen");
            }
            
            ExitState();

            foreach (Button button in _buttons)
            {
                button.Disable();
            }
            
            _gameController.State = new InGameState(_gameController);
            _gameController.State.EnterState();
        }
    }
}
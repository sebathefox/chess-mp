using System;
using System.Collections.Generic;
using Chess_MP.MainMenu;
using Microsoft.Xna.Framework;

namespace Chess_MP.States
{    
    public class EndGameState : State
    { 
        private string _text;
        private List<Button> _buttons;
        private List<Label> _labels;
                
        /// <inheritdoc />
        public EndGameState(GameController gameController, GameColor color) : base(gameController)
        {
            _text = color.ToString();
        }
                
        /// <inheritdoc />
        public override void EnterState()
        {           
            Point center = _gameController.Game.Window.ClientBounds.Center;

            _buttons = new List<Button>()
            {
                new Button(_gameController, "Rematch", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(156, 128, 200, 64)),
                new Button(_gameController, "Main Menu", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(131, 192, 250, 64)),
                new Button(_gameController, "Exit", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(191, 256, 130, 64))
            };

            _labels = new List<Label>()
            {
                new Label(_gameController, _text + " Has Won", new Rectangle(131, 60, 250, 64))
            };

            foreach (Button button in _buttons)
            {
                button.OnClick += OnKeyPressed;
            }
        }

        /// <inheritdoc />
        public override void ExitState()
        {
            foreach (Button button in _buttons)
            {
                button.Disable();
            }

            foreach (Label label in _labels)
            {
                label.Disable();
            }
        }

        private void OnKeyPressed(object sender, EventArgs args)
        {
            Button btn = sender as Button;
            
            if (btn.Text.ToLower().Equals("rematch"))
            {
                ExitState();
                _gameController.State = new InGameState(_gameController);
                _gameController.State.EnterState();

                _gameController = null;
            }
            else if (btn.Text.ToLower().Equals("main menu"))
            {
                ExitState();
                _gameController.State = new PreGameState(_gameController);
                _gameController.State.EnterState();

                _gameController = null;
            }
            else if(btn.Text.ToLower().Equals("exit"))
            {
                _gameController.Game.Exit();
            }
        }
    }
}
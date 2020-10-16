using System;
using System.Collections.Generic;
using Chess_MP.MainMenu;
using Microsoft.Xna.Framework;

namespace Chess_MP.States
{
    public class PreGameState : State
    {
        private List<Button> _buttons;

        
        // TODO: Implement the GUI.
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
                new Button(_gameController, "Play", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(0, 0, 128, 64)),
                new Button(_gameController, "Exit", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(128, 0, 128, 64))
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
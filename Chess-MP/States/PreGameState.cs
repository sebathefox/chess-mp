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
                new Button(_gameController, "Play", _gameController.Game.AssetManager.GetTexture("button"), new Rectangle(center.X - 64, center.Y - 32, 128, 64))
            };

            _buttons[0].OnClick += OnPlayPressed;
        }

        /// <inheritdoc />
        public override void ExitState()
        {
            
        }

        private void OnPlayPressed(object sender, EventArgs args)
        {
            ExitState();
            _buttons[0].Disable();
            
            _gameController.State = new InGameState(_gameController);
            _gameController.State.EnterState();
        }
    }
}
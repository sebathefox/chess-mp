using Microsoft.Xna.Framework;

namespace Chess_MP.States
{
    public class PreGameState : State
    {
        // TODO: Implement the GUI.
        /// <inheritdoc />
        public PreGameState(GameController gameController) : base(gameController)
        {
        }

        /// <inheritdoc />
        public override void EnterState()
        {
            
        }

        /// <inheritdoc />
        public override void ExitState()
        {
            
        }

        private void OnPlayPressed(object sender, Vector2 position)
        {
            // TODO: Implement Logic to check for press.
        }
    }
}
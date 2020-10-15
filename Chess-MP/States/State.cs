namespace Chess_MP.States
{
    /**
     * The abstract class that defines a state.
     * @author Sebastian Davaris
     * @date 15-10-2020
     */
    public abstract class State
    {
        protected GameController _gameController;

        
        
        public State(GameController gameController)
        {
            _gameController = gameController;
        }
        
        /**
         * Called when the parent enters this state.
         * @author Sebastian Davaris
         * @date 15-10-2020
         */
        public abstract void EnterState();

        /**
         * Called when the parent exits this state.
         * @author Sebastian Davaris
         * @date 15-10-2020
         */
        public abstract void ExitState();
    }
}
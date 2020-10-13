using System.Collections.Generic;
using Chess_MP.Pieces;

namespace Chess_MP
{
    /**
     * Contains the Player logic.
     * @author Sebastian Davaris
     * @date 13-10-2020
     */
    public class Player
    {
        private Game1 _game;
        private readonly uint _id;
        private readonly string _name;
        private readonly GameColor _color;

        private List<Piece> _pieces;

        public Player(Game1 game, uint id, string name, GameColor color)
        {
            _game = game;
            _id = id;
            _name = name;
            _color = color;
            _pieces = new List<Piece>(LayoutManager.Generate(_game, this));
        }

        /**
         * Gets the player's ID.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public uint Id => _id;

        /**
         * Gets the player's Name.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public string Name => _name;

        /**
         * Indexer getting the piece with the specified index.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public Piece this[int index] => _pieces[index];
        
        /**
         * Gets the player's Pieces.
         * @author Sebastian Davaris
         * @date 13-10-2020
         */
        public List<Piece> Pieces => _pieces;

        public GameColor Color => _color;
    }
}
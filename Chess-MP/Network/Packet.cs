using System;
using System.Runtime.Serialization;
using Chess_MP.Pieces;

namespace Chess_MP.Network
{
    [Serializable]
    public class Packet : ISerializable
    {
        private Piece _currentPiece;
        
        // private

        /// <inheritdoc />
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // info.AddValue("");
        }
    }
}
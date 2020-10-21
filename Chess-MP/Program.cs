using Chess_MP.Network;
using System;

namespace Chess_MP
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            //Client client = new Client();

            //while (true)
            //{

            //}

            using (var game = new Game1())
                game.Run();
        }
    }
}
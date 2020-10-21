using System;
using Chess_MP.Network;

namespace Chess_MP
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            Host host = new Host();


            while (true)
            {
                host.Receive();

            }
            
            
            
            // using (var game = new Game1())
            //     game.Run();
        }
    }
}
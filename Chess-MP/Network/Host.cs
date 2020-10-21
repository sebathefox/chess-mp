using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Chess_MP.Network
{
    public class StateObject
    {
        public const int BufferSize = 1024;
        
        public byte[] buffer = new byte[BufferSize];
        
        public StringBuilder sb = new StringBuilder();

        public Socket workSocket = null;
    }
    
    public class Host
    {
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        
        private Socket _socket;

        private Socket _client;

        public Host()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            _socket.Bind(new IPEndPoint(IPAddress.Parse("0.0.0.0"), 50166));
            _socket.Listen(1);

            _client = _socket.Accept();
        }

        public void SendData()
        {
            
        }

        public void Receive()
        {
            StateObject state = new StateObject();
            // _client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallBack), state);

            while (_client.Receive(state.buffer) > 0)
            {
                state.sb.Append(Encoding.UTF8.GetString(state.buffer));
            }

            Console.WriteLine(state.sb.ToString());
        }

        private void ReadCallBack(IAsyncResult ar)
        {
            
        }
    }
}
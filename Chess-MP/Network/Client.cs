using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Chess_MP.Network
{
    public class Client
    {
        private Socket _client;

        public Client()
        {
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            
            _client.Connect(IPAddress.Parse("10.142.116.15"), 50166);
            _client.Send(Encoding.UTF8.GetBytes("Yeet"));
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
    }
}
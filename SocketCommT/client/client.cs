using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SocketCommT.client
{
    class Client
    {
        private readonly string serverIp;
        private readonly int serverPort;
        private readonly string clientId;
        private Socket clientSocket;
        private Thread receiveThread;

        public event EventHandler<string> MessageReceived;

        public Client(string serverIp, int serverPort)
        {
            this.serverIp = serverIp;
            this.serverPort = serverPort;
        }
        public void Connect()
        {
            // Create a new TCP/IP socket
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Connect to the remote host
            clientSocket.Connect(IPAddress.Parse(serverIp), serverPort);

            // Start a new thread to receive messages from the server
            receiveThread = new Thread(ReceiveMessages);
            receiveThread.IsBackground = true;
            receiveThread.Start();
        }

        public void Disconnect()
        {
            // Close the socket and stop the receive thread
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            receiveThread?.Join();
        }
        public void SendMessage(string message)
        {
            // Send the message to the server
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            clientSocket.Send(buffer);
        }

        private void ReceiveMessages()
        {
            while (clientSocket.Connected)
            {
                try
                {
                    // Receive messages from the server
                    byte[] buffer = new byte[1024];
                    int bytesReceived = clientSocket.Receive(buffer);
                    if (bytesReceived > 0)
                    {
                        string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                        MessageReceived?.Invoke(this, message);
                    }
                }
                catch (SocketException)
                {
                    // Connection was closed
                    break;
                }
            }
        }



        }


}

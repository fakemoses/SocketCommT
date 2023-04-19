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

        public Client(string serverIp, int serverPort)
        {
            this.serverIp = serverIp;
            this.serverPort = serverPort;
            clientId = Guid.NewGuid().ToString();
        }

        public void Start()
        {
            try
            {
                //internetwork -> defining for IPV4
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket.Connect(new IPEndPoint(IPAddress.Parse(serverIp), serverPort));
                Console.WriteLine("Connected to FormServer");

                Thread receiveThread = new Thread(ReceiveMessages);
                receiveThread.Start();

                while (true)
                {
                    Console.Write("Enter recipient ID (or 'exit' to quit): ");
                    string recipientId = Console.ReadLine();
                    if (recipientId == "exit")
                    {
                        break;
                    }

                    Console.Write("Enter message: ");
                    string content = Console.ReadLine();
                    string message = recipientId + "||" + content;
                    clientSocket.Send(Encoding.UTF8.GetBytes(message));
                }

                Console.WriteLine("Closing connection...");
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

            }

            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }


        }

        private void ReceiveMessages()
        {
            byte[] buffer = new byte[1024];
            while (true)
            {
                int bytesReceived = clientSocket.Receive(buffer);
                if (bytesReceived == 0)
                {
                    break;
                }

                string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                Console.WriteLine("Received message: {0}", message);
            }
            Console.WriteLine("Disconnected from FormServer");
        }
    }


}

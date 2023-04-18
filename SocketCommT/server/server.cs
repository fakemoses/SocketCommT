using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SocketcommT.server
{
    public class Server
    {
        private static IPHostEntry ipHost;
        public static IPAddress iPAddress;
        private static IPEndPoint localEndPoint;
        private static Socket listener;
        private static Socket clientSocket;
        public string message { get; set; }
        public Server()
        {
             ipHost = Dns.GetHostEntry(Dns.GetHostName());
             iPAddress = ipHost.AddressList[0];
             localEndPoint = new IPEndPoint(iPAddress, 6000);
             listener = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        public static void Start()
        {

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    Console.WriteLine("waiting...");

                    clientSocket = listener.Accept();

                    //data buffer
                    byte[] buffer = new byte[1024];
                    string data = null;

                    while (true)
                    {
                        int numByte = clientSocket.Receive(buffer);
                        data += Encoding.ASCII.GetString(buffer, 0, numByte);

                        if (data.IndexOf("<EOF>") > -1)
                            break;

                    }

                    Console.WriteLine("Text received -> {0} ", data);
                    byte[] message = Encoding.ASCII.GetBytes("Test Server");
                    clientSocket.Send(message);


                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

        }

        public void ShutdownServer()
        {
            try
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
        }
    }
}
using System;
using System.Net.Sockets;
using System.Net;

namespace SocketcommT.server;

public class Server
{
	public Server()
	{

	}

    public static void runServer()
    {
        IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress iPAddress = ipHost.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(iPAddress, 6000);

        Socket listener = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true)
            {
                Console.WriteLine("waiting...");

                Socket clientSocket = listener.Accept();

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

                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();

            }

        }
        catch (Exception e)
        {

            Console.WriteLine(e.ToString());
        }

    }
}

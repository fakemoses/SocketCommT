using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SocketcommT.server
{
    public class Server
    {
        public static IPAddress iPAddress;
        private static Socket serverSocket;
        private readonly int port;
        private readonly Dictionary<string, Socket> clients = new Dictionary<string, Socket>();
        private readonly object lockObject = new object();
        private static string clientId;

        public TextBox logTextBox;


        public Server(int port = 6000, TextBox logTextBox = null)
        {
            this.port = port;
            this.logTextBox = logTextBox ?? throw new ArgumentNullException("logTextBox");
        }

        public void Start()
        {
            try
            {
                //following codes is for assigning the IP address of the FormServer instead of calling any IP address
                //IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                //IPAddress ipAddr = ipHost.AddressList[0];
                //IPEndPoint localEndPoint = new IPEndPoint(ipAddr, port);

                // IPAddress.Any is equivalent to IPAddress ip = IPAddress.Parse("0.0.0.0")
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(new IPEndPoint(IPAddress.Any, port));
                serverSocket.Listen(10);

                InvokeOnGuiThread(() => logTextBox.AppendText("Server started listening on port " + port + "\r\n"));

                while (true)
                {
                    Socket clientSocket = serverSocket.Accept();
                    string clientId = Guid.NewGuid().ToString();
                    ClientHandler clientHandler = new ClientHandler(clientSocket, clientId, this);
                    Thread clientThread = new Thread(clientHandler.Handle);
                    clientThread.Start();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }

        }

        // Define a delegate type for the event
        public delegate void StatusChangedEventHandler(object sender, string status);

        // Define the event itself
        public event StatusChangedEventHandler StatusChanged;

        // A method that raises the event when the status changes
        protected void OnStatusChanged(string status)
        {
            // Check if the event has any subscribers
            if (StatusChanged != null)
            {
                // Raise the event, passing the sender (this) and the status message
                StatusChanged(this, status);
            }
        }

        private void InvokeOnGuiThread(Action action)
        {
            if (logTextBox.InvokeRequired)
            {
                logTextBox.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }

        public void BroadcastMessage(string message)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            foreach (ClientHandler clientHandler in ClientHandler.Clients.Values)
            {
                clientHandler.clientSocket.Send(buffer);
            }
            InvokeOnGuiThread(() => logTextBox.AppendText("Broadcast message: " + message + "\r\n"));
        }

        public void Stop()
        {
            Socket exListener = Interlocked.Exchange(ref serverSocket, null);
            if (exListener != null)
            {
                exListener.Close();
            }
            //serverSocket.Shutdown(SocketShutdown.Both);
            //serverSocket.Close();
        }

    }

    public class ClientHandler
    {
        public Socket clientSocket;
        private string clientId;
        private Server server;

        public static readonly Dictionary<string, ClientHandler> Clients = new Dictionary<string, ClientHandler>();

        public ClientHandler(Socket clientSocket, string clientId, Server server)
        {
            this.clientSocket = clientSocket;
            this.clientId = clientId;
            this.server = server;
            Clients.Add(clientId, this);
        }

        public void Handle()
        {
            InvokeOnGuiThread(() => server.logTextBox.AppendText("Client " + clientId + " connected\r\n"));

            byte[] buffer = new byte[1024];
            while (true)
            {
                int bytesReceived = clientSocket.Receive(buffer);
                if (bytesReceived == 0)
                {
                    break;
                }

                string message = Encoding.UTF8.GetString(buffer, 0, bytesReceived);
                InvokeOnGuiThread(() => server.logTextBox.AppendText("Received message from " + clientId + ": " + message + "\r\n"));
                server.BroadcastMessage(clientId + "||" + message);
            }

            Clients.Remove(clientId);
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            InvokeOnGuiThread(() => server.logTextBox.AppendText("Client " + clientId + " disconnected\r\n"));
        }

        private void InvokeOnGuiThread(Action action)
        {
            if (server.logTextBox.InvokeRequired)
            {
                server.logTextBox.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
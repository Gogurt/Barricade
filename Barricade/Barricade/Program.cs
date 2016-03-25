using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barricade
{
    public static class Program
    {
        //Host related
        static int turn;
        static int numberOfPlayers;
        /*
         * Maybe define a constructor for each player to hold information about score?
         * Might be unneccesary since there isn't too many variables connected to each player.
        */

        //Net-related
        //For server
        private static byte[] buffer = new byte[1024];
        private static List<Socket> clientSockets = new List<Socket>();
        private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //For client
        public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
        //SERVER
        public static void CreateServerSocket()
        {
            Console.WriteLine("Setting up the server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            serverSocket.Listen(5);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            Console.WriteLine("Server has been created!");
            Console.WriteLine("Server listening for client requests...");
        }
        private static void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            clientSockets.Add(socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        private static void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            //Trims null bytes being sent
            byte[] dataBuf = new byte[received];
            Array.Copy(buffer, dataBuf, received);

            string text = Encoding.ASCII.GetString(dataBuf);
            Console.WriteLine("Text received: " + text);

            string response = string.Empty;
            
            //text acts as a request, this is where it would be interpreted.
            //So coordiate information on the current player's turn would be retrieved here,
            //and then interpreted to send info back to all conncted players.

            byte[] data = Encoding.ASCII.GetBytes(response);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);

        }

        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        //CLIENT
        public static void LoopConnect()
        {
            int attempts = 0;

            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    clientSocket.Connect(IPAddress.Loopback, 100);
                }
                catch(SocketException)
                {
                    Console.WriteLine("Connection attempts: " + attempts.ToString());
                }
            }
            Console.WriteLine("Client connected");
        }

        public static void SendLoop(string req)
        {
                byte[] buffer = Encoding.ASCII.GetBytes(req);
                clientSocket.Send(buffer);

                byte[] receivedBuf = new byte[1024];
                int rec = clientSocket.Receive(receivedBuf);
                byte[] data = new byte[rec];
                Array.Copy(receivedBuf, data, rec);
                Console.WriteLine("Received: " + Encoding.ASCII.GetString(data));
            
        }
    }
}

/* Barricade Network Game
 * Garrett Leatherman, Jamie Thul, Erik Canton, Matthew Leet
 * 3/31/16
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Barricade
{
    /*
     * Server Class
     * Holds all methods related to creating a server and communicating with connecting clients.
     * This contains all the methods to broadcast update information about the current game to
     * all currently connected players.
     */
    public class Server
    {

        static int turn;
        static int numberOfPlayers;

        //Net-related
        private static byte[] buffer = new byte[1024];
        private static List<Socket> clientSockets = new List<Socket>();
        public static Socket serverSocket;
        
        public string serverMessage = "";

        //Set 
        public static Form1 myForm = null;
        public Server(Form1 form)
        {
            myForm = form;
        }

        //SERVER
        public void CreateServerSocket()
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Setting up the server...");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 8000));
            serverSocket.Listen(5);
            
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            Console.WriteLine("Server has been created!");
            Console.WriteLine("Server listening for incoming players...");
            myForm.hostTextbox("Server listening for incoming players...");
        }

        public void AcceptCallback(IAsyncResult AR)
        {
            Socket socket;
            try
            {
                
                socket = serverSocket.EndAccept(AR);
                clientSockets.Add(socket);
                Console.WriteLine("Player " + (clientSockets.Count + 1).ToString() + " has connected!");
                //TELL HOST THEY CONNECTED ON FORM
                myForm.Invoke(new Action(() => myForm.hostDebugTextbox.Items.Add("Player " + (clientSockets.Count + 1).ToString() + " has connected!")));
                
                numberOfPlayers++;
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch(Exception e)
            {
        
               Console.WriteLine(e.ToString());
            }
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            try {
                Socket socket = (Socket)AR.AsyncState;
                int received = socket.EndReceive(AR);
                //Trims null bytes being sent
                byte[] dataBuf = new byte[received];
                Array.Copy(buffer, dataBuf, received);

                string text = Encoding.ASCII.GetString(dataBuf);
                Console.WriteLine("Text received: " + text);
                myForm.Invoke(new Action(() => myForm.hostDebugTextbox.Items.Add(text)));
                if(text.Equals("Client Disconnect"))
                {
                    socket.Disconnect(true);
                
                    numberOfPlayers--;
                }
                else
                {
                    string response = string.Empty;

                    //text acts as a request, this is where it would be interpreted.
                    //So coordiate information on the current player's turn would be retrieved here,
                    //and then interpreted to send info back to all conncted players.

                    byte[] data = Encoding.ASCII.GetBytes(response);
                    socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
                    socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        public void closeServer()
        {
            serverSocket.Close(1);
            
        }

        

    }
}

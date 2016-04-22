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
        private static List<Socket> connectedSocketList = new List<Socket>();
        public static Socket serverSocket;

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
            numberOfPlayers = 1;
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
                numberOfPlayers++;
                connectedSocketList.Add(socket);
                string playerAcceptMessage = "Player " + (connectedSocketList.Count + 1).ToString() + " has connected!";

                Console.WriteLine(playerAcceptMessage);
                //TELL HOST THEY CONNECTED ON FORM
                try
                {
                    broadcastToClients(socket, playerAcceptMessage);
                }
                catch(Exception e)
                {
                    myForm.Invoke(new Action(() => myForm.hostDebugTextbox.Items.Add("Failed to send to all connected clients.")));
                }
                

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
                Console.WriteLine("Text in socket: " + text);

                if(text.Equals("Client Disconnect"))
                {
                    socket.Disconnect(true);
                
                    numberOfPlayers--;
                }
                else
                {
                    string textToSend = string.Empty;

                    //text acts as a request, this is where it would be interpreted.
                    //So coordiate information on the current player's turn would be retrieved here,
                    //and then interpreted to send info back to all conncted players.
                    switch(text)
                    {

                        default:
                            broadcastToClients(socket, text);
                        break;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private static void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private static void send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);
        }

        public void closeServer()
        {
            //Communicate to connected clients they should close their server sockets

            serverSocket.Close(1);
        }

        public void broadcastToClients(Socket socket, string text)
        {

            for(int i = 0; i < connectedSocketList.Count; i++)
            {
                /*
                if(socket != connectedSocketList.ElementAt(i))
                {
                    send(connectedSocketList.ElementAt(i), text);
                }
                */
                myForm.Invoke(new Action(() => myForm.hostDebugTextbox.Items.Add(text)));

                myForm.Invoke(new Action(() => myForm.hostDebugTextbox.Items.Add("Sending to player " + (connectedSocketList.Count + 1))));
                send(connectedSocketList.ElementAt(i), text);
                connectedSocketList.ElementAt(i).BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), connectedSocketList.ElementAt(i));
            }

        }

    }

}

﻿/* Barricade Network Game
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
        static int numberOfPlayers;
        public int currentPlayer = -1;
        public Boolean samePlayerTakeTurn = false;

        //Net-related
        private static byte[] buffer = new byte[1024];
        public List<Socket> connectedSocketList = new List<Socket>();
        public Socket serverSocket;



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
                myForm.Invoke(new Action(() => myForm.hostDebugTextbox.Items.Add(playerAcceptMessage)));
                Console.WriteLine(playerAcceptMessage);
                //TELL HOST THEY CONNECTED ON FORM
                try
                {
                    broadcastToClients(socket, playerAcceptMessage);
                }
                catch(Exception e)
                {
                    myForm.Invoke(new Action(() => myForm.hostDebugTextbox.Items.Add("Failed to send to all connected clients.")));
                    Console.WriteLine(e.ToString());
                }
                

                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
                serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            }
            catch(Exception e)
            {
        
               Console.WriteLine(e.ToString());
            }
        }

        public void iterateToNextPlayer()
        {
            currentPlayer++;
            if(currentPlayer >= connectedSocketList.Count)
            {
                currentPlayer = -1;
                myForm.canPlay = true;
                myForm.Invoke(new Action(() => myForm.gameTextbox.Items.Add("It is player " + currentPlayer.ToString() + "'s turn.")));
            }
            else
            {
                Socket targetedPlayer = connectedSocketList.ElementAt(currentPlayer);
                send(targetedPlayer, "CanPlay");
                myForm.Invoke(new Action(() => myForm.gameTextbox.Items.Add("It is player " + currentPlayer.ToString() + "'s turn.")));
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

                string receivedCommand = Encoding.ASCII.GetString(dataBuf);
                Console.WriteLine("Text in socket: " + receivedCommand);

                myForm.Invoke(new Action(() => myForm.gameTextbox.Items.Add(receivedCommand)));

                if (receivedCommand.Equals("Client Disconnect"))
                {
                    socket.Disconnect(true);

                    numberOfPlayers--;
                }
                else if (receivedCommand.StartsWith("Update"))
                {
                    //Check if any boxes have been filled
                    //Else send the game board as is to all connected clients
                    string myGameBoard = receivedCommand.Substring(6);
                    
                    //Update the host's gameBoard
                    myForm.gameBoard = myForm.readBoard(myGameBoard);
                    myForm.updateFormBoard();


                    myForm.hostAssessTurn(currentPlayer);
                    myForm.Invoke(new Action(() => myForm.gameTextbox.Items.Add(receivedCommand)));
                    myForm.hostBroadcastBoard();

                    
                   if(currentPlayer == -1 && myForm.iAmTheHost)
                   {
                       myForm.canPlay = true;
                   }
                }
                else
                {
                    myForm.Invoke(new Action(() => myForm.hostDebugTextbox.Items.Add("Failed to interpret received command.")));
                    

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

        public void send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
           
            client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), client);
            client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), client);
        }

        public void closeServer()
        {
            //Communicate to connected clients they should close their server sockets


            serverSocket.Close(1);
        }
        
        /*
         * IMPORTANT: The host needs to be able to use its game class logic to specifically talk to the next player to let them know
         * they can make their turn.
         */

        public void broadcastToClients(Socket socket, string text)
        {
            
            for(int i = 0; i < connectedSocketList.Count; i++)
            {
                if(socket == null)
                {
                        myForm.Invoke(new Action(() => myForm.gameTextbox.Items.Add("Sending to player " + (connectedSocketList.Count + 1))));
                        send(connectedSocketList.ElementAt(i), text);
                }
                else
                {
                    if (socket != connectedSocketList.ElementAt(i))
                    {
                        myForm.Invoke(new Action(() => myForm.gameTextbox.Items.Add("Sending to player " + (connectedSocketList.Count + 1))));
                        send(connectedSocketList.ElementAt(i), text);
                    }
                }
                connectedSocketList.ElementAt(i).BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), connectedSocketList.ElementAt(i));
               }
            //myForm.Invoke(new Action(() => myForm.gameTextbox.Items.Add(text)));

        }

    }

}

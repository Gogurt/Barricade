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

namespace Barricade
{
    /*
     * Client Class
     * Holds all methods related to communicating with a host client.
     * This is where a joined player listens for update information about
     * other players, whose turn it is, and how they can interact when it is
     * their turn.
     */
    public class Client
    {
        //Net-related
        private static byte[] buffer = new byte[1024];
        public static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        

        public static Form1 myForm;
        public Client(Form1 form)
        {
            myForm = form;
        }

        public void ClientConnect(String ipInput)
        {
            int attempts = 0;

            while (!clientSocket.Connected && attempts <= 5)
            {
                try
                {
                    attempts++;
                    //Replace IpAddress.Loopback with ipInput if connecting to host on different machine.
                    //"10.134.222.242"
                    if (ipInput == "")
                    {
                        clientSocket.Connect(IPAddress.Loopback, 8000);
                    }
                    else
                    {
                        clientSocket.Connect(ipInput, 8000);
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("Connection attempts: " + attempts.ToString());
                }
            }
            if (clientSocket.Connected)
            {
                Console.WriteLine("Client connected");
                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
            }
            else
            {
                Console.WriteLine("Failed to connect");
                
            }

        }

        public bool isConnected()
        {
            if(clientSocket.Connected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SendLoop(string req)
        {
            byte[] byteData = Encoding.ASCII.GetBytes(req);
            clientSocket.Send(byteData);

            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            try
            {
                Socket socket = (Socket)AR.AsyncState;
                int received = socket.EndReceive(AR);
                //Trims null bytes being sent
                byte[] dataBuf = new byte[received];
                Array.Copy(buffer, dataBuf, received);

                string receivedCommand = Encoding.ASCII.GetString(dataBuf);
                Console.WriteLine("Text received from host: " + receivedCommand);


                //Interpret game logic from host or other connected client here
                if(receivedCommand == "GameStart")
                {
                    myForm.Invoke(new Action(() => myForm.gamePanel.Visible = true));
                    myForm.Invoke(new Action(() => myForm.joinSessionPanel.Visible = false));
                    
                }
                else if(receivedCommand == "CanPlay")
                {
                    myForm.canPlay = true;
                }
                else if (receivedCommand.StartsWith("Update"))
                {
                    String board = receivedCommand.Substring(6);
                    myForm.Invoke(new Action(() => myForm.gameBoard = myForm.readBoard(board)));
                    myForm.Invoke(new Action(() => myForm.updateFormBoard()));
                    myForm.Invoke(new Action(() => myForm.gamePanel.Visible = true));
                }
                else if (receivedCommand.StartsWith("CanPlayUpdate"))
                {
                    myForm.canPlay = true;
                    String board = receivedCommand.Substring(13);
                    myForm.Invoke(new Action(() => myForm.gameBoard = myForm.readBoard(board)));
                    myForm.Invoke(new Action(() => myForm.updateFormBoard()));
                    myForm.Invoke(new Action(() => myForm.gamePanel.Visible = true));
                }
                else
                {
                    myForm.Invoke(new Action(() => myForm.logToGameTextbox("Error: Recieved unknown query from host.")));
                    myForm.Invoke(new Action(() => myForm.logToGameTextbox(receivedCommand)));
                }


                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }

    
        public static void Disconnect()
        {
            byte[] buffer = Encoding.ASCII.GetBytes("Client Disconnect");
            clientSocket.Send(buffer);
            clientSocket.Disconnect(true);
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Client Diconnected");
        }


    }
}

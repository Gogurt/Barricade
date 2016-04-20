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
            byte[] buffer = Encoding.ASCII.GetBytes(req);
            clientSocket.Send(buffer);
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

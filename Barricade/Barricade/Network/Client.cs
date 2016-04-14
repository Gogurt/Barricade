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
        
        public static void ClientConnect(string ipInput)
        {
            int attempts = 0;

            while (!clientSocket.Connected && attempts <= 5)
            {
                try
                {
                    attempts++;
                    //Replace IpAddress.Loopback with ipInput if connecting to host on different machine.
                    clientSocket.Connect(IPAddress.Loopback, 8000);
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

        public static void SendLoop(string req)
        {
            byte[] buffer = Encoding.ASCII.GetBytes(req);
            clientSocket.Send(buffer);

            //Receiving response

            //byte[] receivedBuf = new byte[1024];
            //int rec = clientSocket.Receive(receivedBuf);
            //byte[] data = new byte[rec];
            //Array.Copy(receivedBuf, data, rec);
            //Console.WriteLine("Received: " + Encoding.ASCII.GetString(data));

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

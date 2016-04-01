/* Barricade Network Game
 * Garrett Leatherman, Jamie Thul, Erik Canton, Matthew Leet
 * 3/31/16
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barricade
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Join a session button (Join Game)
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Manual request prompt occuring...");
            //Send string request with loopSend method
            sendManualRequestPrompt();
        }

        //Create a session button (Host Game)
        private void button2_Click(object sender, EventArgs e)
        {
            Server.CreateServerSocket();
            //Change to panel that waits for incoming clients to join

        }

        //Currently for debugging purposes by sending string data to host. Activated by Join Game button after connect to host is made.
        private void sendManualRequestPrompt()
        {
            if (Client.clientSocket.Connected)
            {
                while(true)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your request", "Debug manual request", "", -1, -1);
                    if(input == "exit")
                    {
                        break;
                    }
                    Client.SendLoop(input);
                }
                Client.Disconnect();
            }
            else
            {
                Client.ClientConnect();
            }
        }

    }


}

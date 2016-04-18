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
            joinSessionPanel.Visible = true;
            string ipInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the host ip. If left empty, this will attempt to connect to a local host.", "Join Host Session", "", -1, -1);
            if(ipInput.Length == 0)
            {
                clientDebugTextbox.Items.Add("Attempting to join a local host...");
            }
            else
            {
                clientDebugTextbox.Items.Add("Attempting to join " + ipInput + "...");
            }
            Client.ClientConnect(ipInput);
            //Send string request with loopSend method

            if (Client.clientSocket.Connected)
            {
                clientDebugTextbox.Items.Add("Client successfully connected to host!");
                Console.WriteLine("Manual request prompt occuring...");
                while (true)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your request", "Debug manual request", "", -1, -1);
                    if (input.ToLower() == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Client.SendLoop(input);
                    }
                }
            }
            else
            {
                clientDebugTextbox.Items.Add("Failed to connect to specified ip. Please press exit and try again.");
                Console.WriteLine("Failed to connect to specified ip. Please press exit and try again.");
            }
        }

        //Create a session button (Host Game)
        private void button2_Click(object sender, EventArgs e)
        {
            hostSessionPanel.Visible = true;
            Server.CreateServerSocket();
            //Change to panel that waits for incoming clients to join

        }


        //Client session back button
        private void button3_Click(object sender, EventArgs e)
        {
            //Clearing any client textbox related items
            clientDebugTextbox.Items.Clear();
            joinSessionPanel.Visible = false;
        }
        //Host session back button
        private void button4_Click(object sender, EventArgs e)
        {
            //Close the server socket
            hostSessionPanel.Visible = false;
            Server.closeServer();
        }

        private void hostOptionsButton_Click(object sender, EventArgs e)
        {

        }

        private void hostStartButton_Click(object sender, EventArgs e)
        {
            /* At this point, the host should close off any attempts for other clients to join.
             * Then, it makes the game board visible to itself and any connected clients.
             * Information that defines the board should be applied, as well as sent to connected clients.
             */
            gamePanel.Visible = true;
            //Send player indicator to make their game panel visible
            //Send initial info to connected players about game settings, whose turn it is

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }


}

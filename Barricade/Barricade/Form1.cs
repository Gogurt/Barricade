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

        //Join a session
        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Manual request prompt occuring...");
            //Send string request with loopSend method
            sendManualRequestPrompt();
        }

        //Create a session
        private void button2_Click(object sender, EventArgs e)
        {
           Program.CreateServerSocket();
        }

        private void sendManualRequestPrompt()
        {
            if (Program.clientSocket.Connected)
            {
                while(true)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter your request", "Debug manual request", "", -1, -1);
                    if(input == "exit")
                    {
                        break;
                    }
                    Program.SendLoop(input);
                }
            }
            else
            {
                Program.ClientConnect();
            }
        }

    }


}

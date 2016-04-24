﻿/* Barricade Network Game
 * Garrett Leatherman, Jamie Thul, Erik Canton, Matthew Leet
 * 3/31/16
 * Command Format for sending and interpreting commands between the Server and Client, like turns, connecting, disconneting, ect
 * Format: [ClientID,CommandText,Body(X,Y)OfPlay]   e.g. string cmd = "1234TURNX5Y4", the ID may have to be a larger number for socket ID
 * Client turn: "1234TURNX5Y4"
 * Client Disconnect: "1234DISC", when DISC is read, it will remove client from socket list and close socket
 * Server Disconnect: "2134SDIS", when SDIS is read by clients, the game will end
 * If we use socket for ID, then we may need to have more commands indicating server turn
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
using System.Threading;

namespace Barricade
{
    public partial class Form1 : Form
    {
        static Server server;
        static Client client;

        GameBoard gb;
        Game.Game barricade;
        Thread gameThread;
        Graphics graphics;

        public Form1()
        {
            InitializeComponent();
            server = new Server(this);
            client = new Client(this);
        }

        int c = 6; //Number of rows
        int r = 6; //Number of columns
        int dotSize = 10; //Dot size in pixels
        int lineLength = 30; //Length of a line in pixels
        int baseVerticalOffset = 30;
        int baseHorizontalOffset = 30;

        //Create array lists to hold all the board objects
        List<List<PictureBox>> boardLinesH = new List<List<PictureBox>>();
        List<List<PictureBox>> boardLinesV = new List<List<PictureBox>>();
        List<List<PictureBox>> boardBoxes = new List<List<PictureBox>>();
        List<PictureBox> boardDots = new List<PictureBox>();

        //On form load, do this...
        private void Form1_Load(object sender, EventArgs e)
        {

            //Create all the dots
            //int x = 0;
            //for (int i = 0; i < c; i++)
            //{
            //    for (int j = 0; j < r; j++)
            //    {
            //        PictureBox newBox = new PictureBox();
            //        newBox.BackColor = Color.Black;
            //        newBox.Height = dotSize;
            //        newBox.Width = dotSize;
            //        int xCoordinate = baseHorizontalOffset + i * (dotSize + lineLength);
            //        int yCoordinate = baseVerticalOffset + j * (dotSize + lineLength);
            //        newBox.Location = new Point(xCoordinate, yCoordinate);
            //        this.gamePanel.Controls.Add(newBox);
            //        boardDots.Add(newBox);
            //        x++;
            //    }
            //}

            /*Create all the boxes
             *
             * The boxes are populated in a two dimensional array
             * in the following way:
             * 00 01 02
             * 10 11 12
             * 20 21 22
             * 
             * For example, the upper right box is boardBoxes[0][2]
             */
            //for (int i = 0; i < c - 1; i++)
            //{
            //    boardBoxes.Add(new List<PictureBox>());
            //    for (int j = 0; j < r - 1; j++)
            //    {
            //        PictureBox newBox = new PictureBox();
            //        newBox.BackColor = this.BackColor; //Boxes start the same color as the form itself.
            //        newBox.Height = lineLength;
            //        newBox.Width = lineLength;
            //        int xCoordinate = baseHorizontalOffset + dotSize + i * (dotSize + lineLength);
            //        int yCoordinate = baseVerticalOffset + dotSize + j * (dotSize + lineLength);
            //        newBox.Location = new Point(xCoordinate, yCoordinate);
            //        this.gamePanel.Controls.Add(newBox);
            //        boardBoxes[i].Add(newBox);
            //    }
            //}

            /*Create all the horizontal lines
             * 
             * The lines are populated in a two dimensional array
             * in the following way:
             * 00 01 02
             * 10 11 12
             * 20 21 22
             */
            //for (int i = 0; i < c - 1; i++)
            //{
            //    boardLinesH.Add(new List<PictureBox>());
            //    for (int j = 0; j < r; j++)
            //    {
            //        PictureBox newBox = new PictureBox();
            //        newBox.BackColor = Color.WhiteSmoke;
            //        newBox.Height = dotSize;
            //        newBox.Width = lineLength;
            //        int xCoordinate = baseHorizontalOffset + dotSize + i * (dotSize + lineLength);
            //        int yCoordinate = baseVerticalOffset + j * (dotSize + lineLength);
            //        newBox.Location = new Point(xCoordinate, yCoordinate);
            //        newBox.MouseClick += Form1_MouseClick;
            //        this.gamePanel.Controls.Add(newBox);
            //        boardLinesH[i].Add(newBox);
            //    }
            //}

            /*Create all the vertical lines
             * 
             * The lines are populated in a two dimensional array
             * in the following way:
             * 00 01 02
             * 10 11 12
             * 20 21 22
             */
            //for (int i = 0; i < c; i++)
            //{
            //    boardLinesV.Add(new List<PictureBox>());
            //    for (int j = 0; j < r - 1; j++)
            //    {
            //        PictureBox newBox = new PictureBox();
            //        newBox.BackColor = Color.WhiteSmoke;
            //        newBox.Height = lineLength;
            //        newBox.Width = dotSize;
            //        int xCoordinate = baseHorizontalOffset + i * (dotSize + lineLength);
            //        int yCoordinate = baseVerticalOffset + dotSize + j * (dotSize + lineLength);
            //        newBox.Location = new Point(xCoordinate, yCoordinate);
            //        newBox.MouseClick += Form1_MouseClick;
            //        this.gamePanel.Controls.Add(newBox);
            //        boardLinesV[i].Add(newBox);
            //    }
            //}
        }

        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //This governs what happens if any picturebox is clicked.
            //PictureBox clicked = (PictureBox)sender; //Typecast
            //clicked.BackColor = Color.RoyalBlue;

            //Check horizontal lines
            //for (int i = 0; i < c - 1; i++)
            //{
            //    for (int j = 0; j < r; j++)
            //    {
            //        if (clicked.Equals((PictureBox)boardLinesH[i][j]))
            //        {
            //            gameTextbox.Items.Add("Horizontal " + (i + 1) + ", " + (j + 1) + " clicked.");
            //        }
            //    }
            //}

            ////Check vertical lines
            //for (int i = 0; i < c; i++)
            //{
            //    for (int j = 0; j < r - 1; j++)
            //    {
            //        if (clicked.Equals((PictureBox)boardLinesV[i][j]))
            //        {
            //            gameTextbox.Items.Add("Vertical " + (i + 1) + ", " + (j + 1) + " clicked.");
            //        }
            //    }
            //}

        }

        void DrawBoard()
        {
            Player[] players = new Player[3];
            players[0] = new Player("player 1", Color.Red);
            players[1] = new Player("player 2", Color.RoyalBlue);
            players[2] = new Player("player 3", Color.SeaGreen);

            gb = new GameBoard(7, 7);
            barricade = new Game.Game(players, gb);

            gameThread = new Thread(new ParameterizedThreadStart(this.StartGame));
            gameThread.Start(graphics);

            gameTextbox.Items.Add(barricade.CurrentPlayer.getName + " : " + barricade.CurrentPlayer.getScore);
        }


        void StartGame(object obj)
        {
            graphics = gamePanel.CreateGraphics();
            barricade.Start(graphics);
        }

        //BUTTONS
        //Join a session button (Join Game)
        private void button1_Click(object sender, EventArgs e)
        {
            joinSessionPanel.Visible = true;
            string ipInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the host ip. If left empty, this will attempt to connect to a local host.", "Join Host Session", "", -1, -1);
            if (ipInput.Length == 0)
            {
                clientDebugTextbox.Items.Add("Attempting to join a local host...");
            }
            else
            {
                clientDebugTextbox.Items.Add("Attempting to join " + ipInput + "...");
            }

            client.ClientConnect(ipInput);
            //Send string request with loopSend method

            if (client.isConnected())
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
                        client.SendLoop(input);
                        clientTextbox("Sending " + input);
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
            server.CreateServerSocket();
            hostSessionPanel.Visible = true;
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
            server.closeServer();

            //Back to main menu
            hostSessionPanel.Visible = false;
            hostDebugTextbox.Items.Clear();
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
            hostSessionPanel.Visible = false;
            DrawBoard();
            //Send player indicator to make their game panel visible
            //Send initial info to connected players about game settings, whose turn it is

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void exitGameButton_Click(object sender, EventArgs e)
        {
            //If clicked, send info to clients game has been manually ended
            //Disconnect socket
            //Return to main menu
            server.closeServer();
            gameTextbox.Items.Clear();
            gameThread.Abort();
            gamePanel.Visible = false;
        }

        //Textbox-related methods for other classes to access
        public void hostTextbox(string text)
        {
            hostDebugTextbox.Items.Add(text);
        }

        public void clientTextbox(string text)
        {
            clientDebugTextbox.Items.Add(text);
        }

        private void gamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            Color lineColor = barricade.CurrentPlayer.getColor;

            foreach (Line l in gb.Lines)
            {
                if (l.Rectangle.Contains(e.Location))
                {
                    if (!l.isSelected())
                    {
                        l.Select(lineColor);
                    }
                }
            }

            gameTextbox.Items.Add(barricade.CurrentPlayer.getName + " : " + barricade.CurrentPlayer.getScore);
        }
    }
}

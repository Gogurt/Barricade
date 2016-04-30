/* Barricade Network Game
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

        //Booleans
        public Boolean canPlay = true;
        public Boolean iAmTheHost = true;
        public Boolean gameContinue = true;
        public Boolean takeAnotherTurn = false;

        //The Game Board itself
        public List<List<String>> gameBoard = new List<List<String>>();

        //Create array lists to hold all the board objects
        List<List<PictureBox>> boardLinesH = new List<List<PictureBox>>();
        List<List<PictureBox>> boardLinesV = new List<List<PictureBox>>();
        List<List<PictureBox>> boardBoxes = new List<List<PictureBox>>();
        List<PictureBox> boardDots = new List<PictureBox>();

        //On form load, do this...
        private void Form1_Load(object sender, EventArgs e)
        {

            //Create all the dots
            int x = 0;
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    PictureBox newBox = new PictureBox();
                    newBox.BackColor = Color.Black;
                    newBox.Height = dotSize;
                    newBox.Width = dotSize;
                    int xCoordinate = baseHorizontalOffset + i * (dotSize + lineLength);
                    int yCoordinate = baseVerticalOffset + j * (dotSize + lineLength);
                    newBox.Location = new Point(xCoordinate, yCoordinate);
                    this.gamePanel.Controls.Add(newBox);
                    boardDots.Add(newBox);
                    x++;
                }
            }

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
            for (int i = 0; i < c - 1; i++)
            {
                boardBoxes.Add(new List<PictureBox>());
                for (int j = 0; j < r - 1; j++)
                {
                    PictureBox newBox = new PictureBox();
                    newBox.BackColor = this.BackColor; //Boxes start the same color as the form itself.
                    newBox.Height = lineLength;
                    newBox.Width = lineLength;
                    int xCoordinate = baseHorizontalOffset + dotSize + i * (dotSize + lineLength);
                    int yCoordinate = baseVerticalOffset + dotSize + j * (dotSize + lineLength);
                    newBox.Location = new Point(xCoordinate, yCoordinate);
                    this.gamePanel.Controls.Add(newBox);
                    boardBoxes[i].Add(newBox);
                }
            }

            /*Create all the horizontal lines
             * 
             * The lines are populated in a two dimensional array
             * in the following way:
             * 00 01 02
             * 10 11 12
             * 20 21 22
             */
            for (int i = 0; i < c - 1; i++)
            {
                boardLinesH.Add(new List<PictureBox>());
                for (int j = 0; j < r; j++)
                {
                    PictureBox newBox = new PictureBox();
                    newBox.BackColor = Color.WhiteSmoke;
                    newBox.Height = dotSize;
                    newBox.Width = lineLength;
                    int xCoordinate = baseHorizontalOffset + dotSize + i * (dotSize + lineLength);
                    int yCoordinate = baseVerticalOffset + j * (dotSize + lineLength);
                    newBox.Location = new Point(xCoordinate, yCoordinate);
                    newBox.MouseClick += Form1_MouseClick;
                    this.gamePanel.Controls.Add(newBox);
                    boardLinesH[i].Add(newBox);
                }
            }

            /*Create all the vertical lines
             * 
             * The lines are populated in a two dimensional array
             * in the following way:
             * 00 01 02
             * 10 11 12
             * 20 21 22
             */
            for (int i = 0; i < c; i++)
            {
                boardLinesV.Add(new List<PictureBox>());
                for (int j = 0; j < r - 1; j++)
                {
                    PictureBox newBox = new PictureBox();
                    newBox.BackColor = Color.WhiteSmoke;
                    newBox.Height = lineLength;
                    newBox.Width = dotSize;
                    int xCoordinate = baseHorizontalOffset + i * (dotSize + lineLength);
                    int yCoordinate = baseVerticalOffset + dotSize + j * (dotSize + lineLength);
                    newBox.Location = new Point(xCoordinate, yCoordinate);
                    newBox.MouseClick += Form1_MouseClick;
                    this.gamePanel.Controls.Add(newBox);
                    boardLinesV[i].Add(newBox);
                }
            }

            //Build the empty board array
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    gameBoard.Add(new List<String>());

                    //If both coordinates are even (0,2,...10)
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        //Then it's a dot.
                        gameBoard[i].Add(".");

                    }//If both coordinates are odd (1,3,...9)
                    else if ((i + 1) % 2 == 0 && (j + 1) % 2 == 0)
                    {
                        //Then it's a box.
                        gameBoard[i].Add("b");

                    }//Otherwise...
                    else
                    {
                        //Then it's a null line.
                        gameBoard[i].Add("n");
                    }
                }
            }
        }

        void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (canPlay)
            {
                //This governs what happens if any picturebox is clicked.
                PictureBox clicked = (PictureBox)sender; //Typecast
                clicked.BackColor = Color.RoyalBlue;

                //Check horizontal lines
                for (int i = 0; i < c - 1; i++)
                {
                    for (int j = 0; j < r; j++)
                    {
                        if (clicked.Equals((PictureBox)boardLinesH[i][j]))
                        {
                            //Text output
                            gameTextbox.Items.Add("Horizontal " + (i + 1) + ", " + (j + 1) + " clicked.");
                            

                            //Update the board
                            gameBoard = updateBoard("H", i, j);
                            gameTextbox.Items.Add(writeBoard(gameBoard));
                            Console.WriteLine(writeBoard(gameBoard));
                            Console.WriteLine(writeBoard(readBoard(writeBoard(gameBoard))));

                            //Broadcast the board if the host.
                            if (iAmTheHost)
                            {
                                hostBroadcastBoard();
                            }
                            else
                            {
                                clientSendBoard();
                            }

                        }
                    }
                }

                //Check vertical lines
                for (int i = 0; i < c; i++)
                {
                    for (int j = 0; j < r - 1; j++)
                    {
                        if (clicked.Equals((PictureBox)boardLinesV[i][j]))
                        {
                            //Text output
                            gameTextbox.Items.Add("Vertical " + (i + 1) + ", " + (j + 1) + " clicked.");

                            //Update the board
                            gameBoard = updateBoard("V", i, j);
                            gameTextbox.Items.Add(writeBoard(gameBoard));
                            Console.WriteLine(writeBoard(gameBoard));
                            Console.WriteLine(writeBoard(readBoard(writeBoard(gameBoard))));

                            //Broadcast the board if the host.
                            if (iAmTheHost)
                            {
                                hostBroadcastBoard();
                            }
                            else
                            {
                                clientSendBoard();
                            }

                        }
                    }
                }
            }//end if

        }

        private void DrawBoard()
        {
            //Draw the board here

            
        }


        void StartGame(object obj)
        {
            
        }

        //BUTTONS
        //Join a session button (Join Game)
        private void joinGameClickEvent(object sender, EventArgs e)
        {
            iAmTheHost = false;
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
                                
            }
            else
            {
                clientDebugTextbox.Items.Add("Failed to connect to specified ip. Please press exit and try again.");
                Console.WriteLine("Failed to connect to specified ip. Please press exit and try again.");
            }
        }

        //Create a session button (Host Game)
        private void hostButtonClickEvent(object sender, EventArgs e)
        {
            iAmTheHost = true;
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
        private void backButtonClickEvent(object sender, EventArgs e)
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

        private void hostStartButtonClickEvent(object sender, EventArgs e)
        {
            /* At this point, the host should close off any attempts for other clients to join.
             * Then, it makes the game board visible to itself and any connected clients.
             * Information that defines the board should be applied, as well as sent to connected clients.
             */
            if (server.connectedSocketList.Count != 0)
            {
                canPlay = true;
                gamePanel.Visible = true;
                hostSessionPanel.Visible = false;
            }
            //Send player indicator to make their game panel visible
            //Send initial info to connected players about game settings, whose turn it is
            server.broadcastToClients(null, "GameStart");
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void exitGameButtonClickEvent(object sender, EventArgs e)
        {
            //Check if current app user is client or host
            if(server.serverSocket != null)
            {
                //If Server, send info to clients game has been manually ended
                //Disconnect socket
                //Return to main menu
                server.closeServer();
                gameTextbox.Items.Clear();
                gameThread.Abort();
                gamePanel.Visible = false;
            }
            else
            {
                //Client should send info to server that they have disconnected from the game

            }


        }

        //Textbox-related methods for other classes to access
        public void hostTextbox(string text)
        {
            hostDebugTextbox.Items.Add(text);
        }

        public void logToGameTextbox(string text)
        {
            gameTextbox.Items.Add(text);
        }

        private void gamePanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (canPlay) // if true, that means that that person has the next turn
            {
                //Logic here for on click of a line

                canPlay = false;

                //Network related
                gameTextbox.Items.Add("Info from on click");
                //Check to see if current player is a host or client
                if(server.serverSocket != null)
                {
                    //Server send method. This is invoked because the host has made the play. Therefore, there is no need to not send
                    //this information to every connected client. That is why the first argument for a client socket is null.
                    server.broadcastToClients(null, "Turn info here e.g. x,y" );
                }
                else
                {
                    //Client send method
                    
                }
            }
            
        }

        /*
         * ============================================================================
         *                          GAME LOGIC BEGINS BELOW
         * ============================================================================
         */

        public List<List<String>> updateBoard(String d, int x, int y)
        {
            //Takes a direction and x and y coordinates in and updates the board.
            List<List<String>> board = new List<List<String>>();

            board = gameBoard;
            
            if (d.Equals("H")) //Line is horizontal
            {
                board[x*2 +1][y*2] = "|";
            }
            else //Line is vertical
            {
                board[x*2][y*2 +1] = "|";
            }

            return board;
        }

        public void updateFormBoard()
        {
            //Iterate through the whole board
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (gameBoard[i][j] == "|") //If it's a line
                    {
                        
                        if (gameBoard[i][j+1] == "." && gameBoard[i][j-1] == ".") //If it's a vertical line
                        {
                            //Color it blue
                            boardLinesV[i/2][j/2 -1].BackColor = Color.RoyalBlue;
                        }
                        else //If it's a horizontal line
                        {
                            //Color it blue
                            boardLinesH[i/2 -1][j/2].BackColor = Color.RoyalBlue;

                        }
                    }
                    else if (gameBoard[i][j] == "n") //If it's a null line
                    {
                        //Theoretically nothing happens since lines can't be removed.
                    }
                    else if (i%2 == 0 && j%2 == 0 && gameBoard[i][j] != "b") //If it's a filled box
                    {
                        //Color it appropriately to the player who scored it


                    }
                }
            }
        }

        public String writeBoard(List<List<String>> inputBoard)
        {
            //Creates a string version of the board.
            String board = "";
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    board += inputBoard[i][j] + ",";
                }
            }

            return board;
        }

        public List<List<String>> readBoard(String board)
        {
            //Takes in a string version of the board and updates the board array
            List<List<String>> newBoard = new List<List<String>>();

            //Rebuild the board
            string[] tokenBoard = board.Split(','); //Tokenize it
            int count = 0;
            for (int i = 0; i < 11; i++)
            {
                newBoard.Add(new List<String>()); //Create a new column

                for (int j = 0; j < 11; j++)
                {
                    newBoard[i].Add(tokenBoard[count]);
                    count++;
                }
            }

                return newBoard;
        }

        public void hostAssessTurn(int currentPlayer)
        {
            //We assume that all boxes have been completed.
            Boolean flag = false;
            
            //We assume that they did not score a point.
            takeAnotherTurn = false;

            //The host evaluates the board for completed boxes
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    if (gameBoard[i][j] == "b")
                    {
                        flag = true; //An empty box was found

                        //Check for a box to complete
                        if (gameBoard[i][j+1] == "|" && gameBoard[i][j-1] == "|" && gameBoard[i+1][j] == "|" && gameBoard[i-1][j] == "|")
                        {
                            //That player scored a point and gets another turn
                            gameBoard[i][j] = Convert.ToString(currentPlayer);
                            takeAnotherTurn = true;
                            flag = false;
                        }
                    }
                }
            }

            if (flag) //If we found an uncompleted box
            {
                gameContinue = true;
            }
            else
            {
                gameContinue = false;
            }

        }

        public void hostBroadcastBoard()
        {
            //Sends out the string from the writeBoard() function to the clients.
            String message = "Update" + writeBoard(gameBoard);
            Console.WriteLine(message);
            server.broadcastToClients(null, message);
        }

        public void clientSendBoard()
        {
            //Send the string from the writeBoard() function to the host.
            client.SendLoop("Update" + writeBoard(gameBoard));
        }
    }
}

namespace Barricade
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.joinSessionPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.clientDebugTextbox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hostSessionPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.hostStartButton = new System.Windows.Forms.Button();
            this.hostDebugTextbox = new System.Windows.Forms.ListBox();
            this.button4 = new System.Windows.Forms.Button();
            this.hostGameLabel = new System.Windows.Forms.Label();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.exitGameButton = new System.Windows.Forms.Button();
            this.gameTextbox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.joinSessionPanel.SuspendLayout();
            this.hostSessionPanel.SuspendLayout();
            this.gamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(16, 332);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Join Game";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(16, 399);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 59);
            this.button2.TabIndex = 1;
            this.button2.Text = "Host Game";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barricade";
            // 
            // joinSessionPanel
            // 
            this.joinSessionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.joinSessionPanel.Controls.Add(this.button3);
            this.joinSessionPanel.Controls.Add(this.clientDebugTextbox);
            this.joinSessionPanel.Controls.Add(this.label2);
            this.joinSessionPanel.Location = new System.Drawing.Point(236, 484);
            this.joinSessionPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.joinSessionPanel.Name = "joinSessionPanel";
            this.joinSessionPanel.Size = new System.Drawing.Size(676, 463);
            this.joinSessionPanel.TabIndex = 3;
            this.joinSessionPanel.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(248, 393);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(203, 59);
            this.button3.TabIndex = 6;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // clientDebugTextbox
            // 
            this.clientDebugTextbox.FormattingEnabled = true;
            this.clientDebugTextbox.ItemHeight = 16;
            this.clientDebugTextbox.Location = new System.Drawing.Point(17, 28);
            this.clientDebugTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.clientDebugTextbox.Name = "clientDebugTextbox";
            this.clientDebugTextbox.Size = new System.Drawing.Size(645, 356);
            this.clientDebugTextbox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(13, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Join Game";
            // 
            // hostSessionPanel
            // 
            this.hostSessionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.hostSessionPanel.Controls.Add(this.panel1);
            this.hostSessionPanel.Controls.Add(this.label4);
            this.hostSessionPanel.Controls.Add(this.hostStartButton);
            this.hostSessionPanel.Controls.Add(this.hostDebugTextbox);
            this.hostSessionPanel.Controls.Add(this.button4);
            this.hostSessionPanel.Controls.Add(this.hostGameLabel);
            this.hostSessionPanel.Location = new System.Drawing.Point(236, 14);
            this.hostSessionPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.hostSessionPanel.Name = "hostSessionPanel";
            this.hostSessionPanel.Size = new System.Drawing.Size(676, 465);
            this.hostSessionPanel.TabIndex = 4;
            this.hostSessionPanel.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(397, 30);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 356);
            this.panel1.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(393, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Options";
            // 
            // hostStartButton
            // 
            this.hostStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.hostStartButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hostStartButton.ForeColor = System.Drawing.SystemColors.Control;
            this.hostStartButton.Location = new System.Drawing.Point(461, 393);
            this.hostStartButton.Margin = new System.Windows.Forms.Padding(4);
            this.hostStartButton.Name = "hostStartButton";
            this.hostStartButton.Size = new System.Drawing.Size(203, 59);
            this.hostStartButton.TabIndex = 10;
            this.hostStartButton.Text = "Start Game";
            this.hostStartButton.UseVisualStyleBackColor = false;
            this.hostStartButton.Click += new System.EventHandler(this.hostStartButton_Click);
            // 
            // hostDebugTextbox
            // 
            this.hostDebugTextbox.FormattingEnabled = true;
            this.hostDebugTextbox.ItemHeight = 16;
            this.hostDebugTextbox.Location = new System.Drawing.Point(17, 28);
            this.hostDebugTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.hostDebugTextbox.Name = "hostDebugTextbox";
            this.hostDebugTextbox.Size = new System.Drawing.Size(369, 356);
            this.hostDebugTextbox.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(17, 393);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(203, 59);
            this.button4.TabIndex = 7;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // hostGameLabel
            // 
            this.hostGameLabel.AutoSize = true;
            this.hostGameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.hostGameLabel.Location = new System.Drawing.Point(13, 9);
            this.hostGameLabel.Name = "hostGameLabel";
            this.hostGameLabel.Size = new System.Drawing.Size(79, 17);
            this.hostGameLabel.TabIndex = 0;
            this.hostGameLabel.Text = "Host Game";
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.gamePanel.Controls.Add(this.exitGameButton);
            this.gamePanel.Controls.Add(this.gameTextbox);
            this.gamePanel.Controls.Add(this.label3);
            this.gamePanel.Location = new System.Drawing.Point(917, 156);
            this.gamePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(700, 470);
            this.gamePanel.TabIndex = 7;
            this.gamePanel.Visible = false;
            // 
            // exitGameButton
            // 
            this.exitGameButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.exitGameButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitGameButton.ForeColor = System.Drawing.SystemColors.Control;
            this.exitGameButton.Location = new System.Drawing.Point(16, 395);
            this.exitGameButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitGameButton.Name = "exitGameButton";
            this.exitGameButton.Size = new System.Drawing.Size(203, 59);
            this.exitGameButton.TabIndex = 13;
            this.exitGameButton.Text = "Exit Game";
            this.exitGameButton.UseVisualStyleBackColor = false;
            this.exitGameButton.Click += new System.EventHandler(this.exitGameButton_Click);
            // 
            // gameTextbox
            // 
            this.gameTextbox.FormattingEnabled = true;
            this.gameTextbox.ItemHeight = 16;
            this.gameTextbox.Location = new System.Drawing.Point(417, 28);
            this.gameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.gameTextbox.Name = "gameTextbox";
            this.gameTextbox.Size = new System.Drawing.Size(267, 356);
            this.gameTextbox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Game";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(1641, 960);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.joinSessionPanel);
            this.Controls.Add(this.hostSessionPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barricade";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.joinSessionPanel.ResumeLayout(false);
            this.joinSessionPanel.PerformLayout();
            this.hostSessionPanel.ResumeLayout(false);
            this.hostSessionPanel.PerformLayout();
            this.gamePanel.ResumeLayout(false);
            this.gamePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel joinSessionPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel hostSessionPanel;
        private System.Windows.Forms.Label hostGameLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox clientDebugTextbox;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.ListBox hostDebugTextbox;
        private System.Windows.Forms.Button hostStartButton;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.ListBox gameTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button exitGameButton;
    }
}


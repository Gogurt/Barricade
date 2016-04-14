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
            this.button4 = new System.Windows.Forms.Button();
            this.hostGameLabel = new System.Windows.Forms.Label();
            this.joinSessionPanel.SuspendLayout();
            this.hostSessionPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(12, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 48);
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
            this.button2.Location = new System.Drawing.Point(12, 324);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 48);
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
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barricade";
            // 
            // joinSessionPanel
            // 
            this.joinSessionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.joinSessionPanel.Controls.Add(this.button3);
            this.joinSessionPanel.Controls.Add(this.clientDebugTextbox);
            this.joinSessionPanel.Controls.Add(this.label2);
            this.joinSessionPanel.Location = new System.Drawing.Point(26, 71);
            this.joinSessionPanel.Margin = new System.Windows.Forms.Padding(2);
            this.joinSessionPanel.Name = "joinSessionPanel";
            this.joinSessionPanel.Size = new System.Drawing.Size(525, 382);
            this.joinSessionPanel.TabIndex = 3;
            this.joinSessionPanel.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(186, 319);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 48);
            this.button3.TabIndex = 6;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // clientDebugTextbox
            // 
            this.clientDebugTextbox.FormattingEnabled = true;
            this.clientDebugTextbox.Location = new System.Drawing.Point(13, 23);
            this.clientDebugTextbox.Name = "clientDebugTextbox";
            this.clientDebugTextbox.Size = new System.Drawing.Size(494, 290);
            this.clientDebugTextbox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(237, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Join Game";
            // 
            // hostSessionPanel
            // 
            this.hostSessionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.hostSessionPanel.Controls.Add(this.button4);
            this.hostSessionPanel.Controls.Add(this.hostGameLabel);
            this.hostSessionPanel.Location = new System.Drawing.Point(572, 37);
            this.hostSessionPanel.Margin = new System.Windows.Forms.Padding(2);
            this.hostSessionPanel.Name = "hostSessionPanel";
            this.hostSessionPanel.Size = new System.Drawing.Size(514, 378);
            this.hostSessionPanel.TabIndex = 4;
            this.hostSessionPanel.Visible = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(111)))), ((int)(((byte)(136)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.ForeColor = System.Drawing.SystemColors.Control;
            this.button4.Location = new System.Drawing.Point(13, 315);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(152, 48);
            this.button4.TabIndex = 7;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // hostGameLabel
            // 
            this.hostGameLabel.AutoSize = true;
            this.hostGameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.hostGameLabel.Location = new System.Drawing.Point(10, 7);
            this.hostGameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.hostGameLabel.Name = "hostGameLabel";
            this.hostGameLabel.Size = new System.Drawing.Size(60, 13);
            this.hostGameLabel.TabIndex = 0;
            this.hostGameLabel.Text = "Host Game";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(767, 537);
            this.Controls.Add(this.joinSessionPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hostSessionPanel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barricade";
            this.joinSessionPanel.ResumeLayout(false);
            this.joinSessionPanel.PerformLayout();
            this.hostSessionPanel.ResumeLayout(false);
            this.hostSessionPanel.PerformLayout();
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
    }
}


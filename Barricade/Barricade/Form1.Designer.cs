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
            this.label2 = new System.Windows.Forms.Label();
            this.hostSessionPanel = new System.Windows.Forms.Panel();
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
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Barricade";
            // 
            // joinSessionPanel
            // 
            this.joinSessionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.joinSessionPanel.Controls.Add(this.label2);
            this.joinSessionPanel.Location = new System.Drawing.Point(226, 2);
            this.joinSessionPanel.Name = "joinSessionPanel";
            this.joinSessionPanel.Size = new System.Drawing.Size(480, 470);
            this.joinSessionPanel.TabIndex = 3;
            this.joinSessionPanel.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(14, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Join Game";
            // 
            // hostSessionPanel
            // 
            this.hostSessionPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.hostSessionPanel.Controls.Add(this.hostGameLabel);
            this.hostSessionPanel.Location = new System.Drawing.Point(223, 2);
            this.hostSessionPanel.Name = "hostSessionPanel";
            this.hostSessionPanel.Size = new System.Drawing.Size(480, 470);
            this.hostSessionPanel.TabIndex = 4;
            this.hostSessionPanel.Visible = false;
            // 
            // hostGameLabel
            // 
            this.hostGameLabel.AutoSize = true;
            this.hostGameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.hostGameLabel.Location = new System.Drawing.Point(14, 9);
            this.hostGameLabel.Name = "hostGameLabel";
            this.hostGameLabel.Size = new System.Drawing.Size(79, 17);
            this.hostGameLabel.TabIndex = 0;
            this.hostGameLabel.Text = "Host Game";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(79)))), ((int)(((byte)(100)))));
            this.ClientSize = new System.Drawing.Size(705, 473);
            this.Controls.Add(this.hostSessionPanel);
            this.Controls.Add(this.joinSessionPanel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4);
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
    }
}


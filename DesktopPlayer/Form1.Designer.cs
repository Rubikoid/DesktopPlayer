namespace DesktopPlayer {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ToggleWork = new System.Windows.Forms.Button();
            this.DEBUG = new System.Windows.Forms.Button();
            this.ServiceName = new System.Windows.Forms.Label();
            this.PlayingStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 68);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(544, 250);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(562, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Working";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // ToggleWork
            // 
            this.ToggleWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleWork.Location = new System.Drawing.Point(562, 37);
            this.ToggleWork.Name = "ToggleWork";
            this.ToggleWork.Size = new System.Drawing.Size(75, 23);
            this.ToggleWork.TabIndex = 2;
            this.ToggleWork.Text = "Toggle work";
            this.ToggleWork.UseVisualStyleBackColor = true;
            this.ToggleWork.Click += new System.EventHandler(this.ToggleButtonClick);
            // 
            // DEBUG
            // 
            this.DEBUG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DEBUG.Location = new System.Drawing.Point(562, 66);
            this.DEBUG.Name = "DEBUG";
            this.DEBUG.Size = new System.Drawing.Size(75, 23);
            this.DEBUG.TabIndex = 3;
            this.DEBUG.Text = "DEBUG";
            this.DEBUG.UseVisualStyleBackColor = true;
            this.DEBUG.Click += new System.EventHandler(this.button2_Click);
            // 
            // ServiceName
            // 
            this.ServiceName.AutoSize = true;
            this.ServiceName.Location = new System.Drawing.Point(12, 9);
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.Size = new System.Drawing.Size(78, 13);
            this.ServiceName.TabIndex = 4;
            this.ServiceName.Text = "Service name: ";
            // 
            // PlayingStatus
            // 
            this.PlayingStatus.AutoSize = true;
            this.PlayingStatus.Location = new System.Drawing.Point(12, 22);
            this.PlayingStatus.Name = "PlayingStatus";
            this.PlayingStatus.Size = new System.Drawing.Size(116, 13);
            this.PlayingStatus.TabIndex = 5;
            this.PlayingStatus.Text = "Playing status: stopped";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 328);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PlayingStatus);
            this.Controls.Add(this.ServiceName);
            this.Controls.Add(this.DEBUG);
            this.Controls.Add(this.ToggleWork);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button ToggleWork;
        private System.Windows.Forms.Button DEBUG;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.Label ServiceName;
        public System.Windows.Forms.Label PlayingStatus;
        private System.Windows.Forms.Label label1;
    }
}


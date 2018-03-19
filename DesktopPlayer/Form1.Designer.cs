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
            this.ToggleWork = new System.Windows.Forms.Button();
            this.ServiceName = new System.Windows.Forms.Label();
            this.PlayingStatus = new System.Windows.Forms.Label();
            this.CompTitle = new System.Windows.Forms.Label();
            this.CompArtist = new System.Windows.Forms.Label();
            this.VolumeBar = new System.Windows.Forms.TrackBar();
            this.CompAlbum = new System.Windows.Forms.Label();
            this.TimeBar = new System.Windows.Forms.TrackBar();
            this.Volume = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.PrevButton = new System.Windows.Forms.Button();
            this.PlayPauseButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // ToggleWork
            // 
            this.ToggleWork.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToggleWork.Location = new System.Drawing.Point(620, 12);
            this.ToggleWork.Name = "ToggleWork";
            this.ToggleWork.Size = new System.Drawing.Size(21, 23);
            this.ToggleWork.TabIndex = 2;
            this.ToggleWork.Text = "X";
            this.ToggleWork.UseVisualStyleBackColor = true;
            this.ToggleWork.Click += new System.EventHandler(this.ToggleButtonClick);
            // 
            // ServiceName
            // 
            this.ServiceName.AutoSize = true;
            this.ServiceName.Location = new System.Drawing.Point(101, 9);
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.Size = new System.Drawing.Size(78, 13);
            this.ServiceName.TabIndex = 4;
            this.ServiceName.Text = "Service name: ";
            // 
            // PlayingStatus
            // 
            this.PlayingStatus.AutoSize = true;
            this.PlayingStatus.Location = new System.Drawing.Point(101, 22);
            this.PlayingStatus.Name = "PlayingStatus";
            this.PlayingStatus.Size = new System.Drawing.Size(116, 13);
            this.PlayingStatus.TabIndex = 5;
            this.PlayingStatus.Text = "Playing status: stopped";
            // 
            // CompTitle
            // 
            this.CompTitle.AutoSize = true;
            this.CompTitle.Location = new System.Drawing.Point(270, 9);
            this.CompTitle.Name = "CompTitle";
            this.CompTitle.Size = new System.Drawing.Size(27, 13);
            this.CompTitle.TabIndex = 6;
            this.CompTitle.Text = "Title";
            // 
            // CompArtist
            // 
            this.CompArtist.AutoSize = true;
            this.CompArtist.Location = new System.Drawing.Point(270, 22);
            this.CompArtist.Name = "CompArtist";
            this.CompArtist.Size = new System.Drawing.Size(35, 13);
            this.CompArtist.TabIndex = 7;
            this.CompArtist.Text = "Artists";
            // 
            // VolumeBar
            // 
            this.VolumeBar.Location = new System.Drawing.Point(12, 41);
            this.VolumeBar.Maximum = 100;
            this.VolumeBar.Name = "VolumeBar";
            this.VolumeBar.Size = new System.Drawing.Size(189, 45);
            this.VolumeBar.SmallChange = 10;
            this.VolumeBar.TabIndex = 8;
            this.VolumeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.VolumeBar.Scroll += new System.EventHandler(this.ValueBar_Scroll);
            // 
            // CompAlbum
            // 
            this.CompAlbum.AutoSize = true;
            this.CompAlbum.Location = new System.Drawing.Point(270, 35);
            this.CompAlbum.Name = "CompAlbum";
            this.CompAlbum.Size = new System.Drawing.Size(36, 13);
            this.CompAlbum.TabIndex = 9;
            this.CompAlbum.Text = "Album";
            // 
            // TimeBar
            // 
            this.TimeBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TimeBar.Location = new System.Drawing.Point(12, 70);
            this.TimeBar.Maximum = 10000;
            this.TimeBar.Name = "TimeBar";
            this.TimeBar.Size = new System.Drawing.Size(629, 45);
            this.TimeBar.TabIndex = 10;
            this.TimeBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.TimeBar.Scroll += new System.EventHandler(this.TimeBar_Scroll);
            // 
            // Volume
            // 
            this.Volume.AutoSize = true;
            this.Volume.Location = new System.Drawing.Point(207, 46);
            this.Volume.Name = "Volume";
            this.Volume.Size = new System.Drawing.Size(42, 13);
            this.Volume.TabIndex = 11;
            this.Volume.Text = "Volume";
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(73, 8);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(22, 23);
            this.NextButton.TabIndex = 12;
            this.NextButton.Text = ">";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PrevButton
            // 
            this.PrevButton.Location = new System.Drawing.Point(12, 8);
            this.PrevButton.Name = "PrevButton";
            this.PrevButton.Size = new System.Drawing.Size(22, 23);
            this.PrevButton.TabIndex = 13;
            this.PrevButton.Text = "<";
            this.PrevButton.UseVisualStyleBackColor = true;
            this.PrevButton.Click += new System.EventHandler(this.PrevButton_Click);
            // 
            // PlayPauseButton
            // 
            this.PlayPauseButton.Location = new System.Drawing.Point(40, 8);
            this.PlayPauseButton.Name = "PlayPauseButton";
            this.PlayPauseButton.Size = new System.Drawing.Size(27, 23);
            this.PlayPauseButton.TabIndex = 14;
            this.PlayPauseButton.Text = "<>";
            this.PlayPauseButton.UseVisualStyleBackColor = true;
            this.PlayPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(591, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 105);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.PlayPauseButton);
            this.Controls.Add(this.PrevButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.Volume);
            this.Controls.Add(this.TimeBar);
            this.Controls.Add(this.CompAlbum);
            this.Controls.Add(this.VolumeBar);
            this.Controls.Add(this.CompArtist);
            this.Controls.Add(this.CompTitle);
            this.Controls.Add(this.PlayingStatus);
            this.Controls.Add(this.ServiceName);
            this.Controls.Add(this.ToggleWork);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VolumeBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ToggleWork;
        public System.Windows.Forms.Label ServiceName;
        public System.Windows.Forms.Label PlayingStatus;
        public System.Windows.Forms.Label CompTitle;
        public System.Windows.Forms.Label CompArtist;
        public System.Windows.Forms.Label CompAlbum;
        public System.Windows.Forms.TrackBar VolumeBar;
        public System.Windows.Forms.TrackBar TimeBar;
        public System.Windows.Forms.Label Volume;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button PrevButton;
        public System.Windows.Forms.Button PlayPauseButton;
        private System.Windows.Forms.Button button1;
    }
}


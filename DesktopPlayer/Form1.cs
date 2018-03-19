//#define debug
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DesktopPlayer {
    public partial class Form1 : Form {
#if debug
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button DEBUG;
#endif

        BrowserIO bio;
        public Worker worker;
        private NotifyIcon notifyIcon;
        private KeyboardHook kbh = new KeyboardHook();
        public Form1() {
            InitializeComponent();
#if debug
            // 
            // DEBUG
            //
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.DEBUG = new System.Windows.Forms.Button();
            
            this.DEBUG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DEBUG.Location = new System.Drawing.Point(620, 41);
            this.DEBUG.Name = "DEBUG";
            this.DEBUG.Size = new System.Drawing.Size(21, 23);
            this.DEBUG.TabIndex = 3;
            this.DEBUG.Text = "D";
            this.DEBUG.UseVisualStyleBackColor = true;
            this.DEBUG.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 121);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(629, 20);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";

            this.Controls.Add(this.DEBUG);
            this.Controls.Add(this.richTextBox1);

            Helper.RichTextBoxStore.rtb = this.richTextBox1;
#endif
            this.bio = new BrowserIO(this);
#if debug
            this.bio.onMessageReciving += (obj, msg) => {
                Helper.RichTextBoxStore.WriteLine(msg);
            };
#endif
            this.worker = new Worker(this, this.bio);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.play_64;
            notifyIcon.Click += notifyIcon_Click;

            kbh.KeyPressed += new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);

            kbh.RegisterHotKey(DesktopPlayer.ModifierKeys.Control | DesktopPlayer.ModifierKeys.Alt, Keys.Up);
            kbh.RegisterHotKey(DesktopPlayer.ModifierKeys.Control | DesktopPlayer.ModifierKeys.Alt, Keys.Down);
            kbh.RegisterHotKey(DesktopPlayer.ModifierKeys.Control | DesktopPlayer.ModifierKeys.Alt, Keys.Left);
            kbh.RegisterHotKey(DesktopPlayer.ModifierKeys.Control | DesktopPlayer.ModifierKeys.Alt, Keys.Right);
            kbh.RegisterHotKey(DesktopPlayer.ModifierKeys.Control | DesktopPlayer.ModifierKeys.Alt, Keys.Home);
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e) {
            if(e.Modifier == (DesktopPlayer.ModifierKeys.Alt | DesktopPlayer.ModifierKeys.Control)) {
                if(e.Key == Keys.Up) {
                    if(this.VolumeBar.Value > 90)
                        this.VolumeBar.Value = 100;
                    else
                        this.VolumeBar.Value += 10;
                    this.ValueBar_Scroll(null, null);
                }
                if(e.Key == Keys.Down) {
                    if(this.VolumeBar.Value < 10)
                        this.VolumeBar.Value = 0;
                    else
                        this.VolumeBar.Value -= 10;
                    this.ValueBar_Scroll(null, null);
                }
                if(e.Key == Keys.Right)
                    this.NextButton_Click(null, null);
                if(e.Key == Keys.Left)
                    this.PrevButton_Click(null, null);
                if(e.Key == Keys.Home)
                    this.PlayPauseButton_Click(null, null);
            }
        }

        private void OnProcessExit(object sender, EventArgs e) {
            this.kbh.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.bio.work = true;
        }

        private void ToggleButtonClick(object sender, EventArgs e) {
            this.bio.work = !this.bio.work;
        }


#if debug
        private void button2_Click(object sender, EventArgs e) {
            //this.bio.SendMessage("{ \"command\": \"CMD_TEST\", \"argument\": \"ARG_TEST\"}");
            var a = 0;
        }
        //debug
#endif
        private void ValueBar_Scroll(object sender, EventArgs e) {
            double value = this.VolumeBar.Value / 100.0;
            this.bio.SendMessage("{ \"command\": \"volume\", \"argument\": "+value.ToString().Replace(",",".")+"}");
        }

        private void TimeBar_Scroll(object sender, EventArgs e) {
            string message = this.worker.GetPositionMessage();
            this.bio.SendMessage(message);
        }

        private void PrevButton_Click(object sender, EventArgs e) {
            this.bio.SendMessage("{ \"command\": \"previous\"}");
        }

        private void PlayPauseButton_Click(object sender, EventArgs e) {
            this.bio.SendMessage("{ \"command\": \"playPause\"}");
        }

        private void NextButton_Click(object sender, EventArgs e) {
            this.bio.SendMessage("{ \"command\": \"next\"}");
        }

        private void button1_Click(object sender, EventArgs e) {
            notifyIcon.Visible = true;
            //this.Hide();
            this.Visible = false;
            this.ShowInTaskbar = false;
        }

        private void notifyIcon_Click(object sender, EventArgs e) {
            //this.Show();
            this.Visible = true;
            notifyIcon.Visible = false;
            this.ShowInTaskbar = true;
        }
    }
}

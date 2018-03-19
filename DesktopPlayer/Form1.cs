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
        BrowserIO bio;
        public Worker worker;
        public Form1() {
            InitializeComponent();
            Helper.RichTextBoxStore.rtb = this.richTextBox1;
            this.bio = new BrowserIO(this);
            this.bio.onMessageReciving += (obj, msg) => {
                Helper.RichTextBoxStore.WriteLine(msg);
            };
            this.worker = new Worker(this, this.bio);
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.bio.work = true;
        }

        private void ToggleButtonClick(object sender, EventArgs e) {
            this.bio.work = !this.bio.work;
        }


        //debug
        private void button2_Click(object sender, EventArgs e) {
            //this.bio.SendMessage("{ \"command\": \"CMD_TEST\", \"argument\": \"ARG_TEST\"}");
            var a = 0;
        }
        //debug
    }
}

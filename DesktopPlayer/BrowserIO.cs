using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DesktopPlayer {
    public class BrowserIO {
        private bool _work;
        private Form1 form;
        private Thread reciverThread;
        private Thread senderThread;
        private BlockingQueue<string> sendingQueue;
        public delegate void ReciveMessage(dynamic obj, string msg);
        public event ReciveMessage onMessageReciving;

        public bool work {
            get {
                return this._work;
            }
            set {
                this._work = value;
                this.form.checkBox1.Invoke((MethodInvoker)delegate () { this.form.checkBox1.Checked = value; });
                if(this._work) {
                    this.StartReciverThread();
                    this.StartSenderThread();
                }
                if(!this._work) {
                    this.sendingQueue.StopWaiting();
                }
            }
        }

        public BrowserIO(Form1 form) {
            this.form = form;
            this.sendingQueue = new BlockingQueue<string>();
        }

        public void SendMessage(string msg) {
            this.sendingQueue.Enqueue(msg);
        }

        public void StartSenderThread() {
            if(this.senderThread == null || this.senderThread.IsAlive) {
                this.senderThread = new Thread(() => {
                    this.sendingQueue.Start();
                    this.Sender();
                });
                this.senderThread.Start();
            }
        }

        public void Sender() {
            Helper.RichTextBoxStore.WriteLine("Started sender");
            Stream stdout = Console.OpenStandardOutput();
            while(this.work) {
                string next = this.sendingQueue.Dequeue();
                if(next == default(string))
                    break;
                int DataLength = next.Length;
                stdout.WriteByte((byte)((DataLength >> 0) & 0xFF));
                stdout.WriteByte((byte)((DataLength >> 8) & 0xFF));
                stdout.WriteByte((byte)((DataLength >> 16) & 0xFF));
                stdout.WriteByte((byte)((DataLength >> 24) & 0xFF));
                Console.Write(next);
            }
            stdout.Close();
            Helper.RichTextBoxStore.WriteLine("Stopped sender");
            Application.Exit();
        }

        public void StartReciverThread() {
            if(this.reciverThread == null || this.reciverThread.IsAlive) {
                this.reciverThread = new Thread(() => {
                    this.Reciver();
                });
                this.reciverThread.Start();
            }
        }

        public void Reciver() {
            Helper.RichTextBoxStore.WriteLine("Started reciver");
            Stream stdin = Console.OpenStandardInput();
            while(this.work) {
                int length = 0;
                byte[] bytes = new byte[4];
                stdin.Read(bytes, 0, 4);
                length = BitConverter.ToInt32(bytes, 0);
                if(length == 0) {
                    this.work = false;
                    break;
                }

                string input = "";
                for(int i = 0; i < length; i++) {
                    input += (char)stdin.ReadByte();
                }
                dynamic recivedObject = JsonConvert.DeserializeObject(input);
                this.onMessageReciving(recivedObject, input);
            }
            stdin.Close();
            Helper.RichTextBoxStore.WriteLine("Stopped reciver");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopPlayer {
    class Helper {
        public static class RichTextBoxStore {
            public static RichTextBox rtb;

            public static void WriteLine(string line) {
                if(rtb != null)
                    rtb.Invoke((MethodInvoker)delegate () { rtb.AppendText(line + "\n"); });
            }

            public static void WriteLineTime(string line) {
                WriteLine((DateTime.Now.ToString()+"::"+line));
            }
        }
    }
}

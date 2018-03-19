using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopPlayer {
    public class Worker {
        private Form1 form;
        private BrowserIO bio;
        private Composition currentCompos;

        public Worker(Form1 form, BrowserIO bio) {
            this.form = form;
            this.bio = bio;
            this.bio.onMessageReciving += this.MessageRecived;
        }

        public void MessageRecived(dynamic obj, string msg) {
            switch(obj["name"].ToString()) {
                case "playbackStatus":
                    this.form.PlayingStatus.Text = "Playing status: " + obj["value"].ToString();
                    break;
                case "currentTime":
                    break;
                case "trackInfo":
                    this.currentCompos = new Composition();
                    this.currentCompos.title = obj["value"]["title"];
                    this.currentCompos.album = obj["value"]["album"] == null ? "no album" : obj["value"]["album"];
                    this.currentCompos.url = obj["value"]["url"] == null ? "" : obj["value"]["url"];
                    this.currentCompos.length = obj["value"]["length"] == null ? -1 : obj["value"]["length"];
                    break;
                case "volume":
                    break;
                case "properties":
                    break;
                case "name":
                    this.form.ServiceName.Text = "Service name: " + obj["value"].ToString();
                    break;
                case null:
                default:
                    break;
            }
        }

        class Composition {
            public string[] artist;
            public string title;
            public string album;
            public string url;
            public double length;
            public string artUrl;
            public string trackId;

            public double currentTime;
        }
    }
}

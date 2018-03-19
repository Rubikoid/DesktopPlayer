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
        private string playingStatus = "stopped";

        public Worker(Form1 form, BrowserIO bio) {
            this.form = form;
            this.bio = bio;
            this.bio.onMessageReciving += this.MessageRecived;
        }

        public void MessageRecived(dynamic obj, string msg) {
            switch(obj["name"].ToString()) {
                case "playbackStatus":
                    this.playingStatus = obj["value"].ToString();
                    this.form.PlayingStatus.Text = "Playing status: " + playingStatus;
                    if(this.playingStatus == "playing")
                        this.form.PlayPauseButton.Text = "||";
                    else
                        this.form.PlayPauseButton.Text = "<>";
                    break;
                case "currentTime":
                    if(this.currentCompos != null) {
                        this.currentCompos.currentTime = obj["value"];
                        double perc = this.currentCompos.currentTime / this.currentCompos.length * 100;
                        this.form.TimeBar.Value = (int)perc >= 0 ? (int)perc * 100 : 0;
                    }
                    break;
                case "trackInfo":
                    this.currentCompos = new Composition();
                    this.currentCompos.title = obj["value"]["title"];
                    this.currentCompos.album = obj["value"]["album"] == null ? "no album" : obj["value"]["album"];
                    this.currentCompos.url = obj["value"]["url"] == null ? "" : obj["value"]["url"];
                    this.currentCompos.length = obj["value"]["length"] == null ? -1 : obj["value"]["length"];
                    this.currentCompos.artUrl = obj["value"]["artUrl"] == null ? "" : obj["value"]["artUrl"];
                    this.currentCompos.trackId = obj["value"]["trackId"] == null ? "" : obj["value"]["trackId"];
                    if(obj["value"]["artist"] is string[])
                        this.currentCompos.artist = obj["value"]["artist"];
                    else
                        this.currentCompos.artist = new string[] { obj["value"]["artist"] };
                    this.currentCompos.print(this.form);
                    break;
                case "volume":
                    this.form.VolumeBar.Value = obj["value"] * 100;
                    this.form.Volume.Text = (obj["value"] * 100).ToString() + "%";
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

        public double GetTiming() {
            double perc = this.form.TimeBar.Value * this.currentCompos.length / 100;
            return perc >= 0 ? perc / 100 : 0;
        }

        public string GetPositionMessage() {
            var value = this.GetTiming();
            return "{ \"command\": \"setPosition\", \"argument\": {\"trackId\": \"" + this.currentCompos.trackId + "\", \"position\":" + value.ToString().Replace(",", ".") + "}}";
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

            public void print(Form1 form) {
                form.CompTitle.Text = "Title: " + this.title;
                form.CompArtist.Text = "Artists: " + String.Join(",", this.artist);
                form.CompAlbum.Text = "Album: " + this.album;
            }
        }
    }
}

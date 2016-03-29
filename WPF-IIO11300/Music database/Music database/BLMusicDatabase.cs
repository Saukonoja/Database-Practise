using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase {
    public class Artist {
        
        private static string cs = "datasource = mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1";
        #region PROPERTIES

        private int avain;
        public int Avain {
            get { return avain; }
        }

        private string nimi;
        public string Nimi {
            get { return nimi; }
            set { nimi = value; }
        }

        private string maa;
        public string Maa {
            get { return maa; }
            set { maa = value; }
        }

        private int vuosi;
        public int Vuosi {
            get { return vuosi; }
            set { vuosi = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Artist(int avain) {
            this.avain = avain;
        }
        public Artist(string nimi, string maa, int vuosi) {
            this.nimi = nimi;
            this.maa = maa;
            this.vuosi = vuosi;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return nimi;
        }

        public static List<Artist> GetArtists() {
            try {
                DataTable dt;
                List<Artist> artists = new List<Artist>();
                dt = DBMusicDatabase.GetArtists(cs);

                Artist artist;
                foreach (DataRow row in dt.Rows) {
                    artist = new Artist(int.Parse(row["avain"].ToString()));
                    artist.Nimi = row["nimi"].ToString();


                    artists.Add(artist);
                }
                return artists;
            }catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }
}

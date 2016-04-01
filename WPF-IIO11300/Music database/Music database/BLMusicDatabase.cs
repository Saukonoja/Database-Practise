﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase {
    public class Artist {
        
        private static string cs = "datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1";
        #region PROPERTIES

        private int key;
        public int Key {
            get { return key; }
            set { key = value; }
        }

        private string name;
        public string Name {
            get { return name; }
            set { name = value; }
        }

        private string country;
        public string Country {
            get { return country; }
            set { country = value; }
        }

        private int year;
        public int Year {
            get { return year; }
            set { year = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Artist(int key) {
            this.key = key;
        }
        public Artist(int key, string name, string country, int year) {
            this.key = key;
            this.name = name;
            this.country = country;
            this.year = year;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }

        public static List<Artist> GetArtists() {
            try {
                DataTable dt;
                List<Artist> artists = new List<Artist>();
                dt = DBMusicDatabase.GetArtists(cs);

                Artist artist;
                foreach (DataRow row in dt.Rows) {
                    artist = new Artist((int)row[0]);
                    artist.Name = row["nimi"].ToString();
                    artist.Country = row["maa_avain"].ToString();
                    artist.Year = (int)row["vuosi_avain"];

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

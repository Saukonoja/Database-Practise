using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDatabase {
    public class Artist {
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

        public static DataTable GetArtistAlbums(string name) {
            try {
                DataTable artistAlbums = DBMusicDatabase.GetEntity(DBSQLQueries.GetArtistAlbums(), name, "ArtistPage");
                return artistAlbums;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable GetArtists() {
            try {
                DataTable artistTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetArtists(), "Artists");
                return artistTable;
            } catch (Exception ex) {
                throw ex;
            }
        }


        public static bool AddNewArtist(string name, string country, int year) {
            try {
                DBMusicDatabase.AddNewArtist(DBSQLQueries.AddArtist(), name, country, year);
                return true;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
         public static bool DeleteArtist(string name) {
             try {
                int deleted = DBMusicDatabase.DeleteArtist(DBSQLQueries.DeleteArtist(), name);
                if (deleted == 1)
                    return true;
                else
                    return false;
             }
             catch (Exception ex) {

                 throw ex;
             }
         }
        public static bool UpdateArtist(int selectedKey, string name, string country, int year) {
            try {
               DBMusicDatabase.UpdateArtist(DBSQLQueries.UpdateArtist(), selectedKey, name, country, year);
                return true;
               
            } catch (Exception ex) {

                throw ex;
            }
        }
        public static int GetSelectedArtistKey(string selectedName) {
            int selectedKey = DBMusicDatabase.GetSelectedKey(DBSQLQueries.GetSelectedArtistKey(), selectedName);
            return selectedKey;
        }
        #endregion
    }
    public class Album {

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

        private string company;
        public string Company {
            get { return company; }
            set { company = value; }
        }

        private int year;
        public int Year {
            get { return year; }
            set { year = value; }
        }

        private string imgpath;
        public string Imgpath {
            get { return imgpath; }
            set { imgpath = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Album(int key) {
            this.key = key;
        }
        public Album(int key, string name, string company, int year, string imgpath) {
            this.key = key;
            this.name = name;
            this.company = company;
            this.year = year;
            this.imgpath = imgpath;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }

        public static DataTable GetAlbums() {
            try {
                DataTable albumsTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetAlbums(), "Albums");
                return albumsTable;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable GetAlbumTracks(string name) {
            try {
                DataTable trackTable = DBMusicDatabase.GetEntity(DBSQLQueries.GetAlbumTracks(), name, "Tracks");
                return trackTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }
    public class Track {
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

        private string length;
        public string Length {
            get { return length; }
            set { length = value; }
        }

        private string artist;
        public string Artist {
            get { return artist; }
            set { artist = value; }
        }

        private int year;
        public int Year {
            get { return year; }
            set { year = value; }
        }

        private string tubepath;
        public string Tubepath {
            get { return tubepath; }
            set { tubepath = value; }
        }

        private int number;
        public int Number {
            get { return number; }
            set { number = value; }
        }
        #endregion
        #region CONSTRUCTOR

        public Track(int key) {
            this.key = key;
        }
        public Track(int key, string name, string length, string artist, int year, string tubepath, int number) {
            this.key = key;
            this.name = name;
            this.length = length;
            this.artist = artist;
            this.year = year;
            this.tubepath = tubepath;
            this.number = number;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }
        public static DataTable GetTracks() {
            try {
                DataTable tracksTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetTracks(), "Tracks");
                return tracksTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }
    public class Genre {
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
        #endregion
        #region CONSTRUCTOR

        public Genre(int key) {
            this.key = key;
        }
        public Genre(int key, string name) {
            this.key = key;
            this.name = name;
        }
        #endregion
        #region METHODS
        public override string ToString() {
            return name;
        }
        public static DataTable GetGenres() {
            try {
                DataTable genresTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetGenres(), "Genres");
                return genresTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }

    public class Company {
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

        public Company(int key) {
            this.key = key;
        }
        public Company(int key, string name, string country, int year) {
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
        public static DataTable GetCompanies() {
            try {
                DataTable companiesTable = DBMusicDatabase.GetEntities(DBSQLQueries.GetCompanies(), "Companies");
                return companiesTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }
}
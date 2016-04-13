using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicDatabase {
    public class Artist {
        #region METHODS
        public static DataTable GetArtists() {
            try {
                DataTable artistTable = DBMusicDatabase.GetTable(DBSQLQueries.GetArtists(), "Artists");
                return artistTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable GetArtistAlbums(string name) {
            try {
                DataTable artistAlbums = DBMusicDatabase.GetSpecificTable(DBSQLQueries.GetArtistAlbums(), name, "ArtistPage");
                return artistAlbums;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddArtist(string name, string country, int year) {
            try {
                string fill = "1";
                DBMusicDatabase.AddRow(DBSQLQueries.AddArtist(), int.Parse(fill), name, fill, fill, fill, country, year, fill, int.Parse(fill), fill, fill, fill);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteArtist(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteRow(DBSQLQueries.DeleteArtist(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool UpdateArtist(int key, string name, string country, int year) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateRow(DBSQLQueries.UpdateArtist(), key, name, fill, fill, fill, country, year, fill, fill, int.Parse(fill), fill, fill);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static List<string> GetComboBoxArtists() {
            try {
                List<string> comboArtists = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxArtists());
                return comboArtists;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable SearchArtist(string srcparam) {
            DataTable resultTable = DBMusicDatabase.SearchTable(DBSQLQueries.SearchArtist(), srcparam, "Result");
            return resultTable;
        }
        #endregion
    }
    public class Album {
        #region METHODS
        public static DataTable GetAlbums() {
            try {
                DataTable albumsTable = DBMusicDatabase.GetTable(DBSQLQueries.GetAlbums(), "Albums");
                return albumsTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable GetAlbumTracks(string name) {
            try {
                DataTable trackTable = DBMusicDatabase.GetSpecificTable(DBSQLQueries.GetAlbumTracks(), name, "Tracks");
                return trackTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static string GetImageUrl(string album) {
            try {
                string imageUrl = DBMusicDatabase.GetImageUrl(DBSQLQueries.GetImageUrl(), album);
                return imageUrl;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static string GetAlbumName(string track) {
            try {
                string albumName = DBMusicDatabase.GetAlbumName(DBSQLQueries.GetAlbumName(), track);
                return albumName;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddAlbum(string name, string artist, string company, int year, string imageLink) {
            try {
                string fill = "1";
                DBMusicDatabase.AddRow(DBSQLQueries.AddAlbum(), int.Parse(fill), name, artist, fill, company, fill, year, imageLink, fill, int.Parse(fill), fill, fill);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static List<string> GetAlbumInfo(string album) {
            try {
                List<string> array = DBMusicDatabase.GetAlbumInfo(DBSQLQueries.GetAlbumInfo(), album);
                return array;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteAlbum(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteRow(DBSQLQueries.DeleteAlbum(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdateAlbum(int key, string name, string artist, string company, int year, string imageLink) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateRow(DBSQLQueries.UpdateAlbum(), key, name, artist, fill, company, fill, year, imageLink, fill, int.Parse(fill), fill, fill);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static List<string> GetComboBoxAlbums() {
            try {
                List<string> comboAlbums = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxAlbums());
                return comboAlbums;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable SearchAlbum(string srcparam) {
            DataTable resultTable = DBMusicDatabase.SearchTable(DBSQLQueries.SearchAlbum(), srcparam, "Result");
            return resultTable;
        }
        #endregion
    }
    public class Track {
        #region METHODS
        public static DataTable GetTracks() {
            try {
                DataTable tracksTable = DBMusicDatabase.GetTable(DBSQLQueries.GetTracks(), "Tracks");
                return tracksTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static string GetTrackTubepath(string track) {
            try {
                string tubepath = DBMusicDatabase.GetTrackTubepath(DBSQLQueries.GetTrackTubepath(), track);
                return tubepath;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddTrack(string name, string artist, int year, string album, string genre, string link, int number, string length) {
            try {
                string fill = "1";
                DBMusicDatabase.AddRow(DBSQLQueries.AddTrack(), int.Parse(fill), name, artist, album, fill, fill, year, fill, link, number, length, genre);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteTrack(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteRow(DBSQLQueries.DeleteTrack(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdateTrack(int key, string name, string artist, int year, string album, string link, int number, string length, string genre) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateRow(DBSQLQueries.UpdateTrack(), key, name, artist, album, fill, fill, year, fill, link, number, length, genre);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static DataTable SearchTrack(string srcparam) {
            DataTable resultTable = DBMusicDatabase.SearchTable(DBSQLQueries.SearchTrack(), srcparam, "Result");
            return resultTable;
        }

        #endregion
    }
    public class Genre {
        #region METHODS
        public static DataTable GetGenres() {
            try {
                DataTable genresTable = DBMusicDatabase.GetTable(DBSQLQueries.GetGenres(), "Genres");
                return genresTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddGenre(string name) {
            try {
                string fill = "1";
                DBMusicDatabase.AddRow(DBSQLQueries.AddGenre(), int.Parse(fill), name, fill, fill, fill, fill, int.Parse(fill), fill, fill, int.Parse(fill), fill, fill);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteGenre(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteRow(DBSQLQueries.DeleteGenre(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdateGenre(int key, string name) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateRow(DBSQLQueries.UpdateGenre(), key, name, fill, fill, fill, fill, int.Parse(fill), fill, fill, int.Parse(fill), fill, fill);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static DataTable GetGenreTracks(string name) {
            try {
                DataTable genreTracks = DBMusicDatabase.GetSpecificTable(DBSQLQueries.GetGenreTracks(), name, "Tracks");
                return genreTracks;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static List<string> GetComboBoxGenres() {
            try {
                List<string> comboGenres = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxGenres());
                return comboGenres;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable SearchGenre(string srcparam) {
            DataTable resultTable = DBMusicDatabase.SearchTable(DBSQLQueries.SearchGenre(), srcparam, "Result");
            return resultTable;
        }
        #endregion
    }
    public class Company {
        #region METHODS
        public static DataTable GetCompanies() {
            try {
                DataTable companiesTable = DBMusicDatabase.GetTable(DBSQLQueries.GetCompanies(), "Companies");
                return companiesTable;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool AddCompany(string name, string country, int year) {
            try {
                string fill = "1";
                DBMusicDatabase.AddRow(DBSQLQueries.AddCompany(), int.Parse(fill), name, fill, fill, fill, country, year, fill, fill, int.Parse(fill), fill, fill);
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool DeleteCompany(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteRow(DBSQLQueries.DeleteCompany(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdateCompany(int key, string name, string country, int year) {
            try {
                string fill = "1";
                DBMusicDatabase.UpdateRow(DBSQLQueries.UpdateCompany(), key, name, fill, fill, fill, country, year, fill, fill, int.Parse(fill), fill, fill);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static DataTable GetCompanyAlbums(string name) {
            try {
                DataTable companyAlbums = DBMusicDatabase.GetSpecificTable(DBSQLQueries.GetCompanyAlbums(), name, "Albums");
                return companyAlbums;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static List<string> GetComboBoxCompanies() {
            try {
                List<string> comboCompanies = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxCompanies());
                return comboCompanies;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable SearchCompanies(string srcparam) {
            DataTable resultTable = DBMusicDatabase.SearchTable(DBSQLQueries.SearchCompanies(), srcparam, "Result");
            return resultTable;
        }
        #endregion
    }
    public class Users {
        #region METHODS
        public static DataTable GetUsers() {
            try {
                DataTable users = DBMusicDatabase.GetTable(DBSQLQueries.GetUsers(), "Users");
                return users;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool UpdateUser(int key, string name, bool admin) {
            try {
                DBMusicDatabase.UpdateUser(DBSQLQueries.UpdateUser(), key, name, admin);
                return true;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool DeleteUser(int key) {
            try {
                int deleted = DBMusicDatabase.DeleteUser(DBSQLQueries.DeleteUser(), key);
                if (deleted == 1)
                    return true;
                else
                    return false;
            } catch (Exception ex) {

                throw ex;
            }
        }
        public static bool UpdatePassword(string username, string password) {
            try {
                DBMusicDatabase.UpdatePassword(DBSQLQueries.UpdatePassword(), username, password);
                return true;
            } catch (Exception ex) {

                throw ex;
            }
        }
        public static List<string> GetComboBoxCountries() {
            try {
                List<string> comboCountries = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxCountries());
                return comboCountries;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static List<string> GetComboBoxYears() {
            try {
                List<string> comboYears = DBMusicDatabase.GetCombobox(DBSQLQueries.GetComboBoxYears());
                return comboYears;
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
    #endregion
}

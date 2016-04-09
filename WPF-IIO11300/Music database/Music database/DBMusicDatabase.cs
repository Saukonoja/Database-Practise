using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDatabase {
    public class DBMusicDatabase {
        private static string connStr = MusicDatabase.Properties.Settings.Default.Database;


        public static DataTable GetEntity(string sqlString, string tableName) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds, tableName);
                conn.Close();
                return ds.Tables[tableName];
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable GetEntities(string sqlString, string tableName) {

            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds, tableName);
                conn.Close();
                return ds.Tables[tableName];
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable GetEntity(string sqlString, string name, string tableName) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@NAME", name);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds, tableName);
                conn.Close();
                return ds.Tables[tableName];
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static void AddNewArtist(string sqlString, string name, string country, int year) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@COUNTRY", country);
                cmd.Parameters.AddWithValue("@YEAR", year);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {

                throw ex;
            }
        }
        public static int DeleteEntity(string sqlString, int key) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", key);
                int deleted = cmd.ExecuteNonQuery();
                return deleted;

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static void UpdateArtist(string sqlString, int key, string name, string country, int year) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", key);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@COUNTRY", country);
                cmd.Parameters.AddWithValue("@YEAR", year);
                cmd.ExecuteNonQuery();

            } catch (Exception ex) {

                throw ex;
            }
        }
        public static void UpdateUser(string sqlString, int key, string name, bool admin) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", key);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@ADMIN", admin);
                cmd.ExecuteNonQuery();

            } catch (Exception ex) {

                throw ex;
            }
        }


        public static void AddAlbum(string sqlString, string name, string artist, string company, int year, string imageLink) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@ARTIST", artist);
                cmd.Parameters.AddWithValue("@COMPANY", company);
                cmd.Parameters.AddWithValue("@YEAR", year);
                cmd.Parameters.AddWithValue("@IMAGELINK", imageLink);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static int DeleteUser(string sqlString, int key) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", key);
                int deleted = cmd.ExecuteNonQuery();
                return deleted;

            } catch (Exception ex) {

                throw ex;
            }
        }

        public static void UpdateAlbum(string sqlString, int key, string name, string artist, string company, int year) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", key);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@ARTIST", artist);
                cmd.Parameters.AddWithValue("@COMPANY", company);
                cmd.Parameters.AddWithValue("@YEAR", year);
                cmd.ExecuteNonQuery();

            } catch (Exception ex) {

                throw ex;
            }
        }

        public static string GetTrackTubepath(string sqlString, string track) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                string tubepath = "";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@track", track);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) {
                    while (rdr.Read()) {
                        tubepath = rdr.GetString(0);
                    }
                }
                conn.Close();
                return tubepath;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetAlbumInfo(string sqlString, string album) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                List<string> array = new List<string>();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@album", album);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) {
                    while (rdr.Read()) {
                        for (int i = 0; i < 4; i++) {
                            array.Add(rdr.GetString(i));
                        }
                    }
                }
                conn.Close();
                return array;
            } catch (Exception ex) {

                throw ex;
            }
        }
        public static void UpdateEntity(string sqlString, int key, string name, string artist, string album, string company, 
            string country, int year, string imageLink, string tubeLink, int number, int length) {

            try {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", key);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@ARTIST", artist);
                cmd.Parameters.AddWithValue("@ALBUM", album);
                cmd.Parameters.AddWithValue("@COMPANY", company);
                cmd.Parameters.AddWithValue("@COUNTRY", country);
                cmd.Parameters.AddWithValue("@YEAR", year);
                cmd.Parameters.AddWithValue("@IMAGELINK", imageLink);
                cmd.Parameters.AddWithValue("@TUBELINK", tubeLink);
                cmd.Parameters.AddWithValue("@NUMBER", number);
                cmd.Parameters.AddWithValue("@LENGTH", length);
                cmd.ExecuteNonQuery();

            } catch (Exception ex) {
                throw ex;
            }
        }

        public static string GetImageUrl(string sqlString, string album) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;

                string imageUrl = "";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@album", album);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) {
                    while (rdr.Read()) {
                        imageUrl = rdr.GetString(0);
                    }
                }
                conn.Close();
                return imageUrl;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static string GetAlbumName(string sqlString, string track) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                string albumName = "";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@track", track);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows) {
                    while (rdr.Read()) {
                        albumName = rdr.GetString(0);
                    }
                }
                conn.Close();
                return albumName;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static void AddEntity(string sqlString, int key, string name, string artist, string album, string company, string country, int year, string link, int number, int length) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", key);
                cmd.Parameters.AddWithValue("@NAME", name);
                cmd.Parameters.AddWithValue("@ARTIST", artist);
                cmd.Parameters.AddWithValue("@ALBUM", album);
                cmd.Parameters.AddWithValue("@COMPANY", company);
                cmd.Parameters.AddWithValue("@COUNTRY", country);
                cmd.Parameters.AddWithValue("@YEAR", year);
                cmd.Parameters.AddWithValue("@LINK", link);
                cmd.Parameters.AddWithValue("@NUMBER", number);
                cmd.Parameters.AddWithValue("@LENGTH", length);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static bool RegisterUser(string username, string password, out string message) {
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    message = "";
                    bool exists = false;
                    conn.Open();
                    string sql = "select * from user where tunnus=@username";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read()) {
                        if (dr.HasRows == true) {
                            message = "User already exists!";
                            exists = true;
                            break;
                        }
                    }
                    dr.Close();
                    if (!exists) {
                        string sql2 = "insert into user (tunnus, salasana, tyyppi) values(@username, @password, false)";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@password", password);

                        int rowAdd = cmd2.ExecuteNonQuery();
                        if (rowAdd == 1) {
                            return true;
                        }
                    }
                    conn.Close();
                    return false;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static bool LoginUser(string username, string password, out string message) {
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    message = "";
                    conn.Open();
                    string passwordCrypted = "";
                    string passwordClean = "";
                    string sql = "select salasana from user where tunnus=@username";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            passwordCrypted = rdr.GetString(0);
                        }
                    }
                    passwordClean = BLLogin.Decrypt(passwordCrypted);
                    rdr.Close();
                    conn.Close();
                    if (passwordClean == password) {
                        return true;
                    }
                    message = "Username or password is invalid!";
                    return false;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static void UpdatePassword(string sqlString, string username, string password) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                string passW = BLRegister.EncryptPassword(password);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@USERNAME", username);
                cmd.Parameters.AddWithValue("@PASSWORD", passW);
                cmd.ExecuteNonQuery();

            } catch (Exception ex) {

                throw ex;
            }
        }

        public static bool CheckIfAdmin(string username) {
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    conn.Open();
                    bool admin = false;
                    string sql = "select tyyppi from user where tunnus=@username";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            admin = rdr.GetBoolean(0);
                        }
                    }

                    conn.Close();
                    return admin;

                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetCountries() {
            List<string> countries = new List<string>();
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    conn.Open();
                    string sql = "select nimi from maa order by nimi;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            countries.Add(rdr.GetString(0));
                        }
                    }

                    conn.Close();
                    return countries;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetArtists() {
            List<string> artists = new List<string>();
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    conn.Open();
                    string sql = "select nimi from esittaja order by nimi;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            artists.Add(rdr.GetString(0));
                        }
                    }
                    conn.Close();
                    return artists;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetAlbums() {
            List<string> albums = new List<string>();
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    conn.Open();
                    string sql = "select nimi from cd order by nimi;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            albums.Add(rdr.GetString(0));
                        }
                    }
                    conn.Close();
                    return albums;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        public static List<string> GetCompanies() {
            List<string> companies = new List<string>();
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    conn.Open();
                    string sql = "select nimi from yhtio order by nimi;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            companies.Add(rdr.GetString(0));
                        }
                    }
                    conn.Close();
                    return companies;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static List<string> GetYears() {
            List<string> years = new List<string>();
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    conn.Open();
                    string sql = "select vuosi from vuosi order by vuosi;";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            years.Add(rdr.GetString(0));
                        }
                    }
                    conn.Close();
                    return years;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

    } //end of class
}

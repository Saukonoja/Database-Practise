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
        #region BASIC CRUD
        public static DataTable GetTable(string sqlString, string tableName) {
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
        public static int DeleteRow(string sqlString, int key) {
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
        public static void UpdateRow(string sqlString, params object[] parameters) {
            try {
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", parameters[0]);
                cmd.Parameters.AddWithValue("@NAME", parameters[1]);
                cmd.Parameters.AddWithValue("@ARTIST", parameters[2]);
                cmd.Parameters.AddWithValue("@ALBUM", parameters[3]);
                cmd.Parameters.AddWithValue("@COMPANY", parameters[4]);
                cmd.Parameters.AddWithValue("@COUNTRY", parameters[5]);
                cmd.Parameters.AddWithValue("@YEAR", parameters[6]);
                cmd.Parameters.AddWithValue("@IMAGELINK", parameters[7]);
                cmd.Parameters.AddWithValue("@TUBELINK", parameters[8]);
                cmd.Parameters.AddWithValue("@NUMBER", parameters[9]);
                cmd.Parameters.AddWithValue("@LENGTH", parameters[10]);
                cmd.Parameters.AddWithValue("@GENRE", parameters[11]);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static void AddRow(string sqlString, params object[] parameters) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", parameters[0]);
                cmd.Parameters.AddWithValue("@NAME", parameters[1]);
                cmd.Parameters.AddWithValue("@ARTIST", parameters[2]);
                cmd.Parameters.AddWithValue("@ALBUM", parameters[3]);
                cmd.Parameters.AddWithValue("@COMPANY", parameters[4]);
                cmd.Parameters.AddWithValue("@COUNTRY", parameters[5]);
                cmd.Parameters.AddWithValue("@YEAR", parameters[6]);
                cmd.Parameters.AddWithValue("@IMAGELINK", parameters[7]);
                cmd.Parameters.AddWithValue("@TUBELINK", parameters[8]);
                cmd.Parameters.AddWithValue("@NUMBER", parameters[9]);
                cmd.Parameters.AddWithValue("@LENGTH", parameters[10]);
                cmd.Parameters.AddWithValue("@GENRE", parameters[11]);
                cmd.ExecuteNonQuery();
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable SearchTable(string sqlString, string srcparam, string tableName) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SRC", srcparam);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds, tableName);
                conn.Close();
                return ds.Tables[tableName];
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
        #region USER
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
        #endregion
        #region SPECIFIC
        public static DataTable GetSpecificTable(string sqlString, string name, string tableName) {
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
        public static List<string> GetCombobox(string stringSQL) {
            List<string> comboBox = new List<string>();
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    conn.Open();
                    string sql = stringSQL;
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            comboBox.Add(rdr.GetString(0));
                        }
                    }
                    conn.Close();
                    return comboBox;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        #endregion
    }
}

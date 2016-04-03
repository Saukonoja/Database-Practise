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

        public static DataSet GetDataset(string sqlString) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception ex) {
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
        public static void AddNewArtist(string sqlString, string name, string country, int year){
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
            }
            catch (Exception ex) {
                
                throw ex;
            }
         }
        public static int DeleteArtist(string sqlString, int key) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try {
                conn.Open();
                string sql = sqlString;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@KEY", key);
                int deleted = cmd.ExecuteNonQuery();
                return deleted;
                
            }
            catch (Exception ex) {
               
                throw ex;
            }
        }

        public static DataTable GetArtistList() {
            try {
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    string sql = "SELECT avain, nimi, maa_avain, vuosi_avain FROM esittaja";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Artists");
                    da.Fill(dt);
                    conn.Close();
                    return dt;
                }

            }
            catch (Exception ex) {

                throw ex;
            }
        }
    } //end of class
}

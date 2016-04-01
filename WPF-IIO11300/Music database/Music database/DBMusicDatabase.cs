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
        public static DataTable GetArtists(string connStr) {
            try {              
                using (MySqlConnection conn = new MySqlConnection(connStr)) {
                    string sql = "select nimi, vuosi_avain, maa_avain from esittaja ";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable("Artists");
                    msda.Fill(dt);
                    conn.Close();
                    return dt;
                }

            } catch (Exception ex) {
                throw ex;
            }
        }
        public static bool RegisterUser(byte[] hash, string hashPassword, string username, out string message, string connStr) {
            try {
                hashPassword = BitConverter.ToString(hash).Replace("-", "");
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
                            message = "user already exists";
                            exists = true;
                            dr.Close();
                            break;
                        }
                    }
                    if (!exists) {
                        string sql2 = "insert into user (tunnus, salasana, tyyppi) values(@username2, @hashPassword, false)";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd.Parameters.AddWithValue("@username2", username);
                        cmd.Parameters.AddWithValue("@hashPassword", hashPassword);

                        int rowAdd = cmd.ExecuteNonQuery();
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
    }
}

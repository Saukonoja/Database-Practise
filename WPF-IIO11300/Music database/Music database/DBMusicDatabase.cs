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
                    string sql = "select esittaja.nimi as Esittaja, vuosi.vuosi as Perustamisvuosi, maa.nimi as Maa from esittaja left join vuosi on esittaja.vuosi_avain = vuosi.avain left join maa on esittaja.maa_avain = maa.avain;";
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    msda.Fill(ds, "Artists");
                    conn.Close();
                    return ds.Tables["Artists"];
                }

            } catch (Exception ex) {
                throw ex;
            }
        }
         public static bool RegisterUser(byte [] hash, string username, string connStr, out string message) {
            string hashPassword;
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
                        if(dr.HasRows == true) {
                            message = "user already exists";
                            exists = true;
                            break;
                        }
                    }
                    dr.Close();
                    if (!exists) {
                        string sql2 = "insert into user (tunnus, salasana, tyyppi) values(@username, @hashPassword, false)";
                        MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                        cmd2.Parameters.AddWithValue("@username", username);
                        cmd2.Parameters.AddWithValue("@hashPassword", hashPassword);

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
    }
}

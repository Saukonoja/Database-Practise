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
    }
}

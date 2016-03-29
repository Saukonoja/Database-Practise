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
                    string sql = "SELECT "+
                        "esittaja.avain, "+
                        "esittaja.nimi, "+
                        "vuosi.vuosi,"+ 
                        "maa.nimi "+
                        "from esittaja "+ 
                        "left join vuosi on esittaja.vuosi_avain = vuosi.avain "+
                        "left join maa on esittaja.maa_avain = maa.avain;";
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

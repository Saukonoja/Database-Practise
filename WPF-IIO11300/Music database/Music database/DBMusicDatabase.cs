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
        public static DataTable GetArtists() {
            MySqlConnection conn = new MySqlConnection("datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1");
            try {
                    conn.Open();
                    string sql = "SELECT " + 
                                            "esittaja.nimi as Esittaja, " + 
                                            "vuosi.vuosi as Perustamisvuosi, " + 
                                            "maa.nimi as Maa " +
                                 "FROM esittaja " + 
                                 "left join vuosi on esittaja.vuosi_avain = vuosi.avain " + 
                                 "left join maa on esittaja.maa_avain = maa.avain; ";
                    
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    msda.Fill(ds, "Artists");
                    conn.Close();
                    return ds.Tables["Artists"];
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable GetAlbums() {
            MySqlConnection conn = new MySqlConnection("datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1");
            try {
                conn.Open();
                string sql = "SELECT " +
                                        "cd.nimi as Levy, " +
                                        "esittaja.nimi as Esittaja, " +
                                        "vuosi.vuosi as Julkaisuvuosi, " +
                                        "yhtio.nimi as Yhtio " +
                             "FROM cd " +
                             "left join cd_esittaja on cd_esittaja.cd_avain = cd.avain " +
                             "left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain " +
                             "left join vuosi on cd.vuosi_avain = vuosi.avain " +
                             "left join yhtio on cd.yhtio_avain = yhtio.avain;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds, "Albums");
                conn.Close();
                return ds.Tables["Albums"];
            }
            catch (Exception ex) {
                throw ex;
            }
        }
        public static DataTable GetTracks() {
            MySqlConnection conn = new MySqlConnection("datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1");
            try {
                conn.Open();
                string sql = "SELECT " +
                                        "kappale.nimi as Kappale, " +
                                        "esittaja.nimi as Esittaja, " +
                                        "cd.nimi as Levy, " +
                                        "vuosi.vuosi as Julkaisuvuosi " +
                             "FROM cd " +
                             "left join cd_kappale on cd_kappale.cd_avain = cd.avain " +
                             "left join kappale on cd_kappale.kappale_avain = kappale.avain " +
                             "left join esittaja on kappale.esittaja_avain = esittaja.avain " +
                             "left join vuosi on kappale.vuosi_avain = vuosi.avain " +
                             "GROUP BY kappale.nimi;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds, "Tracks");
                conn.Close();
                return ds.Tables["Tracks"];
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable GetGenres() {
            MySqlConnection conn = new MySqlConnection("datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1");
            try {
                conn.Open();
                string sql = "SELECT " +
                                        "genre.nimi as Genre " +
                             "FROM genre " +
                             "GROUP BY genre.nimi;" ;

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds, "Genres");
                conn.Close();
                return ds.Tables["Genres"];
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public static DataTable GetCompanies() {
            MySqlConnection conn = new MySqlConnection("datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1");
            try {
                conn.Open();
                string sql = "SELECT " +
                                        "yhtio.nimi as Levyyhtio, " +
                                        "maa.nimi as Maa, " +
                                        "vuosi.vuosi as Perustamisvuosi " +
                             "FROM yhtio " +
                             "left join maa on yhtio.maa_avain = maa.avain " +
                             "left join vuosi on yhtio.vuosi_avain = vuosi.avain " +
                             "GROUP BY yhtio.nimi;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                msda.Fill(ds, "Companies");
                conn.Close();
                return ds.Tables["Companies"];
            }
            catch (Exception ex) {
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

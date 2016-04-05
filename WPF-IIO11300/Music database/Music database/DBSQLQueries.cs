using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase {
    public class DBSQLQueries {

        public static string GetArtists() {
            string getArtists = "SELECT " +
                                            "esittaja.avain as Avain, " +
                                            "esittaja.nimi as Esittaja, " +
                                            "vuosi.vuosi as Perustamisvuosi, " +
                                            "maa.nimi as Maa " +
                                "FROM esittaja " +
                                "left join vuosi on esittaja.vuosi_avain = vuosi.avain " +
                                "left join maa on esittaja.maa_avain = maa.avain; ";
            return getArtists;
        }

        public static string GetAlbums() {
            string getAlbums = "SELECT " +
                                        "cd.nimi as Levy, " +
                                        "esittaja.nimi as Esittaja, " +
                                        "vuosi.vuosi as Julkaisuvuosi, " +
                                        "yhtio.nimi as Yhtio " +
                                "FROM cd " +
                                "left join cd_esittaja on cd_esittaja.cd_avain = cd.avain " +
                                "left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain " +
                                "left join vuosi on cd.vuosi_avain = vuosi.avain " +
                                "left join yhtio on cd.yhtio_avain = yhtio.avain;";
            return getAlbums;
        }

        public static string GetTracks() {
            string getTracks = "SELECT " +
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
            return getTracks;
        }

        public static string GetGenres() {
            string getGenres = "SELECT " +
                                        "genre.nimi as Genre " +
                               "FROM genre " +
                               "GROUP BY genre.nimi;";
            return getGenres;
        }

        public static string GetCompanies() {
            string getCompanies = "SELECT " +
                                        "yhtio.nimi as Levyyhtio, " +
                                        "maa.nimi as Maa, " +
                                        "vuosi.vuosi as Perustamisvuosi " +
                               "FROM yhtio " +
                               "left join maa on yhtio.maa_avain = maa.avain " +
                               "left join vuosi on yhtio.vuosi_avain = vuosi.avain " +
                               "GROUP BY yhtio.nimi;";
            return getCompanies;
        }

        public static string AddArtist() {
            string addArtist = "INSERT INTO esittaja (nimi, maa_avain, vuosi_avain) " +
                                 "VALUES (@NAME, " +
                                 "(SELECT avain FROM maa WHERE nimi = @COUNTRY), " +
                                 "(SELECT avain FROM vuosi WHERE vuosi = @YEAR));";
            return addArtist;
        }
        public static string DeleteArtist() {
            string deleteArtist = "DELETE FROM esittaja WHERE avain = @KEY;";
            return deleteArtist;
        }
    }// end off class
}

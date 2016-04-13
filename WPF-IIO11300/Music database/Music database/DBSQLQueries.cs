using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase {
    public class DBSQLQueries {
        #region ARTIST
        public static string GetArtists() {
            string getArtists = "SELECT " +
                                            "esittaja.nimi as Artist, " +
                                            "vuosi.vuosi as Year, " +
                                            "maa.nimi as Country, " +
                                            "esittaja.avain as ID " +
                                "FROM esittaja " +
                                "left join vuosi on esittaja.vuosi_avain = vuosi.avain " +
                                "left join maa on esittaja.maa_avain = maa.avain " +
                                "GROUP BY esittaja.nimi;";
            return getArtists;
        }
        public static string SearchArtist() {
            string searchArtist = "SELECT " +
                                            "esittaja.nimi as Artist, " +
                                            "vuosi.vuosi as Year, " +
                                            "maa.nimi as Country, " +
                                            "esittaja.avain as ID " +
                                "FROM esittaja " +
                                "left join vuosi on esittaja.vuosi_avain = vuosi.avain " +
                                "left join maa on esittaja.maa_avain = maa.avain " +
                                "WHERE esittaja.nimi LIKE @SRC " +
                                "OR vuosi.vuosi LIKE @SRC " +
                                "OR maa.nimi LIKE @SRC " +
                                "GROUP BY esittaja.nimi;";
            return searchArtist;
        }
        public static string AddArtist() {
            string addArtist = "INSERT INTO esittaja (nimi, maa_avain, vuosi_avain) " +
                                 "VALUES (@NAME, " +
                                 "(SELECT avain FROM maa WHERE nimi = @COUNTRY), " +
                                 "(SELECT avain FROM vuosi WHERE vuosi = @YEAR));";
            return addArtist;
        }
        public static string DeleteArtist() {
            string deleteArtist = "SET FOREIGN_KEY_CHECKS = 0; DELETE FROM cd_esittaja WHERE esittaja_avain = @KEY; DELETE FROM esittaja WHERE avain = @KEY; SET FOREIGN_KEY_CHECKS = 1; ";
            return deleteArtist;
        }
        public static string UpdateArtist() {
            string updateArtist = "UPDATE esittaja " +
                                  "SET nimi = @NAME, " +
                                  "maa_avain = (SELECT avain from maa WHERE nimi = @COUNTRY), " +
                                  "vuosi_avain = (SELECT avain from vuosi where vuosi = @YEAR) " +
                                  "WHERE avain = @KEY ";
            return updateArtist;
        }
        public static string GetArtistAlbums() {
            string artistAlbums = "select " +
                                       "cd.nimi as Album, " +
                                       "vuosi.vuosi as Year, " +
                                       "yhtio.nimi as Company " +
                                  "from cd " +
                                  "left join cd_esittaja on cd_esittaja.cd_avain = cd.avain " +
                                  "left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain " +
                                  "left join vuosi on cd.vuosi_avain = vuosi.avain " +
                                  "left join yhtio on cd.yhtio_avain = yhtio.avain " +
                                  "where cd_esittaja.esittaja_avain = (select avain from esittaja where nimi = @NAME);";
            return artistAlbums;
        }
        #endregion
        #region ALBUM
        public static string GetAlbums() {
            string getAlbums = "SELECT " +
                                        "cd.nimi as Album, " +
                                        "esittaja.nimi as Artist, " +
                                        "vuosi.vuosi as Year, " +
                                        "yhtio.nimi as Company, " +
                                        "cd.kuvapath as Imagelink, " +
                                        "cd.avain as ID " +
                                "FROM cd " +
                                "left join cd_esittaja on cd_esittaja.cd_avain = cd.avain " +
                                "left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain " +
                                "left join vuosi on cd.vuosi_avain = vuosi.avain " +
                                "left join yhtio on cd.yhtio_avain = yhtio.avain " +
                                "GROUP BY cd.nimi";
            return getAlbums;
        }
        public static string SearchAlbum() {
            string searchAlbums = "SELECT " +
                                        "cd.nimi as Album, " +
                                        "esittaja.nimi as Artist, " +
                                        "vuosi.vuosi as Year, " +
                                        "yhtio.nimi as Company, " +
                                        "cd.kuvapath as Imagelink, " +
                                        "cd.avain as ID " +
                                "FROM cd " +
                                "left join cd_esittaja on cd_esittaja.cd_avain = cd.avain " +
                                "left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain " +
                                "left join vuosi on cd.vuosi_avain = vuosi.avain " +
                                "left join yhtio on cd.yhtio_avain = yhtio.avain " +
                                "WHERE cd.nimi LIKE @SRC " +
                                "OR esittaja.nimi LIKE @SRC " +
                                "OR vuosi.vuosi LIKE @SRC " +
                                "OR yhtio.nimi LIKE @SRC " +
                                "GROUP BY cd.nimi;";
            return searchAlbums;
        }
        public static string DeleteAlbum() {
            string deleteArtist = "SET FOREIGN_KEY_CHECKS = 0; DELETE FROM cd_esittaja WHERE cd_avain = @KEY;" +
                                  "DELETE FROM kappale where avain = (SELECT kappale_avain FROM cd_kappale WHERE cd_avain = @KEY);" +
                                  "DELETE FROM cd_kappale WHERE cd_avain = @KEY;" + 
                                  "DELETE FROM cd WHERE avain = @KEY; SET FOREIGN_KEY_CHECKS = 1;";
            return deleteArtist;
        }
        public static string AddAlbum() {
            string addAlbum = "INSERT INTO cd (nimi, yhtio_avain, vuosi_avain, kuvapath) " +
                                 "VALUES (@NAME, " +
                                 "(SELECT avain FROM yhtio WHERE nimi = @COMPANY), " +
                                 "(SELECT avain FROM vuosi WHERE vuosi = @YEAR), @IMAGELINK); " +
                                 "INSERT INTO cd_esittaja (cd_avain, esittaja_avain) " +
                                 "VALUES (" +
                                 "(SELECT avain FROM cd WHERE nimi = @NAME), " +
                                 "(SELECT avain FROM esittaja WHERE nimi = @ARTIST));";
            return addAlbum;
        }
        public static string UpdateAlbum() {
            string updateAlbum = "UPDATE cd " +
                                 "SET nimi = @NAME, " +
                                 "yhtio_avain = (SELECT avain FROM yhtio WHERE nimi = @COMPANY), " +
                                 "vuosi_avain = (SELECT avain FROM vuosi WHERE vuosi = @YEAR), " +
                                 "kuvapath = @IMAGELINK " +
                                 "WHERE avain = @KEY;" +
                                 "UPDATE cd_esittaja " +
                                 "SET esittaja_avain = (SELECT avain FROM esittaja WHERE nimi = @ARTIST)" +
                                 "WHERE cd_avain = @KEY;";
            return updateAlbum;
        }
        public static string GetAlbumTracks() {
            string albumTracks = "select " +
                                        "kappale.numero as '#', " +
                                        "kappale.nimi as Track, " +
                                        "kappale.kesto as Length " +
                                 "from cd " +
                                 "left join cd_kappale on cd_kappale.cd_avain = cd.avain " +
                                 "left join kappale on cd_kappale.kappale_avain = kappale.avain " +
                                 "where cd_kappale.cd_avain = (select avain from cd where nimi = @NAME) " +
                                 "group by kappale.numero;";
            return albumTracks;
        }
        public static string GetAlbumInfo() {
            string albumInfo = "select " +
                                        "esittaja.nimi as Artist, " +
                                        "vuosi.vuosi as Julkaisuvuosi, " +
                                        "count(kappale.nimi), " +
                                        "SEC_TO_TIME(SUM(TIME_TO_SEC(kappale.kesto))) AS Length " +
                                "from cd " +
                                "left join cd_kappale on cd_kappale.cd_avain = cd.avain " +
                                "left join kappale on cd_kappale.kappale_avain = kappale.avain " +
                                "left join esittaja on kappale.esittaja_avain = esittaja.avain " +
                                "left join vuosi on kappale.vuosi_avain = vuosi.avain " +
                                "where cd_kappale.cd_avain = (select avain from cd where nimi = @ALBUM);";
            return albumInfo;
        }
        public static string GetAlbumName() {
            string albumName = "select " +
                                        "cd.nimi " +
                                "from kappale " +
                                "left join cd_kappale on cd_kappale.kappale_avain = kappale.avain " +
                                "left join cd on cd_kappale.cd_avain = cd.avain " +
                                "where cd_kappale.kappale_avain = (select avain from kappale where nimi = @track);";
            return albumName;
        }
        public static string GetImageUrl() {
            string imageUrl = "select kuvapath from cd where nimi = @album";
            return imageUrl;
        }
        #endregion
        #region TRACKS
        public static string GetTracks() {
            string getTracks = "SELECT " +
                                        "kappale.nimi as Track, " +
                                        "esittaja.nimi as Artist, " +
                                        "cd.nimi as Album, " +
                                        "vuosi.vuosi as Year, " +
                                        "kappale.tubepath as TubeLink, " +
                                        "kappale.numero as '#', " +
                                        "kappale.kesto as Length, " +
                                        "genre.nimi as Genre, " +
                                        "kappale.avain as ID " +
                               "FROM cd " +
                               "left join cd_kappale on cd_kappale.cd_avain = cd.avain " +
                               "left join kappale on cd_kappale.kappale_avain = kappale.avain " +
                               "left join kappale_genre on kappale_genre.kappale_avain = kappale.avain " +
                               "left join genre on kappale_genre.genre_avain = genre.avain " +
                               "left join esittaja on kappale.esittaja_avain = esittaja.avain " +
                               "left join vuosi on kappale.vuosi_avain = vuosi.avain " +
                               "WHERE kappale.nimi is not null " +
                               "GROUP BY kappale.nimi;";
            return getTracks;
        }
        public static string SearchTrack() {
            string getTracks = "SELECT " +
                                        "kappale.nimi as Track, " +
                                        "esittaja.nimi as Artist, " +
                                        "cd.nimi as Album, " +
                                        "vuosi.vuosi as Year, " +
                                        "kappale.tubepath as TubeLink, " +
                                        "kappale.numero as '#', " +
                                        "kappale.kesto as Length, " +
                                        "genre.nimi as Genre, " +
                                        "kappale.avain as ID " +
                               "FROM cd " +
                               "left join cd_kappale on cd_kappale.cd_avain = cd.avain " +
                               "left join kappale on cd_kappale.kappale_avain = kappale.avain " +
                               "left join kappale_genre on kappale_genre.kappale_avain = kappale.avain " +
                               "left join genre on kappale_genre.genre_avain = genre.avain " +
                               "left join esittaja on kappale.esittaja_avain = esittaja.avain " +
                               "left join vuosi on kappale.vuosi_avain = vuosi.avain " +
                               "WHERE kappale.nimi LIKE @SRC " +
                               "OR esittaja.nimi LIKE @SRC " +
                               "OR cd.nimi LIKE @SRC " +
                               "OR vuosi.vuosi LIKE @SRC " +
                               "OR kappale.numero LIKE @SRC " +
                               "OR genre.nimi LIKE @SRC " +
                               "GROUP BY kappale.nimi;";
            return getTracks;
        }
        public static string AddTrack() {
            string addTrack = "INSERT INTO kappale (nimi, kesto, esittaja_avain, vuosi_avain, tubepath, numero) " +
                                 "VALUES (@NAME, @LENGTH, " +
                                 "(SELECT avain FROM esittaja WHERE nimi = @ARTIST), " +
                                 "(SELECT avain FROM vuosi WHERE vuosi = @YEAR), @TUBELINK, @NUMBER); " +
                                 "INSERT INTO cd_kappale (cd_avain, kappale_avain) " +
                                 "VALUES ((SELECT avain FROM cd WHERE nimi = @ALBUM), " +
                                 "(SELECT avain FROM kappale WHERE nimi = @NAME));" +
                                 "INSERT INTO kappale_genre (kappale_avain, genre_avain) " +
                                 "VALUES ((SELECT avain FROM kappale WHERE nimi = @NAME), " +
                                 "(SELECT avain from genre WHERE nimi = @GENRE));";

            return addTrack;
        }
        public static string DeleteTrack() {
            string deleteTrack = "DELETE FROM kappale_genre where kappale_avain = @KEY; DELETE FROM cd_kappale WHERE kappale_avain = @KEY; DELETE FROM kappale WHERE avain = @KEY;";
            return deleteTrack;
        }
        public static string UpdateTrack() {
            string updateTrack = "UPDATE kappale " +
                                 "SET nimi = @NAME, " +
                                 "esittaja_avain = (SELECT avain FROM esittaja WHERE nimi = @ARTIST), " +
                                 "vuosi_avain = (SELECT avain FROM vuosi WHERE vuosi = @YEAR), " +
                                 "tubepath = @TUBELINK, " +
                                 "numero = @NUMBER, " +
                                 "kesto = @LENGTH " +
                                 "WHERE avain = @KEY; " +
                                 "UPDATE cd_kappale " +
                                 "SET cd_avain = (SELECT avain FROM cd WHERE nimi = @ALBUM) " +
                                 "WHERE kappale_avain = @KEY; " +
                                 "UPDATE kappale_genre " +
                                 "SET genre_avain = (SELECT avain FROM genre where nimi = @GENRE) " +
                                 "WHERE kappale_avain = @KEY;";
            return updateTrack;
        }
        public static string GetTrackTubepath() {
            string tubepath = "select tubepath from kappale where nimi = @track";
            return tubepath;
        }
        #endregion
        #region GENRE
        public static string GetGenres() {
            string getGenres = "SELECT " +
                               "genre.nimi as Genre, " +
                               "genre.avain as ID " +
                               "FROM genre " +
                               "GROUP BY genre.nimi;";
            return getGenres;
        }
        public static string SearchGenre() {
            string getGenres = "SELECT " +
                               "genre.nimi as Genre, " +
                               "genre.avain as ID " +
                               "FROM genre " +
                               "WHERE genre.nimi LIKE @SRC" +
                               "GROUP BY genre.nimi;";
            return getGenres;
        }
        public static string AddGenre() {
            string addGenre = "INSERT INTO genre (nimi) " +
                                 "VALUES (@NAME);";
            return addGenre;
        }
        public static string DeleteGenre() {
            string deleteGenre = "DELETE FROM kappale_genre WHERE genre_avain = @KEY; DELETE FROM genre WHERE avain = @KEY;";
            return deleteGenre;
        }
        public static string UpdateGenre() {
            string updateGenre = "UPDATE genre " +
                                 "SET nimi = @NAME " +
                                 "WHERE avain = @KEY;";
            return updateGenre;
        }
        public static string GetGenreTracks() {
            string genreTracks = "select " +
                                    "kappale.nimi as Track, " +
                                    "esittaja.nimi as Artist, " +
                                    "cd.nimi as Album, " +
                                    "vuosi.vuosi as Year " +
                                "from cd " +
                                "left join cd_kappale on cd_kappale.cd_avain = cd.avain " +
                                "left join kappale on cd_kappale.kappale_avain = kappale.avain " +
                                "left join esittaja on kappale.esittaja_avain = esittaja.avain " +
                                "left join vuosi on kappale.vuosi_avain = vuosi.avain " +
                                "left join kappale_genre on kappale_genre.kappale_avain = kappale.avain " +
                                "left join genre on kappale_genre.genre_avain = genre.avain " +
                                "where genre.nimi = @NAME " +
                                "order by kappale.nimi;";
            return genreTracks;
        }
        #endregion
        #region COMPANY
        public static string GetCompanies() {
            string getCompanies = "SELECT " +
                                        "yhtio.nimi as Company, " +
                                        "maa.nimi as Country, " +
                                        "vuosi.vuosi as Year, " +
                                        "yhtio.avain as ID " +
                               "FROM yhtio " +
                               "left join maa on yhtio.maa_avain = maa.avain " +
                               "left join vuosi on yhtio.vuosi_avain = vuosi.avain " +
                               "GROUP BY yhtio.nimi;";
            return getCompanies;
        }
        public static string SearchCompanies() {
            string getCompanies = "SELECT " +
                                        "yhtio.nimi as Company, " +
                                        "maa.nimi as Country, " +
                                        "vuosi.vuosi as Year, " +
                                        "yhtio.avain as ID " +
                               "FROM yhtio " +
                               "left join maa on yhtio.maa_avain = maa.avain " +
                               "left join vuosi on yhtio.vuosi_avain = vuosi.avain " +
                               "WHERE yhtio.nimi LIKE @SRC " +
                               "OR maa.nimi LIKE @SRC " +
                               "OR vuosi.vuosi LIKE @SRC " +
                               "GROUP BY yhtio.nimi;";
            return getCompanies;
        }
        public static string AddCompany() {
            string addCompany = "INSERT INTO yhtio (nimi, maa_avain, vuosi_avain) " +
                                 "VALUES (@NAME, " +
                                 "(SELECT avain FROM maa WHERE nimi = @COUNTRY), " +
                                 "(SELECT avain FROM vuosi WHERE vuosi = @YEAR));";
            return addCompany;
        }
        public static string DeleteCompany() {
            string deleteCompany = "SET FOREIGN_KEY_CHECKS = 0; DELETE FROM yhtio WHERE avain = @KEY; SET FOREIGN_KEY_CHECKS = 1;";
            return deleteCompany;
        }
        public static string UpdateCompany() {
            string updateCompany = "UPDATE yhtio " +
                                 "SET nimi = @NAME, " +
                                 "maa_avain = (SELECT avain FROM maa WHERE nimi = @COUNTRY), " +
                                 "vuosi_avain = (SELECT avain FROM vuosi WHERE vuosi = @YEAR) " +
                                 "WHERE avain = @KEY;";
            return updateCompany;
        }
        public static string GetCompanyAlbums() {
            string companyAlbums = "select " +
                                        "cd.nimi as Album, " +
                                        "esittaja.nimi as Artist, " +
                                        "vuosi.vuosi as Year " +
                                    "from cd " +
                                    "left join cd_esittaja on cd_esittaja.cd_avain = cd.avain " +
                                    "left join esittaja on cd_esittaja.esittaja_avain = esittaja.avain " +
                                    "left join vuosi on cd.vuosi_avain = vuosi.avain " +
                                    "left join yhtio on cd.yhtio_avain = yhtio.avain " +
                                    "where cd.yhtio_avain = (select avain from yhtio where nimi = @name); ";
            return companyAlbums;
        }
        #endregion
        #region USER
        public static string GetUsers() {
            string users = "select tunnus as Username, tyyppi as Admin, avain as ID from user;";
            return users;
        }
        public static string UpdateUser() {
            string updateUser = "UPDATE user " +
                                  "SET tunnus = @NAME, " +
                                  "tyyppi = @ADMIN " +
                                  "WHERE avain = @KEY ";
            return updateUser;
        }
        public static string DeleteUser() {
            string deleteUser = "DELETE FROM user WHERE avain = @KEY";
            return deleteUser;
        }
        public static string UpdatePassword() {
            string updatePassword = "update user set salasana = @PASSWORD where tunnus = @USERNAME";
            return updatePassword;
        }
        #endregion
        #region COMBOBOX
        public static string GetComboBoxYears() {
            string comboYears = "select vuosi from vuosi order by vuosi desc;";
            return comboYears;
        }
        public static string GetComboBoxCountries() {
            string comboCountries = "select nimi from maa order by nimi;";
            return comboCountries;
        }
        public static string GetComboBoxArtists() {
            string comboArtists = "select nimi from esittaja order by nimi;";
            return comboArtists;
        }
        public static string GetComboBoxAlbums() {
            string comboAlbums = "select nimi from cd order by nimi;";
            return comboAlbums;
        }
        public static string GetComboBoxCompanies() {
            string comboCompanies = "select nimi from yhtio order by nimi;";
            return comboCompanies;
        }
        public static string GetComboBoxGenres() {
            string comboGenres = "select nimi from genre order by nimi;";
            return comboGenres;
        }
        #endregion
    }
}
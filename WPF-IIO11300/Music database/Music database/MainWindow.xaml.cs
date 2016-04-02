﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;


namespace MusicDatabase {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        WindowHandler handler = new WindowHandler();
        private DataTable artists;
        private DataTable albums;
        private DataTable tracks;
        private DataTable genres;
        private DataTable companies;
        public MainWindow() {
            InitializeComponent();
            IniMytuff();
        }

        public void IniMytuff() {
            try {
                artists = Artist.GetArtists();
                dgTest.DataContext = artists;
                albums = Album.GetAlbums();
                dgTest1.DataContext = albums;
                tracks = Track.GetTracks();
                dgTest2.DataContext = tracks;
                genres = Genre.GetGenres();
                dgTest3.DataContext = genres;
                companies = Company.GetCompanies();
                dgTest4.DataContext = companies;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearchFromDatabase_Click(object sender, RoutedEventArgs e) {

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e) {
            handler.MoveToRegister();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            handler.MoveToLogin();
            this.Close();
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void btnContact_Click(object sender, RoutedEventArgs e) {

        }
    }
}
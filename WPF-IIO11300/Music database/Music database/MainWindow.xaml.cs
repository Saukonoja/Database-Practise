using System;
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

        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
        }

        public void IniMyStuff() {
            try {
                dgTest.DataContext = Artist.GetArtists();
                dgTest1.DataContext = Album.GetAlbums();
                dgTest2.DataContext = Track.GetTracks();
                dgTest3.DataContext = Genre.GetGenres();
                dgTest4.DataContext = Company.GetCompanies();
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

        private void btnAddArtist_Click(object sender, RoutedEventArgs e) {
            string name = txtName.Text;
            string country = txtCountry.Text;
            int year = int.Parse(txtYear.Text);
            try {
                Artist.AddNewArtist(name, country, year);
            }
            catch (Exception ex) {

               MessageBox.Show(ex.Message);
            }
        }

        private void dgTest_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            spArtist.DataContext = dgTest.SelectedItem;
        }
    }
}
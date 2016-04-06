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
        int selectedKey;
        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
        }

        public void IniMyStuff() {
            try {

                dgArtist.DataContext = Artist.GetArtists();
                dgArtistPage.DataContext = Artist.GetArtists();
                dgAlbums.DataContext = Album.GetAlbums();
                dgTracks.DataContext = Track.GetTracks();
                dgGenres.DataContext = Genre.GetGenres();
                dgCompanies.DataContext = Company.GetCompanies();

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        public int GetSelectedKey(string selectedName) {
            int selectedKey = Artist.GetSelectedArtistKey(selectedName);
            return selectedKey;
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
            try {
                string name = txtName.Text;
                int year = int.Parse(txtYear.Text);
                string country = txtCountry.Text;
                Artist.AddNewArtist(name, country, year);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteArtist_Click(object sender, RoutedEventArgs e) {
            try {
                DataRowView rowView = dgArtist.SelectedItem as DataRowView;
                string name = rowView.Row[0] as string;
                MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Artist.DeleteArtist(name);
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "No":
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnChangeArtist_Click(object sender, RoutedEventArgs e) {

            try {
                string name = txtName.Text;
                int year = int.Parse(txtYear.Text);
                string country = txtCountry.Text;
                MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Artist.UpdateArtist(selectedKey, name, country, year);
                        } catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "No":
                        break;
                    default:
                        break;
                }
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e) {
            IniMyStuff();
        }

        private void dgArtist_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                int index = dgArtist.SelectedCells[0].Column.DisplayIndex;
                DataGridRow row = (DataGridRow)dgArtist.ItemContainerGenerator.ContainerFromIndex(dgArtist.SelectedIndex);
                DataGridCell RowColumn = dgArtist.Columns[index].GetCellContent(row).Parent as DataGridCell;
                string CellValue = ((TextBlock)RowColumn.Content).Text;
                ChangeArtistPage(CellValue);
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
        private void ChangeArtistPage(string artist) {
            dgArtist.Visibility = Visibility.Collapsed;
            dgArtistPage.Visibility = Visibility.Visible;
            spBack.Visibility = Visibility.Visible;
        }


        private void btnBack_Click(object sender, RoutedEventArgs e) {
            dgArtist.Visibility = Visibility.Visible;
            dgArtistPage.Visibility = Visibility.Collapsed;
            spBack.Visibility = Visibility.Collapsed;
        }

        private void dgArtistPage_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            try {
                DataRowView rowView = dgArtistPage.SelectedItem as DataRowView;
                string s = rowView.Row[0] as string;
                if (s != null) {
                    string selectedName = rowView.Row[0] as string;
                    selectedKey = GetSelectedKey(selectedName);
                } else {
                    selectedKey = 1;
                }
                    
            } catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
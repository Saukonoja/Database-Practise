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
        private string userType = (Application.Current as App).Usertype;
        private string userName = (Application.Current as App).Username;
        private static string videoString = "http://student.labranet.jamk.fi/~H3298/iim50300/videoplayer.php?param=";
        WindowHandler handler = new WindowHandler();

        public MainWindow() {
            InitializeComponent();
            IniMyStuff();

        }

        public void IniMyStuff() {
            try {

                dgArtist.DataContext = Artist.GetArtists();
                dgArtistEdit.DataContext = Artist.GetArtists();
                dgAlbums.DataContext = Album.GetAlbums();
                dgAlbumEdit.DataContext = Album.GetAlbums();
                dgTracks.DataContext = Track.GetTracks();
                dgGenres.DataContext = Genre.GetGenres();
                dgCompanies.DataContext = Company.GetCompanies();
                dgUsersEdit.DataContext = Users.GetUsers();
                tbCurrentUser.Text = "Welcome, " + userName + "!";
                tbCurrentUserHeader.Text = userName;
                cbCountries.ItemsSource = DBMusicDatabase.GetCountries();
                if (userType == "admin" || userType == "user") {
                    btnLogin.Visibility = Visibility.Collapsed;
                    btnSignUp.Visibility = Visibility.Collapsed;
                    btnLogout.Visibility = Visibility.Visible;
                }

                tabUserSettings.Visibility = Visibility.Visible;

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSearchFromDatabase_Click(object sender, RoutedEventArgs e) {

        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e) {
            IniMyStuff();
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
            tabAbout.IsSelected = true;
        }



        //ARTIST



        private void btnAddArtist_Click(object sender, RoutedEventArgs e) {
            try {
                if (btnAddArtist.Content.ToString() == "Add artist") {
                    txtArtistName.Text = "";
                    txtArtistYear.Text = "";
                    txtArtistCountry.Text = "";
                    btnAddArtist.Content = "Save new artist";
                } else {
                    string name = txtArtistName.Text;
                    int year = int.Parse(txtArtistYear.Text);
                    string country = txtArtistCountry.Text;
                    Artist.AddNewArtist(name, country, year);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteArtist_Click(object sender, RoutedEventArgs e) {
            try {

                DataRowView rowView = dgArtist.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = rowView.Row[1] as string;

                MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {

                            Artist.DeleteArtist(key);
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

        private void btnUpdateArtist_Click(object sender, RoutedEventArgs e) {

            try {
                DataRowView rowView = dgArtist.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = txtArtistName.Text;
                int year = int.Parse(txtArtistYear.Text);
                string country = txtArtistCountry.Text;

                MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Artist.UpdateArtist(key, name, country, year);
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

        private void dgArtist_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                DataRowView dataRow = (DataRowView)dgArtist.SelectedItem;
                int index = dgArtist.CurrentCell.Column.DisplayIndex;
                string cellValue = dataRow.Row.ItemArray[index].ToString();
                int columnIndex = dgArtist.CurrentColumn.DisplayIndex;
                if (columnIndex == 1) {
                    ChangeArtistPage(cellValue);
                    tabAlbums.IsSelected = true;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgArtistPage_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                DataRowView dataRow = (DataRowView)dgArtistPage.SelectedItem;
                int index = dgArtistPage.CurrentCell.Column.DisplayIndex;
                string cellValue = dataRow.Row.ItemArray[index].ToString();
                int columnIndex = dgArtistPage.CurrentColumn.DisplayIndex;
                if (columnIndex == 0) {
                    ChangeAlbumPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        private void ChangeArtistPage(string artist) {
            spArtists.Visibility = Visibility.Collapsed;
            spArtistPage.Visibility = Visibility.Visible;
            spEditArtistButton.Visibility = Visibility.Collapsed;
            dgArtistPage.DataContext = Artist.GetArtistAlbums(artist);
            tbArtistPage.Text = artist;
        }

        private void btnBackToArtists_Click(object sender, RoutedEventArgs e) {
            spArtists.Visibility = Visibility.Visible;
            spArtistPage.Visibility = Visibility.Collapsed;
            spEditArtistButton.Visibility = Visibility.Visible;
        }

        private void btnEditArtist_Click(object sender, RoutedEventArgs e) {
            spArtists.Visibility = Visibility.Collapsed;
            spArtistEdit.Visibility = Visibility.Visible;
            spEditArtistButton.Visibility = Visibility.Collapsed;
        }

        private void btnBackFromArtistEdit_Click(object sender, RoutedEventArgs e) {
            spArtists.Visibility = Visibility.Visible;
            spArtistEdit.Visibility = Visibility.Collapsed;
            spEditArtistButton.Visibility = Visibility.Visible;
        }




        //ALBUM





        private void btnAddAlbum_Click(object sender, RoutedEventArgs e) {

        }

        private void btnDeleteAlbum_Click(object sender, RoutedEventArgs e) {

        }

        private void btnUpdateAlbum_Click(object sender, RoutedEventArgs e) {

        }

        private void dgAlbums_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                DataRowView dataRow = (DataRowView)dgAlbums.SelectedItem;
                int index = dgAlbums.CurrentCell.Column.DisplayIndex;
                string cellValue = dataRow.Row.ItemArray[index].ToString();
                int columnIndex = dgAlbums.CurrentColumn.DisplayIndex;
                if (columnIndex == 0) {
                    ChangeAlbumPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgAlbumPage_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                DataRowView dataRow = (DataRowView)dgAlbumPage.SelectedItem;
                int index = dgAlbumPage.CurrentCell.Column.DisplayIndex;
                string cellValue = dataRow.Row.ItemArray[index].ToString();
                int columnIndex = dgAlbumPage.CurrentColumn.DisplayIndex;
                if (columnIndex == 1) {
                    PlayTrack(cellValue);
                    tbTrackName.Text = cellValue;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgAlbumEdit_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void PlayTrack(string track) {
            spYoutubePlayer.Visibility = Visibility.Visible;
            youtubeVideo.Navigate(new Uri(videoString + Track.GetTrackTubepath(track), UriKind.RelativeOrAbsolute));
        }

        private void ChangeAlbumPage(string album) {
            spAlbums.Visibility = Visibility.Collapsed;
            spAlbumPage.Visibility = Visibility.Visible;
            spEditAlbumButton.Visibility = Visibility.Collapsed;
            dgAlbumPage.DataContext = Album.GetAlbumTracks(album);
            tbAlbumPage.Text = album;
        }

        private void btnBackToAlbums_Click(object sender, RoutedEventArgs e) {
            spAlbums.Visibility = Visibility.Visible;
            spAlbumPage.Visibility = Visibility.Collapsed;
            spEditAlbumButton.Visibility = Visibility.Visible;
        }

        private void btnEditAlbum_Click(object sender, RoutedEventArgs e) {
            spAlbums.Visibility = Visibility.Collapsed;
            spAlbumEdit.Visibility = Visibility.Visible;
            spEditAlbumButton.Visibility = Visibility.Collapsed;
        }

        private void btnBackFromAlbumEdit_Click(object sender, RoutedEventArgs e) {
            spAlbums.Visibility = Visibility.Visible;
            spAlbumEdit.Visibility = Visibility.Collapsed;
            spEditAlbumButton.Visibility = Visibility.Visible;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e) {
            (Application.Current as App).Usertype = "guest";
            (Application.Current as App).Username = "guest";
            this.handler.MoveToLogin();
            this.Close();
        }

        private void dgArtistEdit_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e) {
            tabHome.IsSelected = true;
        }

        private void dgUserEdit_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e) {
            try {

                DataRowView rowView = dgUsersEdit.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = rowView.Row[1] as string;

                MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {

                            Users.DeleteUser(key);
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

        private void btnUpdateUser_Click(object sender, RoutedEventArgs e) {
            try {
                DataRowView rowView = dgUsersEdit.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = txtUsername.Text;
                bool admin = chkAdmin.IsChecked.Value;

                MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Users.UpdateUser(key, name, admin);
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

        private void Hyperlink_Click_1(object sender, RoutedEventArgs e) {
            tabUserSettings.IsSelected = true;

        }

        private void btnUpdatePassword_Click(object sender, RoutedEventArgs e) {
            try {
                string newPassword = txtPassword.Text;
                string user = (Application.Current as App).Username;
                MessageBoxResult result = MessageBox.Show("Save changes to " + user, "Save changes", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Users.UpdatePassword(user, newPassword);
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
    }
}
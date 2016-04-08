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
using System.ComponentModel;

namespace MusicDatabase {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private string userType = (Application.Current as App).Usertype;
        private string userName = (Application.Current as App).Username;
        private static string videoString = "http://student.labranet.jamk.fi/~H3298/iim50300/videoplayer.php?param=";
        private static string imageFolderUri = "http://student.labranet.jamk.fi/~H3298/iim50300/images/";
        private int columnIndex;
        private string cellValue;
        private string linkValue;
        WindowHandler handler = new WindowHandler();
        bool shutdown = true;

        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
        }

        #region INIT

        public void IniMyStuff() {
            try {
                dgArtist.DataContext = Artist.GetArtists().DefaultView;
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
                if (userType != "guest") {
                    tabUserSettings.Visibility = Visibility.Visible;
                    usernameLink.IsEnabled = true;
                }
                if (userType == "admin") {
                    spUsersEdit.Visibility = Visibility.Visible;
                }
                var mainImageUri = new Uri(imageFolderUri + "emptycd.png");
                var bitmap = new BitmapImage(mainImageUri);
                mainImage.Source = bitmap;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion
        #region MAIN BUTTONS AND METHODS
        private void btnSearchFromDatabase_Click(object sender, RoutedEventArgs e) {

        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e) {
            IniMyStuff();
        }

        private void homeLink_Click(object sender, RoutedEventArgs e) {
            tabHome.IsSelected = true;
        }

        private void usernameLink_Click(object sender, RoutedEventArgs e) {
            if (userType != "guest") {
                tabUserSettings.IsSelected = true;
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e) {
            shutdown = false;
            youtubeVideo.Navigate(new Uri("http://google.fi", UriKind.RelativeOrAbsolute));
            handler.MoveToRegister();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            shutdown = false;
            youtubeVideo.Navigate(new Uri("http://google.fi", UriKind.RelativeOrAbsolute));
            handler.MoveToLogin();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e) {
            shutdown = false;
            youtubeVideo.Navigate(new Uri("http://google.fi", UriKind.RelativeOrAbsolute));
            (Application.Current as App).Usertype = "guest";
            (Application.Current as App).Username = "guest";
            this.handler.MoveToLogin();
            this.Close();
        }

        private void btnContact_Click(object sender, RoutedEventArgs e) {
            tabAbout.IsSelected = true;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            if (shutdown == true) {
                Application.Current.Shutdown();
            }
        }

        private void MouseDoubleClicked(DataGrid dg, out string cellValue, out int columnIndex) {
            DataRowView dataRow = (DataRowView)dg.SelectedItem;
            int index = dg.CurrentCell.Column.DisplayIndex;
            cellValue = dataRow.Row.ItemArray[index].ToString();
            columnIndex = dg.CurrentColumn.DisplayIndex;
        }

        private void ChangePage(StackPanel sp1, StackPanel sp2, StackPanel sp3) {
            sp1.Visibility = Visibility.Collapsed;
            sp2.Visibility = Visibility.Visible;
            sp3.Visibility = Visibility.Collapsed;
        }

        private void ChangeArtistPage(string current) {
            ChangePage(spArtists, spArtistPage, spEditArtistButton);
            dgArtistPage.DataContext = Artist.GetArtistAlbums(current);
            tbArtistPage.Text = current;
        }

        private void ChangeAlbumPage(string current) {
            ChangePage(spAlbums, spAlbumPage, spEditAlbumButton);
            dgAlbumPage.DataContext = Album.GetAlbumTracks(current);
            tbAlbumPage.Text = current;
            tabAlbums.IsSelected = true;
            var albumImageUri = new Uri(Album.GetImageUrl(current));
            var bitmap = new BitmapImage(albumImageUri);
            albumImage.Source = bitmap;
            List<string> array = Album.GetAlbumInfo(current);
            int totalSeconds = int.Parse(array[3]);
            int seconds = totalSeconds % 60;
            int minutes = totalSeconds / 60;
            string length = minutes + ":" + seconds;
            Hyperlink link = new Hyperlink();
            link.Inlines.Add(array[0]);
            SolidColorBrush color = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            link.Foreground = color;
            var run = link.Inlines.FirstOrDefault() as Run;
            linkValue = run == null ? string.Empty : run.Text;
            tbAlbumInfo.Inlines.Clear();
            tbAlbumInfo.Inlines.Add("from artist ");
            tbAlbumInfo.Inlines.Add(link);
            tbAlbumInfo.Inlines.Add(" \u2022 " + array[1] + " \u2022 \n" + array[2] + " tracks, " + length);
            link.Click += artistName_Click;    
        }

        private void artistName_Click(object sender, RoutedEventArgs e) {
            tabArtists.IsSelected = true;     
            ChangeArtistPage(linkValue);
        }

        private void BackTo(StackPanel sp1, StackPanel sp2, StackPanel sp3) {
            sp1.Visibility = Visibility.Visible;
            sp2.Visibility = Visibility.Collapsed;
            sp3.Visibility = Visibility.Visible;
        }

        private void Edit(StackPanel sp1, StackPanel sp2, StackPanel sp3) {
            sp1.Visibility = Visibility.Collapsed;
            sp2.Visibility = Visibility.Visible;
            sp3.Visibility = Visibility.Collapsed;
        }

        private void BackFromEdit(StackPanel sp1, StackPanel sp2, StackPanel sp3) {
            sp1.Visibility = Visibility.Visible;
            sp2.Visibility = Visibility.Collapsed;
            sp3.Visibility = Visibility.Visible;
        }

        private void PlayTrack(string track) {
            spYoutubePlayer.Visibility = Visibility.Visible;
            youtubeVideo.Navigate(new Uri(videoString + Track.GetTrackTubepath(track), UriKind.RelativeOrAbsolute));
            tbTrackName.Text = track;
            var mainImageUri = new Uri(Album.GetImageUrl(tbAlbumPage.Text));
            var bitmap = new BitmapImage(mainImageUri);
            mainImage.Source = bitmap;
        }
        #endregion
        #region ARTIST

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
                MouseDoubleClicked(dgArtist, out cellValue, out columnIndex);
                if (columnIndex == 1) {
                    ChangeArtistPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgArtistPage_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                e.Handled = true;
                MouseDoubleClicked(dgArtistPage, out cellValue, out columnIndex);
                if (columnIndex == 0) {
                    ChangeAlbumPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackToArtists_Click(object sender, RoutedEventArgs e) {
            BackTo(spArtists, spArtistPage, spEditArtistButton);
        }

        private void btnEditArtist_Click(object sender, RoutedEventArgs e) {
            Edit(spArtists, spArtistEdit, spEditArtistButton);
        }

        private void btnBackFromArtistEdit_Click(object sender, RoutedEventArgs e) {
            BackFromEdit(spArtists, spArtistEdit, spEditArtistButton);
        }
        #endregion
        #region ALBUM

        private void btnAddAlbum_Click(object sender, RoutedEventArgs e) {

        }

        private void btnDeleteAlbum_Click(object sender, RoutedEventArgs e) {

        }

        private void btnUpdateAlbum_Click(object sender, RoutedEventArgs e) {

        }

        private void dgAlbums_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                MouseDoubleClicked(dgAlbums, out cellValue, out columnIndex);
                if (columnIndex == 0) {
                    ChangeAlbumPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgAlbumPage_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                MouseDoubleClicked(dgAlbumPage, out cellValue, out columnIndex);
                if (columnIndex == 1) {
                    PlayTrack(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackToAlbums_Click(object sender, RoutedEventArgs e) {
            BackTo(spAlbums, spAlbumPage, spEditAlbumButton);
        }

        private void btnEditAlbum_Click(object sender, RoutedEventArgs e) {
            Edit(spAlbums, spAlbumEdit, spEditAlbumButton);
        }

        private void btnBackFromAlbumEdit_Click(object sender, RoutedEventArgs e) {
            BackFromEdit(spAlbums, spAlbumEdit, spEditAlbumButton);
        }
        #endregion
        #region USER

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
        #endregion

        private void mainImage_MouseDown(object sender, MouseButtonEventArgs e) {
            tabAlbums.IsSelected = true;
        }
    }
}
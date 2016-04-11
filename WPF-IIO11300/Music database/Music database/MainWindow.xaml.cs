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
        Uri mainImageUri = new Uri(imageFolderUri + "emptycd.png");
        WindowHandler handler = new WindowHandler();
        bool shutdown = true;

        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
            IniDatagrids();
        }

        #region INIT

        public void IniMyStuff() {
            tbCurrentUser.Text = "Welcome, " + userName + "!";
            tbCurrentUserHeader.Text = userName;
            try {
                cbArtistYear.ItemsSource = DBMusicDatabase.GetYears();
                cbArtistCountry.ItemsSource = DBMusicDatabase.GetCountries();
                cbAlbumYear.ItemsSource = DBMusicDatabase.GetYears();
                cbTrackYear.ItemsSource = DBMusicDatabase.GetYears();
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

                var bitmap = new BitmapImage(mainImageUri);
                mainImage.Source = bitmap;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void IniDatagrids() {
            IniArtists();
            IniAlbums();
            IniTracks();
            IniGenres();
            IniCompanies();
        }

        public void IniArtists() {
            dgArtist.DataContext = Artist.GetArtists().DefaultView;
            dgArtistEdit.DataContext = Artist.GetArtists();
            cbAlbumArtist.ItemsSource = DBMusicDatabase.GetArtists();
            cbTrackArtist.ItemsSource = DBMusicDatabase.GetArtists();
        }

        public void IniAlbums() {
            dgAlbums.DataContext = Album.GetAlbums();
            dgAlbumEdit.DataContext = Album.GetAlbums();
            cbTrackAlbum.ItemsSource = DBMusicDatabase.GetAlbums();
        }

        public void IniTracks() {
            dgTracks.DataContext = Track.GetTracks();
            dgTrackEdit.DataContext = Track.GetTracks();
        }

        public void IniGenres() {
            dgGenres.DataContext = Genre.GetGenres();
            dgGenreEdit.DataContext = Genre.GetGenres();
        }

        public void IniCompanies() {
            dgCompanies.DataContext = Company.GetCompanies();
            dgCompanyEdit.DataContext = Company.GetCompanies();
            cbAlbumCompany.ItemsSource = DBMusicDatabase.GetCompanies();
        }

        public void IniUsers() {
            dgUsersEdit.DataContext = Users.GetUsers();
        }
        #endregion
        #region MAIN BUTTONS AND METHODS
        private void btnSearchFromDatabase_Click(object sender, RoutedEventArgs e) {

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

        private void artistName_Click(object sender, RoutedEventArgs e) {
            tabArtists.IsSelected = true;
            ChangeArtistPage(linkValue);
        }

        private void ChangePage(StackPanel sp1, StackPanel sp2, StackPanel sp3) {
            sp1.Visibility = Visibility.Collapsed;
            sp2.Visibility = Visibility.Visible;
            sp3.Visibility = Visibility.Visible;
        }

        private void ChangeArtistPage(string current) {
            ChangePage(spArtists, spArtistPage, spBackToArtists);
            spArtistEdit.Visibility = Visibility.Collapsed;
            spBackFromArtistEdit.Visibility = Visibility.Collapsed;
            dgArtistPage.DataContext = Artist.GetArtistAlbums(current);
            tbArtistPage.Text = current;
            tabArtists.IsSelected = true;
        }

        private void ChangeAlbumPage(string current) {
            try {
                ChangePage(spAlbums, spAlbumPage, spBackToAlbums);
                dgAlbumPage.DataContext = Album.GetAlbumTracks(current);
                tbAlbumPage.Text = current;
                tabAlbums.IsSelected = true;
                spAlbumEdit.Visibility = Visibility.Collapsed;
                var albumImageUri = new Uri(imageFolderUri + "emptycd.png");
                if (Album.GetImageUrl(current) != "") {
                    albumImageUri = new Uri(Album.GetImageUrl(current));
                }
                var bitmap = new BitmapImage(albumImageUri);
                albumImage.Source = bitmap;
                List<string> array = Album.GetAlbumInfo(current);
                int totalSeconds = int.Parse(array[3]);
                int seconds = totalSeconds % 60;
                int minutes = totalSeconds / 60;
                string length = minutes + ":" + seconds;
                if (seconds < 10) {
                    length = minutes + ":0" + seconds;
                }
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
            } catch (Exception) {
                MessageBox.Show("Some details are empty.");
            }
        }

        private void ChangeGenrePage(string current) {
            ChangePage(spGenres, spGenrePage, spBackToGenres);
            dgGenrePage.DataContext = Genre.GetGenreTracks(current);
            tbGenrePage.Text = current;
        }
        private void ChangeCompanyPage(string current) {
            ChangePage(spCompanies, spCompanyPage, spBackToCompanies);
            dgCompanyPage.DataContext = Company.GetCompanyAlbums(current);
            tbCompanyPage.Text = current;
        }

        private void mainImage_MouseDown(object sender, MouseButtonEventArgs e) {
            string uri = imageFolderUri + "emptycd.png";
            if (mainImageUri.ToString() != uri) {
                tabAlbums.IsSelected = true;
                spBackFromAlbumEdit.Visibility = Visibility.Collapsed;
                spYoutubePlayer.Visibility = Visibility.Visible;
                try {
                    ChangeAlbumPage(Album.GetAlbumName(tbTrackName.Text));
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BackTo(StackPanel sp1, StackPanel sp2, StackPanel sp3) {
            sp1.Visibility = Visibility.Visible;
            sp2.Visibility = Visibility.Collapsed;
            sp3.Visibility = Visibility.Collapsed;
        }

        private void Edit(StackPanel sp1, StackPanel sp2, StackPanel sp3) {
            sp1.Visibility = Visibility.Collapsed;
            sp2.Visibility = Visibility.Visible;
            sp3.Visibility = Visibility.Visible;
        }

        private void BackFromEdit(StackPanel sp1, StackPanel sp2, StackPanel sp3, DataGrid dg) {
            sp1.Visibility = Visibility.Visible;
            sp2.Visibility = Visibility.Collapsed;
            sp3.Visibility = Visibility.Collapsed;
            dg.SelectedIndex = -1;
        }

        private void PlayTrack(string track) {
            spYoutubePlayer.Visibility = Visibility.Visible;
            youtubeVideo.Navigate(new Uri(videoString + Track.GetTrackTubepath(track), UriKind.RelativeOrAbsolute));
            tbTrackName.Text = track;
            mainImageUri = new Uri(Album.GetImageUrl(tbAlbumPage.Text));
            var bitmap = new BitmapImage(mainImageUri);
            mainImage.Source = bitmap;
            tabAlbums.IsSelected = true;
        }

        private void dg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e) {
            if ((string)e.Column.Header == "ID") {
                e.Cancel = true;
            }
        }
        private void dgEdit_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            btnAddArtist.Content = "Add artist"; btnAddAlbum.Content = "Add album";
            btnAddTrack.Content = "Add track"; btnAddArtist.Content = "Add artist";
            btnAddArtist.Content = "Add artist";
        }

        #endregion
        #region ARTIST

        private void btnAddArtist_Click(object sender, RoutedEventArgs e) {
            if (txtArtistName.Text != "" && txtArtistName.Text != "" &&
                cbArtistCountry.Text != "") {
                try {
                    if (dgArtistEdit.SelectedIndex > -1) {
                        if (btnAddArtist.Content.ToString() == "Add artist") {
                            dgArtistEdit.SelectedIndex = -1;
                            txtArtistName.Text = "";
                            cbArtistYear.Text = "";
                            cbArtistCountry.Text = "";
                            btnAddArtist.Content = "Save new artist";
                        }
                    } else if (dgArtistEdit.SelectedIndex == -1) {
                        string name = txtArtistName.Text;
                        int year = int.Parse(cbArtistYear.Text);
                        string country = cbArtistCountry.Text;
                        Artist.AddNewArtist(name, country, year);
                        btnAddArtist.Content = "Add artist";
                        IniArtists();
                        MessageBox.Show("New artist added to database.");
                        dgArtistEdit.SelectedIndex = 0;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else {
                MessageBox.Show("Fill fields first.");
            }
        }

        private void btnDeleteArtist_Click(object sender, RoutedEventArgs e) {
            if (dgArtistEdit.SelectedIndex > -1) {
                try {
                    DataRowView rowView = dgArtistEdit.SelectedItem as DataRowView;
                    int key = (int)rowView[3];
                    string name = rowView.Row[0] as string;

                    MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                    switch (result.ToString()) {
                        case "Yes":
                            try {
                                Artist.DeleteArtist(key);
                                IniArtists();
                                MessageBox.Show("Artist deleted from the database.");
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
            } else {
                MessageBox.Show("Select artist first.");
            }
        }

        private void btnUpdateArtist_Click(object sender, RoutedEventArgs e) {
            if (dgArtistEdit.SelectedIndex > -1) {
                try {
                    DataRowView rowView = dgArtistEdit.SelectedItem as DataRowView;
                    int key = (int)rowView[3];
                    string name = txtArtistName.Text;
                    int year = int.Parse(cbArtistYear.Text);
                    string country = cbArtistCountry.Text;

                    MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                    switch (result.ToString()) {
                        case "Yes":
                            try {
                                Artist.UpdateArtist(key, name, country, year);
                                IniArtists();
                                MessageBox.Show("Artist updated to database.");
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
            } else {
                MessageBox.Show("Select artist first.");
            }
        }

        private void dgArtist_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                MouseDoubleClicked(dgArtist, out cellValue, out columnIndex);
                if (columnIndex == 0) {
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
            BackTo(spArtists, spArtistPage, spBackToArtists);
        }

        private void btnEditArtist_Click(object sender, RoutedEventArgs e) {
            Edit(spArtists, spArtistEdit, spBackFromArtistEdit);
        }

        private void btnBackFromArtistEdit_Click(object sender, RoutedEventArgs e) {
            BackFromEdit(spArtists, spArtistEdit, spBackFromArtistEdit, dgArtistEdit);
        }
        #endregion
        #region ALBUM

        private void btnAddAlbum_Click(object sender, RoutedEventArgs e) {
            if (txtAlbumName.Text != "" && cbAlbumArtist.Text != "" &&
                cbAlbumYear.Text != "") {
                try {
                    if (dgAlbumEdit.SelectedIndex > -1) {
                        if (btnAddAlbum.Content.ToString() == "Add album") {
                            dgAlbumEdit.SelectedIndex = -1;
                            txtAlbumName.Text = "";
                            cbAlbumArtist.Text = "";
                            cbAlbumYear.Text = "";
                            cbAlbumCompany.Text = "";
                            txtAlbumCover.Text = "";
                            btnAddAlbum.Content = "Save new album";
                        }
                    } else if (dgAlbumEdit.SelectedIndex == -1) {
                        string name = txtAlbumName.Text;
                        string artist = cbAlbumArtist.Text;
                        int year = int.Parse(cbAlbumYear.Text);
                        string company = cbAlbumCompany.Text;
                        string imageLink = txtAlbumCover.Text;
                        Album.AddAlbum(name, artist, company, year, imageLink);
                        IniAlbums();
                        MessageBox.Show("New album added to database.");
                        btnAddAlbum.Content = "Add album";
                        dgAlbumEdit.SelectedIndex = 0;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else {
                MessageBox.Show("Fill fields first.");
            }
        }

        private void btnDeleteAlbum_Click(object sender, RoutedEventArgs e) {
            if (dgAlbumEdit.SelectedIndex > 1) {
                try {
                    DataRowView rowView = dgAlbumEdit.SelectedItem as DataRowView;
                    int key = (int)rowView[5];
                    string name = rowView.Row[0] as string;
                    MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                    switch (result.ToString()) {
                        case "Yes":
                            try {
                                Album.DeleteAlbum(key);
                                IniAlbums();
                                MessageBox.Show("Album deleted from the database.");
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
            } else {
                MessageBox.Show("Select album first.");
            }
        }

        private void btnUpdateAlbum_Click(object sender, RoutedEventArgs e) {
            if (dgAlbumEdit.SelectedIndex > 1) {
                try {
                    DataRowView rowView = dgAlbumEdit.SelectedItem as DataRowView;
                    int key = (int)rowView[5];
                    string name = txtAlbumName.Text;
                    string artist = cbAlbumArtist.Text;
                    int year = int.Parse(cbAlbumYear.Text);
                    string company = cbAlbumCompany.Text;
                    string imageLink = txtAlbumCover.Text;
                    MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                    switch (result.ToString()) {
                        case "Yes":
                            try {
                                Album.UpdateAlbum(key, name, artist, company, year, imageLink);
                                IniAlbums();
                                MessageBox.Show("Album updated to database.");
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
            } else {
                MessageBox.Show("Select album first.");
            }
        }

        private void dgAlbums_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                e.Handled = true;
                MouseDoubleClicked(dgAlbums, out cellValue, out columnIndex);
                if (columnIndex == 0) {
                    ChangeAlbumPage(cellValue);
                }
                if (columnIndex == 1) {
                    ChangeArtistPage(cellValue);
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
            BackTo(spAlbums, spAlbumPage, spBackToAlbums);
        }

        private void btnEditAlbum_Click(object sender, RoutedEventArgs e) {
            Edit(spAlbums, spAlbumEdit, spBackFromAlbumEdit);
            spYoutubePlayer.Visibility = Visibility.Collapsed;
        }

        private void btnBackFromAlbumEdit_Click(object sender, RoutedEventArgs e) {
            BackFromEdit(spAlbums, spAlbumEdit, spBackFromAlbumEdit, dgAlbumEdit);
            spYoutubePlayer.Visibility = Visibility.Visible;
        }
        #endregion
        #region TRACK
        private void btnAddTrack_Click(object sender, RoutedEventArgs e) {
            if (txtTrackName.Text != "" && cbTrackArtist.Text != "" &&
                cbTrackYear.Text != "" && cbTrackAlbum.Text != "" &&
                txtTrackNumber.Text != "" && txtTrackLength.Text != "") {
                try {
                    if (dgTrackEdit.SelectedIndex > -1) {
                        if (btnAddTrack.Content.ToString() == "Add track") {
                            dgTrackEdit.SelectedIndex = -1;
                            txtTrackName.Text = "";
                            cbTrackArtist.Text = "";
                            cbTrackYear.Text = "";
                            cbTrackAlbum.Text = "";
                            txtTubeLink.Text = "";
                            txtTrackNumber.Text = "";
                            txtTrackLength.Text = "4:30";
                            btnAddTrack.Content = "Save new track";
                        }
                    } else if (dgTrackEdit.SelectedIndex == -1) {
                        string name = txtTrackName.Text;
                        string artist = cbTrackArtist.Text;
                        int year = int.Parse(cbTrackYear.Text);
                        string album = cbTrackAlbum.Text;
                        string link = txtTubeLink.Text;
                        string linkParsed = link.Substring(link.LastIndexOf('=') + 1);
                        int number = int.Parse(txtTrackNumber.Text);
                        string length = "00:" + txtTrackLength.Text;
                        int lengthSeconds = (int)TimeSpan.Parse(length).TotalSeconds;
                        Track.AddTrack(name, artist, year, album, linkParsed, number, lengthSeconds);
                        IniTracks();
                        MessageBox.Show("New track added to database.");
                        btnAddTrack.Content = "Add track";
                        dgTrackEdit.SelectedIndex = 0;
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else {
                MessageBox.Show("Fill fields first.");
            }
        }

        private void btnDeleteTrack_Click(object sender, RoutedEventArgs e) {
            if (dgTrackEdit.SelectedIndex > -1) {
                try {
                    DataRowView rowView = dgTrackEdit.SelectedItem as DataRowView;
                    int key = (int)rowView[7];
                    string name = rowView.Row[0] as string;
                    MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                    switch (result.ToString()) {
                        case "Yes":
                            try {
                                Track.DeleteTrack(key);
                                IniTracks();
                                MessageBox.Show("Track deleted from the database.");
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
            } else {
                MessageBox.Show("Select track first.");
            }
        }

        private void btnUpdateTrack_Click(object sender, RoutedEventArgs e) {
            if (dgTrackEdit.SelectedIndex > -1) {
                try {
                    DataRowView rowView = dgTrackEdit.SelectedItem as DataRowView;
                    int key = (int)rowView[7];
                    string name = txtTrackName.Text;
                    string artist = cbTrackArtist.Text;
                    int year = int.Parse(cbTrackYear.Text);
                    string album = cbTrackAlbum.Text;
                    string link = txtTubeLink.Text;
                    string linkParsed = link.Substring(link.LastIndexOf('=') + 1);
                    int number = int.Parse(txtTrackNumber.Text);
                    int length = int.Parse(txtTrackLength.Text);
                    MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                    switch (result.ToString()) {
                        case "Yes":
                            try {
                                Track.UpdateTrack(key, name, artist, year, album, linkParsed, number, length);
                                IniTracks();
                                MessageBox.Show("Track updated to database.");
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
            } else {
                MessageBox.Show("Select track first.");
            }
        }

        private void dgTracks_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                e.Handled = true;
                MouseDoubleClicked(dgTracks, out cellValue, out columnIndex);
                if (columnIndex == 0) {
                    ChangeAlbumPage(Album.GetAlbumName(cellValue));
                    PlayTrack(cellValue);
                }
                if (columnIndex == 1) {
                    ChangeArtistPage(cellValue);
                }
                if (columnIndex == 2) {
                    ChangeAlbumPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditTrack_Click(object sender, RoutedEventArgs e) {
            Edit(spTracks, spTrackEdit, spBackFromTrackEdit);
        }

        private void btnBackFromTrackEdit_Click(object sender, RoutedEventArgs e) {
            BackFromEdit(spTracks, spTrackEdit, spBackFromTrackEdit, dgTrackEdit);
        }
        #endregion
        #region GENRE

        private void btnAddGenre_Click(object sender, RoutedEventArgs e) {
            if (txtGenreName.Text != "") {
                try {
                    dgTrackEdit.SelectedIndex = -1;
                    if (btnAddTrack.Content.ToString() == "Add genre") {
                        txtGenreName.Text = "";
                        btnAddTrack.Content = "Save new genre";
                    } else {
                        string name = txtGenreName.Text;
                        //Genre.AddGenre(name);
                        IniGenres();
                        MessageBox.Show("New genre added to database.");
                        btnAddTrack.Content = "Add genre";
                    }
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
            } else {
                MessageBox.Show("Fill fields first.");
            }
        }

        private void btnDeleteGenre_Click(object sender, RoutedEventArgs e) {
            if (dgTrackEdit.SelectedIndex > -1) {
                //try {
                //DataRowView rowView = dgTrackEdit.SelectedItem as DataRowView;
                //int key = (int)rowView[7];
                //string name = rowView.Row[0] as string;
                //MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                //switch (result.ToString()) {
                //    case "Yes":
                //        try {
                //Track.DeleteTrack(key);
                //IniGenres();
                //MessageBox.Show("Track deleted from the database.");
                //            } catch (Exception ex) {
                //                MessageBox.Show(ex.Message);
                //            }
                //            break;
                //        case "No":
                //            break;
                //        default:
                //            break;
                //    }
                //} catch (Exception ex) {
                //    MessageBox.Show(ex.Message);
                //}
            } else {
                MessageBox.Show("Select track first.");
            }
        }

        private void btnUpdateGenre_Click(object sender, RoutedEventArgs e) {
            if (dgTrackEdit.SelectedIndex > -1) {
                //try {
                //    DataRowView rowView = dgTrackEdit.SelectedItem as DataRowView;
                //    int key = (int)rowView[7];
                //    string name = txtTrackName.Text;
                //    string artist = txtTrackArtist.Text;
                //    int year = int.Parse(txtTrackYear.Text);
                //    string album = txtTrackAlbum.Text;
                //    string link = txtTubeLink.Text;
                //    int number = int.Parse(txtTrackNumber.Text);
                //    int length = int.Parse(txtTrackLength.Text);
                //    MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                //    switch (result.ToString()) {
                //        case "Yes":
                //            try {
                //                Track.UpdateTrack(key, name, artist, year, album, link, number, length);
                //                IniGenres();
                //                MessageBox.Show("Track updated to database.");
                //            } catch (Exception ex) {
                //                MessageBox.Show(ex.Message);
                //            }
                //            break;
                //        case "No":
                //            break;
                //        default:
                //            break;
                //    }
                //} catch (Exception ex) {
                //    MessageBox.Show(ex.Message);
                //}
            } else {
                MessageBox.Show("Select track first.");
            }
        }

        private void dgGenres_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                e.Handled = true;
                MouseDoubleClicked(dgGenres, out cellValue, out columnIndex);
                if (columnIndex == 0) {
                    ChangeGenrePage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgGenrePage_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                e.Handled = true;
                MouseDoubleClicked(dgGenrePage, out cellValue, out columnIndex);
                if (columnIndex == 0) {
                    ChangeAlbumPage(Album.GetAlbumName(cellValue));
                    PlayTrack(cellValue);
                }
                if (columnIndex == 1) {
                    ChangeArtistPage(cellValue);
                }
                if (columnIndex == 2) {
                    ChangeAlbumPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackToGenres_Click(object sender, RoutedEventArgs e) {
            BackTo(spGenres, spGenrePage, spBackToGenres);
        }

        private void btnEditGenre_Click(object sender, RoutedEventArgs e) {
            Edit(spGenres, spGenreEdit, spBackFromGenreEdit);
        }

        private void btnBackFromGenreEdit_Click(object sender, RoutedEventArgs e) {
            BackFromEdit(spGenres, spGenreEdit, spBackFromGenreEdit, dgGenreEdit);
        }
        #endregion

        #region COMPANIES

        private void btnAddCompany_Click(object sender, RoutedEventArgs e) {

        }

        private void btnDeleteCompany_Click(object sender, RoutedEventArgs e) {

        }

        private void btnUpdateCompany_Click(object sender, RoutedEventArgs e) {

        }

        private void dgCompanies_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                e.Handled = true;
                MouseDoubleClicked(dgCompanies, out cellValue, out columnIndex);
                if (columnIndex == 0) {
                    ChangeCompanyPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgCompanyPage_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            try {
                e.Handled = true;
                MouseDoubleClicked(dgCompanyPage, out cellValue, out columnIndex);
                if (columnIndex == 0) {
                    ChangeAlbumPage(cellValue);
                }
                if (columnIndex == 1) {
                    ChangeArtistPage(cellValue);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackToCompanies_Click(object sender, RoutedEventArgs e) {
            BackTo(spCompanies, spCompanyPage, spBackToCompanies);
        }

        private void btnEditCompany_Click(object sender, RoutedEventArgs e) {
            Edit(spCompanies, spCompanyEdit, spBackFromCompanyEdit);
        }

        private void btnBackFromCompanyEdit_Click(object sender, RoutedEventArgs e) {
            BackFromEdit(spCompanies, spCompanyEdit, spBackFromCompanyEdit, dgCompanyEdit);
        }
        #endregion
        #region USER

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e) {
            try {
                DataRowView rowView = dgUsersEdit.SelectedItem as DataRowView;
                int key = (int)rowView[2];
                string name = rowView.Row[0] as string;

                MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {

                            Users.DeleteUser(key);
                            IniUsers();
                            MessageBox.Show("User deleted from the database.");
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
                int key = (int)rowView[2];
                string name = txtUsername.Text;
                bool admin = chkAdmin.IsChecked.Value;

                MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Users.UpdateUser(key, name, admin);
                            IniUsers();
                            MessageBox.Show("User updated to database.");
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
                            IniUsers();
                            MessageBox.Show("Password updated to database.");
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

        private void btnEmptyBoxes_Click(object sender, RoutedEventArgs e) {

        }
    }
}
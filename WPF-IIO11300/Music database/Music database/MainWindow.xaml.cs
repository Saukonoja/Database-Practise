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
        private string user = (Application.Current as App).User;
        WindowHandler handler = new WindowHandler();

        public MainWindow() {
            InitializeComponent();
            IniMyStuff();
            wbMain.Navigate(new Uri("http://student.labranet.jamk.fi/~H3298/iim50300/videoplayer.php?param=DWRXTw9AAA", UriKind.RelativeOrAbsolute));
        }

        public void IniMyStuff() {
            try {
                
                dgArtist.DataContext = Artist.GetArtists();
                dgArtistEdit.DataContext = Artist.GetArtists();
                dgAlbums.DataContext = Album.GetAlbums();
                dgAlbumEdit.DataContext = Album.GetAlbums();
                dgTracksEdit.DataContext = Track.GetTracks();
                dgGenres.DataContext = Genre.GetGenres();
                dgCompanies.DataContext = Company.GetCompanies();
                tbCurrentUser.Text = "Welcome, " + user + "!";
                if(user == "admin" || user == "user") {
                    btnLogin.Visibility = Visibility.Collapsed;
                    btnSignUp.Visibility = Visibility.Collapsed;
                    btnLogout.Visibility = Visibility.Visible;
                }
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
            tabAlbums.IsSelected = true;
        }
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

                DataRowView rowView = dgArtistEdit.SelectedItem as DataRowView;
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
                DataRowView rowView = dgArtistEdit.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = txtArtistName.Text;
                int year = int.Parse(txtArtistYear.Text);
                string country = txtArtistCountry.Text;

                MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Artist.UpdateArtist (key, name, country, year);
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
                if(columnIndex == 0) {
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
            }catch(Exception ex) {
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
        #endregion
        #region ALBUM
        private void btnAddAlbum_Click(object sender, RoutedEventArgs e) {
            try {
                //if (btnAddAlbum.Content.ToString() == "Add album") {
                //    txtAlbumName.Text = "";
                //    txtAlbumArtist.Text = "";
                //    txtAlbumYear.Text = "";
                //    txtAlbumCompany.Text = "";
                //    btnAddArtist.Content = "Save new album";
                //}
                //else {
                    string name = txtAlbumName.Text;
                    string artist = txtAlbumArtist.Text;
                    int year = int.Parse(txtAlbumYear.Text);
                    string company = txtAlbumCompany.Text;
                    Album.AddAlbum(name, artist, company, year);
                //}
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteAlbum_Click(object sender, RoutedEventArgs e) {
            try {

                DataRowView rowView = dgAlbumEdit.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = rowView.Row[1] as string;
                MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Album.DeleteAlbum(key);
                        }
                        catch (Exception ex) {

                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "No":
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateAlbum_Click(object sender, RoutedEventArgs e) {
            try {
                DataRowView rowView = dgAlbumEdit.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = txtAlbumName.Text;
                string artist = txtAlbumArtist.Text;
                int year = int.Parse(txtAlbumYear.Text);
                string company = txtAlbumCompany.Text;
                MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Album.UpdateAlbum(key, name, artist, company, year);
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "No":
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
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

        private void dgAlbumPage_SelectionChanged(object sender, SelectionChangedEventArgs e) {
                
        }

        private void dgAlbumEdit_SelectionChanged(object sender, SelectionChangedEventArgs e) {

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
            (Application.Current as App).User = "guest";
            this.handler.MoveToLogin();
            this.Close();
        }
        #endregion

    
        private void dgArtistEdit_SelectionChanged(object sender, SelectionChangedEventArgs e) {

        }
        #region TRACK
        private void btnAddTrack_Click(object sender, RoutedEventArgs e) { 
            try {
                //if (btnAddAlbum.Content.ToString() == "Add album") {
                //    txtAlbumName.Text = "";
                //    txtAlbumArtist.Text = "";
                //    txtAlbumYear.Text = "";
                //    txtAlbumCompany.Text = "";
                //    btnAddArtist.Content = "Save new album";
                //}
                //else {
                string name = txtTrackName.Text;
                string artist = txtTrackArtist.Text;
                string album = txtTrackAlbum.Text;
                int year = int.Parse(txtTrackYear.Text);
                Track.AddTrack(name, artist, album, year);
                //}
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDeleteTrack_Click(object sender, RoutedEventArgs e) {
            try {
                DataRowView rowView = dgTracksEdit.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = rowView.Row[1] as string;
                MessageBoxResult result = MessageBox.Show("Delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Track.DeleteTrack(key);
                        }
                        catch (Exception ex) {

                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "No":
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdateTrack_Click(object sender, RoutedEventArgs e) {
            try {
                DataRowView rowView = dgTracksEdit.SelectedItem as DataRowView;
                int key = (int)rowView[0];
                string name = txtTrackName.Text;
                string artist = txtTrackArtist.Text;
                string album = txtTrackAlbum.Text;
                int year = int.Parse(txtTrackYear.Text);
                MessageBoxResult result = MessageBox.Show("Save changes to " + name, "Save changes", MessageBoxButton.YesNo);
                switch (result.ToString()) {
                    case "Yes":
                        try {
                            Track.UpdateTrack(key, name, artist, album, year);
                        }
                        catch (Exception ex) {
                            MessageBox.Show(ex.Message);
                        }
                        break;
                    case "No":
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBackFromTrackEdit_Click(object sender, RoutedEventArgs e) {

        }
#endregion
    }
}
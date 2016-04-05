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
            test();
        }

        public void IniMyStuff() {
            try {

                //dgArtist.DataContext = Artist.GetArtists();
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
            //string name = txtName.Text;
            //string country = txtCountry.Text;
            //int year = int.Parse(txtYear.Text);
            //try {
            //    Artist.AddNewArtist(name, country, year);
            //}
            //catch (Exception ex) {
            //   MessageBox.Show(ex.Message);
            //}
        }

        private void btnDeleteArtist_Click(object sender, RoutedEventArgs e) {
            //try {
            //    DataRowView rowView = dgArtist.SelectedItem as DataRowView;
            //    string name = rowView.Row[1] as string;
            //    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete " + name + " from the database?", "Delete confirmation", MessageBoxButton.YesNo);
            //    switch (result.ToString()) {
            //        case "Yes":
            //            try {
            //                Artist.DeleteArtist(name);
            //            }
            //            catch (Exception ex) {
            //                MessageBox.Show(ex.Message);
            //            }
            //            break;
            //        case "No":
            //            break;
            //        default:
            //            break;
            //    }
            //}
            //catch (Exception ex) {

            //    MessageBox.Show(ex.Message);
            //}
        }
        private void btnChangeArtist_Click(object sender, RoutedEventArgs e) {
          
        }
        private void btnRefresh_Click(object sender, RoutedEventArgs e) {
            IniMyStuff();
        }
        private void dgTest_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //spArtist.DataContext = dgArtist.SelectedItem;

        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e) {
            tbTest.Visibility = Visibility.Collapsed;
        }

        private void test() {
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            ColumnDefinition gridCol3 = new ColumnDefinition();
            gridCol1.Width = new GridLength(150);
            gridCol2.Width = new GridLength(150);
            gridCol3.Width = new GridLength(150);
            gridTest.ColumnDefinitions.Add(gridCol1);
            gridTest.ColumnDefinitions.Add(gridCol2);
            gridTest.ColumnDefinitions.Add(gridCol3);

            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(45);
            RowDefinition gridRow2 = new RowDefinition();
            gridRow2.Height = new GridLength(45);
            RowDefinition gridRow3 = new RowDefinition();
            gridRow3.Height = new GridLength(45);
            gridTest.RowDefinitions.Add(gridRow1);
            gridTest.RowDefinitions.Add(gridRow2);
            gridTest.RowDefinitions.Add(gridRow3);

            TextBlock txtBlock1 = new TextBlock();
            txtBlock1.Text = "Artist";
            Grid.SetRow(txtBlock1, 0);
            Grid.SetColumn(txtBlock1, 0);

            TextBlock txtBlock2 = new TextBlock();
            txtBlock2.Text = "Year";
            Grid.SetRow(txtBlock2, 0);
            Grid.SetColumn(txtBlock2, 1);

            TextBlock txtBlock3 = new TextBlock();
            txtBlock3.Text = "County";
            Grid.SetRow(txtBlock3, 0);
            Grid.SetColumn(txtBlock3, 2);

            gridTest.Children.Add(txtBlock1);
            gridTest.Children.Add(txtBlock2);
            gridTest.Children.Add(txtBlock3);
           
            TextBlock artistText = new TextBlock();
            Run ln = new Run("Europe");
            Hyperlink link = new Hyperlink(ln);
            artistText.Inlines.Add(link);
            link.Click += (sender, e) =>
            {
                gridTest.Visibility = Visibility.Collapsed;
            };

            Grid.SetRow(artistText, 1);
            Grid.SetColumn(artistText, 0);

            TextBlock yearText = new TextBlock();
            yearText.Text = "1986";
            Grid.SetRow(yearText, 1);
            Grid.SetColumn(yearText, 1);

            TextBlock countryText = new TextBlock();
            countryText.Text = "Sweden";
            Grid.SetRow(countryText, 1);
            Grid.SetColumn(countryText, 2);

            gridTest.Children.Add(artistText);
            gridTest.Children.Add(yearText);
            gridTest.Children.Add(countryText);

            artistText = new TextBlock();
            artistText.Text = "Iron Maiden";
            Grid.SetRow(artistText, 2);
            Grid.SetColumn(artistText, 0);

            yearText = new TextBlock();
            yearText.Text = "1992";
            Grid.SetRow(yearText, 2);
            Grid.SetColumn(yearText, 1);

            countryText = new TextBlock();
            countryText.Text = "United States of America";
            countryText.FontSize = 12;
            countryText.FontWeight = FontWeights.Bold;
            Grid.SetRow(countryText, 2);
            Grid.SetColumn(countryText, 2);

            gridTest.Children.Add(artistText);
            gridTest.Children.Add(yearText);
            gridTest.Children.Add(countryText);       
        }
    }
}
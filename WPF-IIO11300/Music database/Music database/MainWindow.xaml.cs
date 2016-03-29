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

namespace Music_database {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnSearchFromDatabase_Click(object sender, RoutedEventArgs e) {

        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e) {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {

        }

        private void testConnection_Click(object sender, RoutedEventArgs e) {
            try {
                string cs = "datasource=mysql.labranet.jamk.fi;port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1";
                
                using (MySqlConnection conn = new MySqlConnection(cs)) {
                    conn.Open();
                    string sql = "SELECT * FROM cd";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataAdapter msda = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    msda.Fill(dt);
                    dgTest.DataContext = dt.DefaultView;
                    conn.Close();
                    MessageBox.Show("Connected");
                }
             
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

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
using System.Windows.Shapes;

namespace MusicDatabase {
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class BLRegister : Window {
        private static string cs = "datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1";
        WindowHandler handler = new WindowHandler();
        public BLRegister() {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            string username = txtUserName.Text;
            string password = txtPassword.Password;
            string repassword = txtReEnterPassword.Password;
            string message = "";
            Validator validator = new Validator();

            try {
                if (validator.Validate(username, password, repassword)) {

                    BLRegister register = new BLRegister(username, password);
                    if (register.RegisterUser(out message)) {
                        handler.MoveToLogin();
                        this.Close();
                        MessageBox.Show("Registration was successful!", "Registration Music Database");
                    }
                } else {
                    MessageBox.Show("Valid username: 6-20 characters.\nValid password: 8-20 characters.\nNo special characters.\nPasswords must match.", "Registration Music Database");
                }
            } catch (Exception ex) {
                message = ex.Message;
            } finally {
                if (message != "") {
                    MessageBox.Show(message, "Registration Music Database");
                }
            }
        }
        private void btnBackToLogin_Click_1(object sender, RoutedEventArgs e) {
            handler.MoveToLogin();
            this.Close();
        }

        private void btnBackToMain_Click(object sender, RoutedEventArgs e) {
            handler.MoveToMain();
            this.Close();
        }
    }
}

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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class BLLogin : Window {
        WindowHandler handler = new WindowHandler();
        public BLLogin() {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e) {
            handler.MoveToRegister();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            string username = txtUserName.Text;
            string password = txtPassword.Password;
            string message = "";
            Validator validator = new Validator();

            try {
                if (validator.ValidateLogin(username, password)) {

                    BLLogin login = new BLLogin(username, password);
                    if (login.LoginUser(out message)) {
                        handler.MoveToMain();
                        this.Close();
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

        private void btnBackToMain_Click(object sender, RoutedEventArgs e) {
            handler.MoveToMain();
            this.Close();
        }
    }
}

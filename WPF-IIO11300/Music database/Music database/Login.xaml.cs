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
        Validator validator;
        public BLLogin() {
            InitializeComponent();
            txtUsername.Focus();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e) {
            handler.MoveToRegister();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e) {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string message = "";
            validator = new Validator();

            try {
                if (validator.ValidateLogin(username, password)) {

                    BLLogin login = new BLLogin(username, password);
                    if (login.LoginUser(out message)) {
                        handler.MoveToMain();
                        this.Close();
                    } else {
                        txtPassword.Password = "";
                        txtPassword.Focus();
                    }
                } else {
                    MessageBox.Show("Valid username: 5-20 characters.\nValid password: 8-20 characters.\nNo special characters.\nPasswords must match.", "Registration Music Database");
                    txtPassword.Password = "";
                    txtPassword.Focus();
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e) {
            if ((e.Key == Key.Return)) {
                btnLogin_Click(null, null);
            }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e) {
            validator = new Validator();
            if (validator.CheckPassword(txtPassword.Password)) {
                var bc = new BrushConverter();
                btnLogin.Background = (Brush)bc.ConvertFrom("#ACCB12");
            } else {
                btnLogin.Background = Brushes.Gray;
            }
        }
    }
}

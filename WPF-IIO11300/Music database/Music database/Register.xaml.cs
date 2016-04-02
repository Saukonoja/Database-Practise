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
        WindowHandler handler = new WindowHandler();
        Validator validator;
        public BLRegister() {
            InitializeComponent();
            txtUsername.Focus();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            string username = txtUsername.Text;
            string password = txtPassword.Password;
            string repassword = txtReEnterPassword.Password;
            string message = "";
            validator = new Validator();

            try {
                if (validator.ValidateRegister(username, password, repassword)) {

                    BLRegister register = new BLRegister(username, password);
                    if (register.RegisterUser(out message)) {
                        handler.MoveToLogin();
                        this.Close();
                        MessageBox.Show("Registration was successful!", "Registration Music Database");
                    } else {
                        txtUsername.Text = "";
                        txtPassword.Password = "";
                        txtReEnterPassword.Password = "";
                        txtUsername.Focus();
                    }
                } else {
                    MessageBox.Show("Valid username: 5-20 characters.\nValid password: 8-20 characters.\nNo special characters.\nPasswords must match.", "Registration Music Database");
                    txtUsername.Text = "";
                    txtPassword.Password = "";
                    txtReEnterPassword.Password = "";
                    txtUsername.Focus();
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

        private void txtReEnterPassword_KeyDown(object sender, KeyEventArgs e) {
            if ((e.Key == Key.Return)) {
                btnRegister_Click(null, null);
            }
        }

        private void txtReEnterPassword_PasswordChanged(object sender, RoutedEventArgs e) {
            validator = new Validator();
            if ((validator.CheckPassword(txtPassword.Password)) && (validator.CheckPassword(txtReEnterPassword.Password)) &&
                (txtPassword.Password == txtReEnterPassword.Password)) {
                var bc = new BrushConverter();
                btnRegister.Background = (Brush)bc.ConvertFrom("#ACCB12");
            } else {
                btnRegister.Background = Brushes.Gray;
            }
        }
    }
}

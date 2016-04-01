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
    public partial class Register : Window {
        WindowHandler handler = new WindowHandler();
        public Register() {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e) {
            handler.MoveToLogin();
            this.Close();
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

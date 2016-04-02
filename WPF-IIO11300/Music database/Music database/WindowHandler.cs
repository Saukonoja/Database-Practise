using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDatabase {
    public class WindowHandler {
        public void MoveToMain() {
            MainWindow main = new MainWindow();
            App.Current.MainWindow = main;
            main.Show();
        }

        public void MoveToLogin() {
            BLLogin login = new BLLogin();
            App.Current.MainWindow = login;
            login.Show();
        }

        public void MoveToRegister() {
            BLRegister register = new BLRegister();
            App.Current.MainWindow = register; 
            register.Show();
        }
    }
}

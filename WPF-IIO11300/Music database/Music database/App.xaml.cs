using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MusicDatabase {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private string usertype = "guest";

        public String Usertype {
            get { return this.usertype; }
            set { this.usertype = value; }
        }

        private string username = "Guest";

        public String Username {
            get { return this.username; }
            set { this.username = value; }
        }
    }
}

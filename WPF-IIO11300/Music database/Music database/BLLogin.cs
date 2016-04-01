using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicDatabase {
    public partial class BLLogin {
        private static string connStr = "datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1";
        private string username;
        private string password;

        public BLLogin(string username, string password) {
            this.username = username;
            this.password = password;
        }
        public bool LoginUser(out string messageToUser) {
            try {
                string message = "";

                if (DBMusicDatabase.LoginUser(username, password, connStr, out message)) {
                    messageToUser = message;
                    return true;
                }
                messageToUser = message;
                return false;

            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}

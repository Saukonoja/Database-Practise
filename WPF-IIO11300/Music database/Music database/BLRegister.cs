using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MusicDatabase {

    public partial class BLRegister {
        private static string connStr = "datasource=mysql.labranet.jamk.fi; port=3306;username=H3298;password=dYeBlPSrM1swQ336LN90Fv7ZKFq7OZFB;database=H3298_1";
        private string username;
        private string password;
        private byte[] hash;

        public BLRegister(string username, string password) {
            this.username = username;
            hash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(this.password = password));
        }

        static bool VerifyPassword(byte[] hash, string password) {
            byte[] pwdHash = MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < 16; i++) {
                if (pwdHash[i] != hash[i]) return false;
            }
            return true;
        }

        public bool RegisterUser(out string messageToUser) {
            try {
                string message = "";

                if (DBMusicDatabase.RegisterUser(hash, username, connStr, out message)) {
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

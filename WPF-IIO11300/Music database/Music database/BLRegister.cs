using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace MusicDatabase {

    public partial class BLRegister {
        private string username;
        private string password;

        public BLRegister(string username, string password) {
            this.username = username;
            this.password = EncryptPassword(password);
        }

        public static string EncryptPassword(string password) {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create()) {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream()) {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write)) {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    password = Convert.ToBase64String(ms.ToArray());
                }
            }
            return password;
        }

        public bool RegisterUser(out string messageToUser) {
            try {
                string message = "";

                if (DBMusicDatabase.RegisterUser(username, password, out message)) {
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

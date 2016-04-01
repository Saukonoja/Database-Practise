using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicDatabase {
    public class Validator {

        public bool Validate(string username, string password, string repassword) {
            if (CheckUserName(username) && CheckPassword(password)) {
                if (password == repassword) {
                    return true;
                }
            }
            return false;
        }
        public bool CheckUserName(string username) {
            int numberOfSpecials = Regex.Matches(username, "[^a-zA-Z0-9]").Count;
            if ((username.Length >= 6 && username.Length <= 20) && numberOfSpecials == 0) {
                return true;
            }
            return false;
        }

        public bool CheckPassword(string password) {
            int numberOfSpecials = Regex.Matches(password, "[^a-zA-Z0-9]").Count;
            if ((password.Length >= 8 && password.Length <= 20) && numberOfSpecials == 0) {
                return true;
            }
            return false;
        }

    }
}

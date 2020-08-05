using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseConnect
{
    class MyUser
    {
        public MyUser()
        {
        }

        public MyUser(string username, string pass, string gender, string fullname)
        {
            Username = username;
            Password = pass;
            Gender = gender;
            Fullname = fullname;
        }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public string Fullname { get; set; }

        private static string error = "Username not exits!";

        public static void showError()
        {
            System.Windows.Forms.MessageBox.Show(error);
        }

        public static bool loginCheck(MyUser u1, MyUser u2)
        {
            if(u1 == null || u2 == null)
            {
                return false;
            }
            if(u1.Username != u2.Username)
            {
                error = "Username not exits!";
                return false;
            }
            else if(u1.Password != u2.Password)
            {
                error = "Password incorrect";
                return false;
            }

            return true;
        }
    }
}

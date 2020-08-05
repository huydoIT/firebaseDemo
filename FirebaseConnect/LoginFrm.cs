using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;

namespace FirebaseConnect
{
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "3ZeJDjD4noBWmGXfTL3FBwW7Da3Wzhp4ig5xgLTI",
            BasePath = "https://theusers-233fb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
                //if(client != null)
                //{
                //    messagebox.show("database connected!!");
                //}
            }
            catch {
                MessageBox.Show("Connection have problem");
            }
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            RegistrationFrm reg = new RegistrationFrm();
            reg.ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            #region Condition check
            if (string.IsNullOrWhiteSpace(txtUser.Text) &&
                string.IsNullOrWhiteSpace(txtPass.Text))
            {
                MessageBox.Show("Please Input Username and Password");
                return;
            }
            #endregion

            FirebaseResponse res = client.Get(@"User/" + txtUser.Text);
            MyUser resUser = res.ResultAs<MyUser>();

            MyUser curUser = new MyUser()
            {
                Username = txtUser.Text,
                Password = txtPass.Text
            };

            if(MyUser.loginCheck(resUser, curUser) == true)
            {
                //MessageBox.Show("Login Successed!!");
                MainFrm mainfrm = new MainFrm(resUser.Fullname);
                this.Hide();
                mainfrm.Show();
            }
            else
            {
                MyUser.showError();
            }
        }
    }
}

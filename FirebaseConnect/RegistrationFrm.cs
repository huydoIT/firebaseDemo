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
using FireSharp.Interfaces;
using FireSharp.Response;

namespace FirebaseConnect
{
    public partial class RegistrationFrm : Form
    {
        public RegistrationFrm()
        {
            InitializeComponent();
        }

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "3ZeJDjD4noBWmGXfTL3FBwW7Da3Wzhp4ig5xgLTI",
            BasePath = "https://theusers-233fb.firebaseio.com/"
        };

        IFirebaseClient client;

        private void RegistrationFrm_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("Connection have problem");
            }

        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            #region Condition check
            if (string.IsNullOrWhiteSpace(txtUser.Text) &&
                string.IsNullOrWhiteSpace(txtPass.Text) &&
                string.IsNullOrWhiteSpace(txtName.Text) &&
                string.IsNullOrWhiteSpace(cbGender.Text))
            {
                MessageBox.Show("Please input All fields");
                return;
            }
            #endregion

            MyUser user = new MyUser()
            {
                Username = txtUser.Text,
                Password = txtPass.Text,
                Gender = cbGender.Text,
                Fullname = txtName.Text
            };

            SetResponse set = client.Set(@"User/" + txtUser.Text, user);

            MessageBox.Show("Successfully registration!!");
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

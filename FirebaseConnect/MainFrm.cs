using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirebaseConnect
{
    public partial class MainFrm : Form
    {
        string _name;

        public MainFrm()
        {
            InitializeComponent();
        }

        public MainFrm(string name)
        {
            _name = name;
            InitializeComponent();

            this.lbName.Text = "Hello " + _name;
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginFrm frm = new LoginFrm();
            if(frm.Visible == false)
            {
                frm.Show();
            }
        }
    }
}

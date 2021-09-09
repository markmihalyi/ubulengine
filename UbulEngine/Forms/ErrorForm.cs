using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbulEngine
{
    public partial class ErrorForm : Form
    {
        public ErrorForm(string error, bool kitagadva = false)
        {
            InitializeComponent();
            lbl_error.Text = error;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Process.Start("UbulEngine.exe");
        }
    }
}

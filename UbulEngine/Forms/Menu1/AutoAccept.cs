using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbulEngine
{
    public partial class AutoAccept : Form
    {
        public static bool TurnedOn = false;

        public AutoAccept()
        {
            InitializeComponent();

            if (TurnedOn)
            {
                btn_toggleAuto.Text = "Kikapcsolás";
                btn_toggleAuto.BackColor = Color.FromArgb(252, 164, 164);
            }
            else
            {
                btn_toggleAuto.Text = "Bekapcsolás";
                btn_toggleAuto.BackColor = Color.FromArgb(169, 252, 164);
            }
        }

        private void btn_toggleAuto_Click(object sender, EventArgs e)
        {
            TurnedOn = !TurnedOn;
            if (TurnedOn)
            {
                btn_toggleAuto.Text = "Kikapcsolás";
                btn_toggleAuto.BackColor = Color.FromArgb(252, 164, 164);
            }
            else
            {
                btn_toggleAuto.Text = "Bekapcsolás";
                btn_toggleAuto.BackColor = Color.FromArgb(169, 252, 164);
            }
        }
    }
}

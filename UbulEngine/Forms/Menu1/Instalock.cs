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
    public partial class Instalock : Form
    {
        public static bool TurnedOn = false;
        public static string champName;
        public static int champId;

        public Instalock()
        {
            InitializeComponent();
            tb_champName.Text = champName;
            API.instalockError = false;
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
            if (API.GetChampionIdByName(tb_champName.Text) != 0)
            {
                TurnedOn = !TurnedOn;
                if (TurnedOn)
                {
                    champName = tb_champName.Text.Trim();
                    champId = API.GetChampionIdByName(tb_champName.Text);
                    btn_toggleAuto.Text = "Kikapcsolás";
                    btn_toggleAuto.BackColor = Color.FromArgb(252, 164, 164);
                }
                else
                {
                    btn_toggleAuto.Text = "Bekapcsolás";
                    btn_toggleAuto.BackColor = Color.FromArgb(169, 252, 164);
                }
            }
            else
            {
                MessageBox.Show("Nincs ilyen karakter vagy elírtad.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

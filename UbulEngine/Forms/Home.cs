using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbulEngine
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo("https://gonext.today/blog/explorer/icon")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        private void btn_changeicon_Click(object sender, EventArgs e)
        {
            if (API.ChangeIconGlobal(Convert.ToInt32(idInput.Value)) == "Created")
            {
                MessageBox.Show("Sikeresen megváltoztattad az ikonod!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                try { summonerIcon.Load($"https://ddragon.leagueoflegends.com/cdn/{API.GetLolLatestVersion()}/img/profileicon/{API.GetCurrentSummoner("profileIconId")}.png"); } catch { }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Nincs meg neked az az ikon amit be szeretnél állítani.\nÍgy is be szeretnéd állítani úgy, hogy csak saját magad lásd?", "Figyelmeztetés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Debug.WriteLine(API.ChangeIconLocal(Convert.ToInt32(idInput.Value)));
                    if (API.ChangeIconLocal(Convert.ToInt32(idInput.Value)) == "Created")
                    {
                        MessageBox.Show("Sikeresen megváltoztattad az ikonod!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}

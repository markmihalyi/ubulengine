using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class InviteSpam : Form
    {
        public static bool SpamButtonReady = false;
        public static bool SpamTurnedOn = false;
        public static bool SettingsView = false;
        public static string RiotClientServicesPath;
        public static long summonerId;

        public InviteSpam()
        {
            InitializeComponent();
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ue_accounts.json"))
            {
                LoadSavedAccounts();
            }
            else
            {
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ue_accounts.json", "[]");
            }

            if (SpamTurnedOn)
            {
                btn_toggleSpam.Text = "Kikapcsolás";
                btn_toggleSpam.BackColor = Color.FromArgb(252, 164, 164);
            }
            else
            {
                btn_toggleSpam.Text = "Bekapcsolás";
                btn_toggleSpam.BackColor = Color.FromArgb(169, 252, 164);
            }
        }

        private void LoadSavedAccounts()
        {
            for (int i = 1; i <= 40; i++)
            {
                var c = Controls.Find("textBox" + i.ToString(), true);
                c.OfType<TextBox>().ToArray()[0].Text = string.Empty;
            }

            string strJson = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ue_accounts.json");
            JArray jarray = JArray.Parse(strJson);
            int textBoxIndex = 1;
            foreach (JObject account in jarray)
            {
                var c1 = Controls.Find("textBox" + textBoxIndex.ToString(), true);
                var c2 = Controls.Find("textBox" + (textBoxIndex + 1).ToString(), true);
                c1.OfType<TextBox>().ToArray()[0].Text = account.GetValue("username").ToString();
                c2.OfType<TextBox>().ToArray()[0].Text = account.GetValue("password").ToString();
                textBoxIndex += 2;
            }
        }

        private void btn_toggleSpam_Click(object sender, EventArgs e)
        {
            if (SpamButtonReady)
            {
                if (tb_summonerName.Text != string.Empty)
                {
                    SpamTurnedOn = !SpamTurnedOn;
                    if (SpamTurnedOn)
                    {
                        summonerId = API.GetSummonerIdByName(tb_summonerName.Text);
                        btn_toggleSpam.Text = "Kikapcsolás";
                        btn_toggleSpam.BackColor = Color.FromArgb(252, 164, 164);
                        API.InviteSpamStartTimer();
                    }
                    else
                    {
                        btn_toggleSpam.Text = "Bekapcsolás";
                        btn_toggleSpam.BackColor = Color.FromArgb(169, 252, 164);
                        API.SpamStopTimer();
                    }
                }
                else
                {
                    MessageBox.Show("Előbb írj be egy nevet.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Előbb kattints az inicializálás gombra, és várd végig a kliensek betöltését.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_inicialize_Click(object sender, EventArgs e)
        {
            if (tb_riotclientservices.Text != "RiotClientServices.exe helye")
            {
                API.SpamInicialize();
            }
            else
            {
                MessageBox.Show("Először add meg a RiotClientServices.exe elérési útvonalát!", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_deactivate_Click(object sender, EventArgs e)
        {
            API.SpamDeactivate();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            SettingsView = !SettingsView;
            if (SettingsView)
            {
                panel2.Visible = true;
                panel3.Visible = true;
                btn_save.Visible = true;
                btn_settings.Text = "Vissza";
            }
            else
            {
                panel2.Visible = false;
                panel3.Visible = false;
                btn_save.Visible = false;
                btn_settings.Text = "Fiókok kezelése";
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            JArray jarray = new JArray();
            for (int i = 1; i <= 40; i += 2)
            {
                var c1 = Controls.Find("textBox" + i.ToString(), true);
                var c2 = Controls.Find("textBox" + (i + 1).ToString(), true);
                string tbtext_username = c1.OfType<TextBox>().ToArray()[0].Text;
                string tbtext_password = c2.OfType<TextBox>().ToArray()[0].Text;
                if (tbtext_username != string.Empty || tbtext_password != string.Empty)
                {
                    string json = $@"{{'username': '{tbtext_username}','password': '{tbtext_password}'}}";
                    jarray.Add(JObject.Parse(json));
                }
            }
            string strJson = jarray.ToString();
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ue_accounts.json", strJson);
            MessageBox.Show("Sikeresen elmentetted a fiókok adatait!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 40; i++)
            {
                var c = Controls.Find("textBox" + i.ToString(), true);
                c.OfType<TextBox>().ToArray()[0].Text = string.Empty;
            }

            string strJson = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ue_accounts.json");
            JArray jarray = JArray.Parse(strJson);
            int textBoxIndex = 1;
            foreach (JObject account in jarray)
            {
                var c1 = Controls.Find("textBox" + textBoxIndex.ToString(), true);
                var c2 = Controls.Find("textBox" + (textBoxIndex + 1).ToString(), true);
                c1.OfType<TextBox>().ToArray()[0].Text = account.GetValue("username").ToString();
                c2.OfType<TextBox>().ToArray()[0].Text = account.GetValue("password").ToString();
                textBoxIndex += 2;
            }
            MessageBox.Show("Sikeresen betöltötted a fiókok adatait!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_selectpath_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_riotclientservices.Text = openFileDialog.FileName;
                RiotClientServicesPath = openFileDialog.FileName;
            }
        }
    }
}

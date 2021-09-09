using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace UbulEngine
{
    public partial class Main : Form
    {
        private static bool clientReady = true;

        // Alapvető adatok
        private static System.Threading.Timer timer;
        private string summonerName;
        private string summonerLvl;
        private int percentCompleteForNextLevel;
        private string summonerLvlAfter;
        private string summonerXpStatus;
        private string summonerRp;
        private string summonerBe;

        // Jogosultságok
        private bool autoAccept;
        private bool instalock;
        private bool availabilityChanger;
        private bool inviteSpam;

        public Main()
        {
            InitializeComponent();
            lbl_version.Parent = btnHome;
            lbl_version.Text = $"v{API.appVersion}";
            InitializeNotifyIconMenu();
            hideSubMenu();

            if (CheckIfClientIsRunning())
            {
                if (API.IsClientReady())
                {
                    summonerName = API.GetCurrentSummoner("displayName");
                    summonerLvl = API.GetCurrentSummoner("summonerLevel");
                    percentCompleteForNextLevel = Convert.ToInt32(API.GetCurrentSummoner("percentCompleteForNextLevel"));
                    summonerLvlAfter = (Convert.ToInt32(API.GetCurrentSummoner("summonerLevel")) + 1).ToString();
                    summonerXpStatus = $"{API.GetCurrentSummoner("xpSinceLastLevel")} / {Convert.ToInt32(API.GetCurrentSummoner("xpUntilNextLevel"))}";
                    summonerRp = API.GetCurrentSummonerWallet("rp");
                    summonerBe = API.GetCurrentSummonerWallet("ip");
                    if (API.GetUserPermission(summonerName, "AutoAccept")) autoAccept = true; else autoAccept = false;
                    if (API.GetUserPermission(summonerName, "Instalock")) instalock = true; else instalock = false;
                    if (API.GetUserPermission(summonerName, "AvailabilityChanger")) availabilityChanger = true; else availabilityChanger = false;
                    if (API.GetUserPermission(summonerName, "InviteSpam")) inviteSpam = true; else inviteSpam = false;
                    timer = new System.Threading.Timer(_ => LCUTimer(), null, 0, 100);
                    if (summonerName == "Six Path Crab" || summonerName == "Túró typec cx") btn_typec.Visible = true;
                    API.UpdateChampionDatas();
                    ShowHomeForm();
                }
                else
                {
                    clientReady = false;
                    openChildForm(new ErrorForm("A kliens még nem töltött be teljesen."));
                }
            }
            else
            {
                clientReady = false;
                openChildForm(new ErrorForm("Indítsd el a klienst!"));
            }
        }

        private void ShowHomeForm()
        {
            Home h = new Home();

            // Ikon
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, (h.summonerIcon.Width + 13), (h.summonerIcon.Height + 3));
            Region rg = new Region(gp);
            h.summonerIcon.Region = rg;
            try { h.summonerIcon.Load($"https://ddragon.leagueoflegends.com/cdn/{API.GetLolLatestVersion()}/img/profileicon/{API.GetCurrentSummoner("profileIconId")}.png"); } catch { }

            // Név
            h.summonerName.Text = summonerName;

            // Szint
            h.summonerLvl.Text = summonerLvl;
            try
            {
                int haladasX = 114 * percentCompleteForNextLevel / 100;
                h.summonerLvlProgress.Size = new Size(haladasX, 23);
            }
            catch { }
            h.summonerLvlAfter.Text = summonerLvlAfter;

            // EXP
            h.summonerXpStatus.Text = summonerXpStatus;

            // RP
            h.summonerRp.Text = summonerRp;

            // BE
            h.summonerBe.Text = summonerBe;

            //! Home form megnyitása
            openChildForm(h);
        }

        private void hideSubMenu()
        {
            panelMenu1SubMenu.Visible = false;
            panelMenu2SubMenu.Visible = false;
            panelMenu3SubMenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnMenu1_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMenu1SubMenu);
        }

        #region Menu1SubMenu
        private void btn_autoaccept_Click(object sender, EventArgs e)
        {
            if (clientReady)
            {
                if (autoAccept)
                {
                    openChildForm(new AutoAccept());
                }
                else
                {
                    MessageBox.Show("Ez a funkció számodra nem elérhető.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_instalock_Click(object sender, EventArgs e)
        {
            if (clientReady)
            {
                if (instalock)
                {
                    openChildForm(new Instalock());
                }
                else
                {
                    MessageBox.Show("Ez a funkció számodra nem elérhető.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void btnMenu2_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMenu2SubMenu);
        }

        #region Menu2Submenu
        private void btn_changeavailability_Click(object sender, EventArgs e)
        {
            if (clientReady)
            {
                if (availabilityChanger)
                {
                    openChildForm(new AvailabilityChanger());
                }
                else
                {
                    MessageBox.Show("Ez a funkció számodra nem elérhető.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void btnMenu3_Click(object sender, EventArgs e)
        {
            showSubMenu(panelMenu3SubMenu);
        }

        #region Menu3Submenu
        private void btn_invitespam_Click(object sender, EventArgs e)
        {
            if (clientReady)
            {
                if (inviteSpam)
                {
                    openChildForm(new InviteSpam());
                }
                else
                {
                    MessageBox.Show("Ez a funkció számodra nem elérhető.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (clientReady && activeForm.ToString() != "UbulEngine.Home, Text: Home")
            {
                activeForm.Close();
                ShowHomeForm();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Automatizált folyamatok lelke
        /// </summary>
        private void LCUTimer()
        {
            if (AutoAccept.TurnedOn)
            {
                if (API.GetGameflowPhase() == "\"ReadyCheck\"")
                {
                    API.AcceptReadyCheckRequest();
                }
            }
            if (Instalock.TurnedOn)
            {
                if (API.GetGameflowPhase() == "\"ChampSelect\"")
                {
                    API.InstalockChampion(Instalock.champId);
                }
            }
        }

        /// <summary>
        /// Ellenőrzi, hogy fut-e a lol kliens
        /// </summary>
        /// <returns>Bool értéket ad vissza az alapján, hogy
        /// fut-e "LeagueClientUx" néven alkalmazás.</returns>
        public static bool CheckIfClientIsRunning()
        {
            return Process.GetProcesses().Any(p => p.ProcessName.Contains("LeagueClientUx"));
        }

        /* ------------------- */
        /* Értesítés ikon menü */
        /* ------------------- */

        // Inicializálás
        private void InitializeNotifyIconMenu()
        {
            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.BackColor = Color.FromArgb(41, 42, 45);
            notifyIcon.ContextMenuStrip.ForeColor = Color.White;
            notifyIcon.ContextMenuStrip.Items.Add("Kilépés", null, MenuExit_Click);
        }

        // Gombok
        private void MenuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Ablak kicsinyítésekor megjeleníti az értesítés ikont
        private void Main_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;
            }
        }

        // Az értesítés ikonra bal klikkel kattintva megjelenik a fő ablak
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Show();
                WindowState = FormWindowState.Normal;
                notifyIcon.Visible = false;
            }
        }

        private void btn_typec_Click(object sender, EventArgs e)
        {
            API.typec();
        }

        private void btn_changelog_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo("https://github.com/markmihalyi/UbulEngine")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

        /* RBK A KIRÁLY
        private void button9_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("megjött az ítélethozatal");
            MessageBox.Show("az Oláh cigányok közül");
            MessageBox.Show("KI LETTÉL TAGADVA");
        }
        */

        /* RESTART GOMB
         private void btn_restart_Click(object sender, EventArgs e)
         {
             Application.Restart();
             Environment.Exit(0);
         }
         */
    }
}

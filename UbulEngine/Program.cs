using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace UbulEngine
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!API.IsUpToDate())
            {
                DialogResult dr = MessageBox.Show("A program futtatásához szükséges frissítés elérhető.", "Új frissítés elérhető", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    if (File.Exists("Updater.exe"))
                    {
                        Process.Start("Updater.exe");
                    }
                    else
                    {
                        MessageBox.Show("Nem található az \"Updater.exe\" fájl. \nTelepítsd újra a programot.");
                    }
                    Application.Exit();
                }
            }
            else
            {
                Application.Run(new Main());
            }
        }
    }
}

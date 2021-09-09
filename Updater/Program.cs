using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Updater
{
    class Program
    {
        static void Main(string[] args)
        {
            // Régi fájlok törlése
            foreach (var file in Directory.GetFiles(Environment.CurrentDirectory))
            {
                if (file != @$"{Environment.CurrentDirectory}\Updater.exe" && file != @$"{Environment.CurrentDirectory}\unins000.dat" && file != @$"{Environment.CurrentDirectory}\unins000.exe")
                    File.Delete(file);
            }

            // A legfrissebb verzió letöltése
            WebClient wc1 = new WebClient();
            wc1.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            wc1.Headers.Add("Cache-Control", "no-cache");
            string latestVersion = wc1.DownloadString("https://markmihalyi.github.io/UbulEngine_PrivateMisc/latest.txt").Trim();
            WebClient wc2 = new WebClient();
            wc2.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
            wc2.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
            wc2.DownloadFileAsync(new Uri("https://markmihalyi.github.io/UbulEngine_PrivateMisc/UbulEngine-" + latestVersion + ".zip"), "latest.zip");

            // Fájlok kicsomagolása
            while (true)
            {
                long filesize = 0;
                try { filesize = new FileInfo("latest.zip").Length; } catch { }
                if (File.Exists($@"{Environment.CurrentDirectory}\latest.zip") && filesize != 0)
                {
                    ZipFile.ExtractToDirectory(@$"{Environment.CurrentDirectory}\latest.zip", Environment.CurrentDirectory);
                    break;
                }
                Thread.Sleep(500);
            }

            // Tömörített fájl törlése
            File.Delete("latest.zip");

            Thread.Sleep(1500);

            // Frissítés kész -> program indítása
            DialogResult dr = MessageBox.Show("A program frissítése megtörtént.", " ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            if (dr == DialogResult.OK) Process.Start("UbulEngine.exe");
        }
    }
}

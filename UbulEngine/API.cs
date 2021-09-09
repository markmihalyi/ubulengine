using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UbulEngine
{
    class API
    {
        /// <summary>
        /// Lekérdezi a program legfrisebb verzióját
        /// </summary>
        /// <returns>Amennyiben a legfrissebb verzió eltér a
        /// jelenleg telepített példánytól, TRUE értéket ad vissza.</returns>
        public static string appVersion = "1.0.6";
        public static bool IsUpToDate()
        {
            WebClient wc = new WebClient();
            wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            wc.Headers.Add("Cache-Control", "no-cache");
            string latestVersion = wc.DownloadString("https://markmihalyi.github.io/UbulEngine_PrivateMisc/latest.txt").Trim();
            if (appVersion == latestVersion) return true;
            return false;
        }

        /// <summary>
        /// API-kérelem küldése, válasz fogadása
        /// </summary>
        /// <param name="path">API-kérelem elérési útvonala</param>
        /// <param name="method">API-kérelem típusa</param>
        /// <returns>Visszaadja az API-kérelemre kapott választ.
        /// Ezt később bárhogyan lekezelhetjük, megkaphatjuk az egész választ
        /// vagy akár az API-kérelemre visszakapott státusz kódot.</returns>
        public static IRestResponse SendRequest(string path, Method method, string body = null, string paramName = null, string paramValue = null, int? pid = null, int? appPort = null, string authToken = null)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            string encoded;
            if (pid != null) encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"riot:{GetRemotingAuthToken(pid)}"));
            else if (appPort != null && authToken != null) encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"riot:{authToken}"));
            else encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"riot:{GetRemotingAuthToken()}"));

            RestClient client;
            if (pid != null) client = new RestClient("https://127.0.0.1:" + GetAppPort(pid) + path);
            else if (appPort != null && authToken != null) client = new RestClient("https://127.0.0.1:" + appPort + path);
            else client = new RestClient("https://127.0.0.1:" + GetAppPort() + path);

            var request = new RestRequest(method);
            request.AddHeader("Authorization", $"Basic {encoded}");
            if (body != null)
            {
                request.AddHeader("Content-Type", "application/json");
                request.AddJsonBody(body);
            }
            if (paramName != null && paramValue != null)
            {
                request.AddParameter(paramName, paramValue);
            }
            IRestResponse response = client.Execute(request);
            return response;
        }
        
        public static Dictionary<string, int> champDatas = new Dictionary<string, int>();

        public static int GetChampionIdByName(string champName)
        {
            if (champDatas.ContainsKey(champName)) return champDatas[champName];
            return 0;
        }

        public static void UpdateChampionDatas()
        {
            WebClient wc = new WebClient();
            wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            wc.Headers.Add("Cache-Control", "no-cache");
            string championsJson = wc.DownloadString($"http://ddragon.leagueoflegends.com/cdn/{GetLolLatestVersion()}/data/en_US/champion.json").Trim();
            JObject champions = JObject.Parse(championsJson);
            foreach (JProperty championProperty in champions.GetValue("data"))
            {
                string champName = championProperty.Name;
                int champId = 0;
                foreach (var championData in championProperty)
                {
                    if (championData["id"].ToString() == championProperty.Name.ToString()) champId = Convert.ToInt32(championData["key"]);
                }
                champDatas.Add(champName, champId);
            }
        }

        /// <summary>
        /// Lekéri a lol legfrissebb verzióját
        /// </summary>
        /// <returns>Visszaadja string-ként a verzió megnevezését.</returns>
        public static string GetLolLatestVersion()
        {
            WebClient wc = new WebClient();
            wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);
            wc.Headers.Add("Cache-Control", "no-cache");
            string latestVersion = wc.DownloadString("https://ddragon.leagueoflegends.com/api/versions.json").Trim();
            return JArray.Parse(latestVersion)[0].ToString();
        }

        /// <summary>
        /// Automatikusan kiválasztja a kívánt karaktert, ha nincs kitiltva
        /// </summary>
        private static bool processRunning = true;
        public static bool instalockError = false;
        public static void InstalockChampion(int id)
        {
            if (processRunning)
            {
                processRunning = false;
                if (SendRequest("/lol-champ-select/v1/current-champion", Method.GET).Content == "0")
                {
                    JObject session = JObject.Parse(SendRequest("/lol-champ-select/v1/session", Method.GET).Content);
                    JArray myTeam = JArray.Parse(session.GetValue("myTeam").ToString());
                    string mySummonerId = GetCurrentSummoner("summonerId");
                    int myCellOrder = -1;
                    foreach (JObject summoner in myTeam)
                    {
                        if (summoner.GetValue("summonerId").ToString() == mySummonerId)
                        {
                            myCellOrder = Convert.ToInt32(summoner.GetValue("cellId"));
                        }
                    }
                    JArray actionsArray = JArray.Parse(session.GetValue("actions").ToString());
                    JArray actions = JArray.Parse(actionsArray[0].ToString());
                    int mySummonerOrderId = -1;
                    foreach (JObject action in actions)
                    {
                        if (action.GetValue("actorCellId").ToString() == myCellOrder.ToString())
                        {
                            mySummonerOrderId = Convert.ToInt32(action.GetValue("id"));
                            break;
                        }
                    }
                    var r = SendRequest("/lol-champ-select/v1/session/actions/" + mySummonerOrderId, Method.PATCH, "{\"completed\":true,\"championId\":" + id + "}");
                    if (!instalockError)
                    {
                        if (r.StatusCode.ToString() == "NoContent")
                        {
                            MessageBox.Show("Megkaptad azt a hőst, amit kiválasztottál.", " ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            instalockError = false;
                        }
                        else
                        {
                            MessageBox.Show("Nem sikerült kiválasztani a hőst.", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                            instalockError = true;
                        }
                    }
                    processRunning = true;
                }
                else
                {
                    processRunning = true;
                }
            }
        }

        /// <summary>
        /// Megváltoztatja az ikonod a megadott id-jű ikonra (GLOBÁLIS)
        /// </summary>
        /// <param name="id"></param>
        public static string ChangeIconGlobal(int id)
        {
            var r = SendRequest("/lol-summoner/v1/current-summoner/icon", Method.PUT, "{\"profileIconId\": " + id + "}");
            return r.StatusCode.ToString();
        }

        /// <summary>
        /// Megváltoztatja az ikonod a megadott id-jű ikonra (LOKÁLIS)
        /// </summary>
        /// <param name="id"></param>
        public static string ChangeIconLocal(int id)
        {
            var r = SendRequest("/lol-chat/v1/me", Method.PUT, "{\"icon\": " + id + "}");
            return r.StatusCode.ToString();
        }

        /// <summary>
        /// Megváltoztatja az elérhetőségi állapotod
        /// </summary>
        /// <param name="selectedIndex">A kiválasztott elem indexe.</param>
        public static void ChangeAvailability(int selectedIndex)
        {
            string mode = null;
            switch (selectedIndex)
            {
                case 0:
                    mode = "online";
                    break;
                case 1:
                    mode = "away";
                    break;
                case 2:
                    mode = "mobile";
                    break;
                case 3:
                    mode = "offline";
                    break;
            }
            SendRequest("/lol-chat/v1/me", Method.PUT, "{\"availability\": \"" + mode + "\"}");
        }

        /// <summary>
        /// Kliensek indítása, elrejtése háttérbe
        /// </summary>
        private static List<int> appPorts = new List<int>();
        private static List<string> authTokens = new List<string>();
        private static List<int> i_list = new List<int>();
        public static void SpamInicialize()
        {
            if (!(File.ReadAllText("ue_accounts.json").Trim() == "[]"))
            {
                JArray jarray = JArray.Parse(File.ReadAllText("ue_accounts.json"));
                int i = 1;
                foreach (JObject account in jarray)
                {
                    int riotClientPort = 6900 + i;
                    string username = account.GetValue("username").ToString();
                    string password = account.GetValue("password").ToString();

                    var p = Process.Start(InviteSpam.RiotClientServicesPath, $"--launch-product=league_of_legends --launch-patchline=live --app-port={riotClientPort} --remoting-auth-token=kItBNgRIncu_Wn6Xgthi3w --headless --allow-multiple-clients");
                    while (true)
                    {
                        var r1 = SendRequest("/rnet-product-registry/v4/player-products-state", Method.GET, null, null, null, p.Id);
                        if (r1.StatusCode.ToString() != "0") break;
                        Thread.Sleep(100);
                    }
                    SendRequest("/rso-auth/v2/authorizations", Method.POST, "{\"clientId\":\"riot-client\",\"trustLevels\":[\"always_trusted\"]}", null, null, p.Id);
                    SendRequest("/rso-auth/v1/session/credentials", Method.PUT, "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"persistLogin\":false}", null, null, p.Id);
                    SendRequest("/product-launcher/v1/products/league_of_legends/patchlines/live", Method.POST, null, null, null, p.Id);

                    int leagueClientUxPID;
                    while (true)
                    {
                        leagueClientUxPID = Convert.ToInt32(Process.GetProcessesByName("LeagueClientUx").OrderBy(x => x.StartTime).Last().Id);
                        if (Process.GetProcessById(Process.GetProcessById(leagueClientUxPID).Parent().Id).Parent().Id == p.Id)
                        {
                            //Debug.WriteLine("got'em: " + leagueClientUxPID);
                            break;
                        }
                        Thread.Sleep(100);
                    }
                    while (true)
                    {
                        var r2 = SendRequest("/lol-lobby/v2/eligibility/initial-configuration-complete", Method.GET, null, null, null, leagueClientUxPID);
                        if (r2.Content == "true") break;
                        Thread.Sleep(100);
                    }
                    //Debug.WriteLine("BIG POG");
                    appPorts.Add(GetAppPort(leagueClientUxPID));
                    authTokens.Add(GetRemotingAuthToken(leagueClientUxPID));
                    SendRequest("/riotclient/kill-ux", Method.POST, null, null, null, leagueClientUxPID);
                    i_list.Add(i);
                    //Debug.WriteLine(i + ". kliens betöltése megtörtént.");
                    i++;
                    //if (i == 4)
                    if (i == (jarray.Count + 1))
                    {
                        InviteSpam.SpamButtonReady = true;
                        MessageBox.Show("A kliensek betöltése megtörtént. \nMost már használhatod a \"Bekapcsolás\" gombot.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Nem állítottál még be egy fiókot sem.\nA \"Fiókok kezelése\" gombra kattintva teheted meg.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private static System.Threading.Timer timer;
        public static void InviteSpamStartTimer()
        {
            timer = new System.Threading.Timer(_ => InviteSpamTimer(), null, 0, 1000);
        }

        public static void SpamStopTimer()
        {
            timer.Dispose();
        }

        private static void InviteSpamTimer()
        {
            foreach (int i in i_list)
            {
                SendRequest("/lol-lobby/v2/lobby", Method.POST, "{\"customGameLobby\":{\"configuration\":{\"gameMode\":\"CLASSIC\",\"gameMutator\":\"\",\"gameServerRegion\":\"\",\"mapId\":11,\"mutators\":{\"id\":2},\"spectatorPolicy\":\"NotAllowed\",\"teamSize\":5},\"lobbyName\":\"Custom Game\",\"lobbyPassword\":\"wrhgerhbjúerwh445968\"},\"isCustom\":true}", null, null, null, appPorts[i - 1], authTokens[i - 1]);
                //Debug.WriteLine("Új lobby: " + r1.StatusCode);

                SendRequest("/lol-lobby/v2/lobby/invitations", Method.POST, "[{\"toSummonerId\":" + InviteSpam.summonerId + "}]", null, null, null, appPorts[i - 1], authTokens[i - 1]);
                //Debug.WriteLine("Meghívás: " + r2.StatusCode);

                //var r3 = SendRequest("/lol-lobby/v2/lobby", Method.DELETE, null, null, null, null, appPorts[i], authTokens[i]);
                //Debug.WriteLine("Lobby törlés: " + r3.StatusCode);
            }
        }


        //! TODO kikapcs
        public static void SpamDeactivate()
        {
            foreach (var process in Process.GetProcessesByName("RiotClientServices"))
            {
                process.Kill();
            }
            foreach (var process in Process.GetProcessesByName("LeagueClient"))
            {
                process.Kill();
            }
        }

        /// <summary>
        /// Lekérdezi a felhasználó összes barátjának nevét
        /// </summary>
        /// <returns>Visszaadja a neveket string-ként.</returns>
        public static List<string> GetFriendsName()
        {
            var r = SendRequest("/lol-chat/v1/friends", Method.GET);
            List<string> friendNames = new List<string>();
            JArray jsonArray = JArray.Parse(r.Content);
            foreach (JObject item in jsonArray)
            {
                friendNames.Add(item["name"].ToString());
            }
            friendNames.RemoveAt(0);
            friendNames.Sort();
            return friendNames;
        }

        /// <summary>
        /// A paraméterben megadott névhez tartozó id lekérése
        /// </summary>
        /// <param name="summonerName"></param>
        /// <returns>Visszaadja int-ként az id-t.</returns>
        public static long GetSummonerIdByName(string summonerName)
        {
            var r = SendRequest($"/lol-summoner/v1/summoners", Method.GET, null, "name", summonerName);
            return Convert.ToInt64(JObject.Parse(r.Content).GetValue("summonerId").ToString());
        }


        /// <summary>
        /// Lekérdezi, hogy engedélyezett-e a felhasználó a szoftver használatára
        /// </summary>
        /// <param name="summonerName"></param>
        /// <returns>Amennyiben az users.txt tartalmazza a felhasználó nevét,
        /// akkor TRUE-, más esetben FALSE értéket ad vissza.</returns>
        public static bool GetUserPermission(string summonerName, string permissionName)
        {
            string jsonRaw = new WebClient().DownloadString("https://markmihalyi.github.io/UbulEngine_PrivateMisc/permissions/WZpf9Ern9ejFndFgxcwPFaUSbagoaiTwJoCApo4SCifLFdvdhZhGWQ8ZPz8k4zbVp3W2Cyu6AUxJEesBgYgCmV8QVYKoQm2237.json").Trim();
            string jsonUtf8 = Encoding.UTF8.GetString(Encoding.Default.GetBytes(jsonRaw));
            JArray users = JArray.Parse(jsonUtf8);

            // Meghatározott felhasználók (VIP)
            foreach (JObject user in users)
            {
                if (user.GetValue("username").ToString() == summonerName)
                {
                    return Convert.ToBoolean(user.GetValue(permissionName));
                }
            }

            // Alapértelmezett jogosultságok
            jsonRaw = new WebClient().DownloadString("https://markmihalyi.github.io/UbulEngine_PrivateMisc/permissions/DefaultPermissions.json").Trim();
            jsonUtf8 = Encoding.UTF8.GetString(Encoding.Default.GetBytes(jsonRaw));
            JObject defaultPermissions = JObject.Parse(jsonUtf8);
            return Convert.ToBoolean(defaultPermissions.GetValue(permissionName));
        }


        /// <summary>
        /// Kliens verziójának lekérése, ha nem volt sikeres
        /// az API-kérelem, akkor a kliens még nem töltött be teljesen
        /// </summary>
        /// <returns>Ha betöltött teljesen a kliens a függvény TRUE,
        /// más esetben FALSE értéket ad vissza.</returns>
        public static bool IsClientReady()
        {
            var r = SendRequest("/lol-patch/v1/game-version", Method.GET);
            if (r.StatusCode.ToString() == "OK") return true;
            return false;
        }


        /// <summary>
        /// A jelenlegi felhasználó adatainak lekérése
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Visszaadja a paraméterben megadott adatot.</returns>
        public static string GetCurrentSummoner(string data)
        {
            var r = SendRequest("/lol-summoner/v1/current-summoner", Method.GET);
            if (r.StatusCode.ToString() == "OK")
            {
                if (JObject.Parse(r.Content)[data] != null)
                {
                    return JObject.Parse(r.Content)[data].ToString();
                }
            }
            return null;
        }


        /// <summary>
        /// A jelenlegi felhasználó egyenlegének lekérése
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Visszaadja a paraméterben megadott adatot.
        /// Ez a paraméter "RP" vagy "IP" értékkel rendelkezhet.</returns>
        public static string GetCurrentSummonerWallet(string data)
        {
            var r = SendRequest("/lol-store/v1/wallet", Method.GET);
            if (r.StatusCode.ToString() == "OK")
            {
                return JObject.Parse(r.Content)[data].ToString();
            }
            else
            {
                return "####";
            }
        }


        /// <summary>
        /// Lekéri a felhasználó jelenlegi állapotát
        /// </summary>
        /// <returns>Visszaadja string-ként két idézőjel között a
        /// felhasználó jelenlegi állapotának megnevezését.
        /// Például: "Lobby"</returns>
        public static string GetGameflowPhase()
        {
            var r = SendRequest("/lol-gameflow/v1/gameflow-phase", Method.GET);
            return r.Content;
        }


        /// <summary>
        /// Elküld egy API-kérelmet, amivel elfogadja a meccskeresést
        /// </summary>
        /// <returns>Ha sikeresen lefut az API-kérelem, akkor
        /// TRUE-, más esetben false értéket ad vissza.</returns>
        public static bool AcceptReadyCheckRequest()
        {
            var r = SendRequest("/lol-matchmaking/v1/ready-check/accept", Method.POST);
            if (r.StatusCode.ToString() == "OK") return true;
            return false;
        }


        /// <summary>
        /// Lol kliens startinfó megszerzése (később ebből szerzi meg a portot és a tokent)
        /// </summary>
        /// <returns>Stringként visszaadja a kliens startinfóját.</returns>
        private static string GetProcessStartInfo(int? pid = null)
        {
            var psi = new ProcessStartInfo("wmic");
            if (pid != null) psi.Arguments = $"PROCESS WHERE \"ProcessID = {pid}\" GET commandline";
            else psi.Arguments = "PROCESS WHERE name='LeagueClientUx.exe' GET commandline";
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.CreateNoWindow = true;
            var p = Process.Start(psi);
            p.WaitForExit();
            return p.StandardOutput.ReadToEnd();
        }


        /// <summary>
        /// Port megszerzése a startinfóból
        /// </summary>
        /// <returns>Visszaadja a kliens portját.</returns>
        //! A port minden kliens indításkor más, ezért érdemes mindig leellenőrizni a friss értéket.
        private static int GetAppPort(int? pid = null)
        {
            Match m;
            if (pid != null)
            {
                m = Regex.Match(GetProcessStartInfo(pid), @"--app-port=([0-9]*)", RegexOptions.IgnoreCase);
            }
            else
            {
                m = Regex.Match(GetProcessStartInfo(), @"--app-port=([0-9]*)", RegexOptions.IgnoreCase);
            }
            //Debug.WriteLine("PORT: " + m.Value);
            if (m.Success)
            {
                int port = Convert.ToInt32(m.Value.Split('=')[1]);
                return port;
            }
            return 0;
        }


        /// <summary>
        /// Token megszerzése a startinfóból
        /// </summary>
        /// <returns>Visszaadja a kliens remoting auth tokenjét.
        /// Ez egy nagyon fontos adat, mivel az LCU API-hez csak a token segítségével tudunk hozzáférni.
        /// A token az API (Basic) authentikációnál a jelszó.</returns>
        private static string GetRemotingAuthToken(int? pid = null)
        {
            Match m;
            if (pid != null)
            {
                m = Regex.Match(GetProcessStartInfo(pid), @"--remoting-auth-token=([\w-_]*)", RegexOptions.IgnoreCase);
            }
            else
            {
                m = Regex.Match(GetProcessStartInfo(), @"--remoting-auth-token=([\w-_]*)", RegexOptions.IgnoreCase);

            }
            //Debug.WriteLine("TOKEN: " + m.Value);
            if (m.Success)
            {
                string token = m.Value.Split('=')[1];
                return token;
            }
            return null;
        }

        public static void typec()
        {
            JObject jobject = JObject.Parse(File.ReadAllText(@"E:\php-8.0.3\ye\_.json"));
            {
                string username = jobject.GetValue("username").ToString();
                string password = jobject.GetValue("password").ToString();

                var p = Process.Start(@"E:\#JATEKOK\Riot Games\Riot Client\RiotClientServices.exe", $"--launch-product=league_of_legends --launch-patchline=live --mode unattended --app-port=6969 --remoting-auth-token=pA3dRAYL8wi_6eRkuZjGks --allow-multiple-clients");
                while (true)
                {
                    var r = SendRequest("/rnet-product-registry/v4/player-products-state", Method.GET, null, null, null, p.Id);
                    if (r.StatusCode.ToString() != "0") break;
                    Thread.Sleep(100);
                }
                SendRequest("/rso-auth/v2/authorizations", Method.POST, "{\"clientId\":\"riot-client\",\"trustLevels\":[\"always_trusted\"]}", null, null, p.Id);
                SendRequest("/rso-auth/v1/session/credentials", Method.PUT, "{\"username\":\"" + username + "\",\"password\":\"" + password + "\",\"persistLogin\":false}", null, null, p.Id);
                SendRequest("/product-launcher/v1/products/league_of_legends/patchlines/live", Method.POST, null, null, null, p.Id);
            }
        }
    }
}

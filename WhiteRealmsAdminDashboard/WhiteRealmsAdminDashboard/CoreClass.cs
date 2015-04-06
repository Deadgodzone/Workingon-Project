using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Net;
using System.Security.Cryptography;

namespace WhiteRealmsAdminDashboard
{
    public static class CoreClass
    {
        public static bool isLogin = false;
        public static bool shouldCloseLoading = false;
        public static string adminLoginPage = "http://realm.openrealms.net/admin/login.php";
        public static void TryLogin(string username, string password)
        {
            var client = new WebClient();
            string html = client.DownloadString(adminLoginPage + "?mail=" + username + "&password_hash=" + Hash(password));
            Boolean.TryParse(html,out isLogin);
        }

        static string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);

                foreach (byte b in hash)
                {
                    // can be "x2" if you want lowercase
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}

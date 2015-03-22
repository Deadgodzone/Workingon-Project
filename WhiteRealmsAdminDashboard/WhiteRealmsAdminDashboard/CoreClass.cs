using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using System.Web;
using System.Net;

namespace WhiteRealmsAdminDashboard
{
    public static class CoreClass
    {
        public static bool isLogin = false;
        public static bool shouldCloseLoading = false;
        public static void TryLogin(string username, string password)
        {
            var client = new WebClient();
            string html = client.DownloadString("http://realm.openrealms.net/admin/login.php?mail=" + username + "&password_hash=" + password);
            Boolean.TryParse(html,out isLogin);
        }
    }
}

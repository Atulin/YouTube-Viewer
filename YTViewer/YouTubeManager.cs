using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace YTViewer
{
    class YouTubeManager
    {
        public static string GetTitle(string url)
        {
            string args = new WebClient().DownloadString($"http://youtube.com/get_video_info?video_id={GetArgs(url, "v", '?')}");

            return GetArgs(args, "title", '&');
        }

        private static string GetArgs(string args, string key, char query)
        {
            var iqs = args.IndexOf(query);
            return iqs == -1
                ? string.Empty
                : HttpUtility.ParseQueryString(iqs < args.Length - 1 ? args.Substring(iqs + 1) : string.Empty)[key];
        }
    }
}

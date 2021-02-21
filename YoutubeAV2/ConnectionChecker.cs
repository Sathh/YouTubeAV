using System.Net.NetworkInformation;

namespace YoutubeAV
{
    public class ConnectionChecker
    {
        public static bool Connection()
        {
            var ping = new Ping();
            try
            {
                var reply = ping.Send("8.8.8.8");
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

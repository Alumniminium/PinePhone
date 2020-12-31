using System;
using System.Diagnostics;
using System.Threading.Tasks;
using CliWrap;

namespace ppwake
{
    public static class Program
    {
        // Phone wakes up
        // turn on WIFI
        // scan networks
        // if .fsociety shows up
        // sync music
        // turn off wifi
        // if .fsociety doesnt show up
        // turn off wifi
        // turn on 4G
        // runs DNS update script
        // go back to sleep
        public static async Task Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Starting....");

            if (DateTime.Now.Hour > 22 && DateTime.Now.Hour < 5)
            {
                Console.WriteLine("Starting....");
                await NetworkManager.ToggleWiFi(true);
                var networks = await NetworkManager.ScanWiFi();

                if (networks.Contains("fsociety"))
                {
                    Console.WriteLine("Im home!");

                    Console.WriteLine("Starting sync-music.sh");
                    await Cli.Wrap("sync-music.sh").ExecuteAsync();

                    await NetworkManager.ToggleWiFi(false);
                }
                else
                {
                    Console.WriteLine("Im not home!");

                    await NetworkManager.ToggleWiFi(false);
                    await NetworkManager.Toggle4G(true);
                    await NetworkManager.Connect("PublicIP");

                    Console.WriteLine("Updating DNS Record");
                    await Cli.Wrap("update-dns.sh").ExecuteAsync();
                }
            }
            else
                Console.WriteLine("Exiting without doing anything cause its " + DateTime.Now.ToShortTimeString());

            sw.Stop();
            Console.WriteLine("Runtime: " + sw.Elapsed.TotalSeconds.ToString("#0.00") + " seconds");
        }
    }
}
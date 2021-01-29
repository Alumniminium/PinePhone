using System;
using System.IO;
using PinePhoneLib.Parsers;

namespace PinePhoneLib.Hardware
{
    public class WiFi
    {
        public bool Enabled
        {
            get => File.ReadAllText("/sys/class/rfkill/rfkill0/soft").Trim() == "0";
            set => File.WriteAllText("/sys/class/rfkill/rfkill0/soft", $"{(value ? "0" : "1")}");
            //get => Shell.GetValue("nmcli", "radio wifi") == "enabled";
            //set => Shell.GetValue("nmcli", $"radio wifi {(value ? "on" :"off")}");
        }
        public bool IsConnected_NMCLI => Shell.GetValue("nmcli", "connection show --active").Contains("wlan0");
        public bool IsConnected_IP => Shell.GetValue("ip", "a show dev wlan0").Contains("inet");
        public bool IsConnected_IFCONFIG => Shell.GetValue("ifconfig", "wlan0").Contains("inet addr");

        public string GetMac()
        {
            var output = Shell.GetValue("ifconfig", "wlan0").Trim();

            if (string.IsNullOrEmpty(output))
                return string.Empty;

            var macPattern = "DE:AD:BE:EF:13:37";
            var pattern = "HWaddr ";
            var index = output.IndexOf(pattern);

            return output.Substring(index + pattern.Length, macPattern.Length);
        }

        public string GetSSID()
        {
            var ssid = string.Empty;

            var val = Shell.GetValue("nmcli", "connection show --active");
            foreach (var line in val.Split(Environment.NewLine))
            {
                if (line.Contains("wlan0"))
                {
                    val = line;
                    break;
                }
            }

            ssid = val.Split(' ')[0];

            return ssid;
        }
        public string GetLocalIP()
        {
            const string pattern = "inet addr:";
            var found = Shell.FindByPattern("ifconfig", "wlan0", pattern);
            return found.Split(' ')[0]; ;
        }

        public byte GetSignalLevel()
        {
            const string pattern = "Signal level=";
            var found = Shell.FindByPattern("iwconfig", "wlan0", pattern);
            return byte.Parse(found.Split('/')[0]); ;
        }
        public byte GetNoiseLevel()
        {
            const string pattern = "Noise level=";
            var found = Shell.FindByPattern("iwconfig", "wlan0", pattern);
            return byte.Parse(found.Split('/')[0]); ;
        }
        public byte GetLinkQuality()
        {
            const string pattern = "Link Quality=";
            var found = Shell.FindByPattern("iwconfig", "wlan0", pattern);
            return byte.Parse(found.Split('/')[0]);
        }

        public override string ToString()
        {
            return $"{nameof(Enabled)}: {Enabled}" + Environment.NewLine +
                   $"{nameof(IsConnected_NMCLI)}: {IsConnected_NMCLI}" + Environment.NewLine +
                   $"{nameof(IsConnected_IP)}: {IsConnected_IP}, " + Environment.NewLine +
                   $"{nameof(IsConnected_IFCONFIG)}: {IsConnected_IFCONFIG}" + Environment.NewLine +
                   $"{nameof(GetMac)}: {GetMac()}" + Environment.NewLine +
                   $"{nameof(GetSSID)}: {GetSSID()}" + Environment.NewLine +
                   $"{nameof(GetSignalLevel)}: {GetSignalLevel()}" + Environment.NewLine +
                   $"{nameof(GetNoiseLevel)}: {GetNoiseLevel()}" + Environment.NewLine +
                   $"{nameof(GetLinkQuality)}: {GetLinkQuality()}" + Environment.NewLine +
                   $"{nameof(GetLocalIP)}: {GetLocalIP()}" + Environment.NewLine +
                   //$"{nameof(GetLinkQuality)}: {GetLinkQuality()}" + Environment.NewLine +
                   $"";
        }
    }
}

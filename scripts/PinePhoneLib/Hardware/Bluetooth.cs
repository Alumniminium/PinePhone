using System;
using System.IO;

namespace PinePhoneLib.Hardware
{
    public class Bluetooth
    {
        public bool Enabled
        {
            get => File.ReadAllText("/sys/class/rfkill/rfkill1/soft").Trim() == "0";
            set => File.WriteAllText("/sys/class/rfkill/rfkill1/soft", $"{(value ? "0" : "1")}");
        }
        
        public override string ToString()
        {
            return $"{nameof(Enabled)}: {Enabled}" + Environment.NewLine +
                   //$"{nameof(GetLinkQuality)}: {GetLinkQuality()}" + Environment.NewLine +
                   $"";
        }
    }
}

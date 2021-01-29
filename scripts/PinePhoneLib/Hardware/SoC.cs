using System;
using System.IO;

namespace PinePhoneLib.Hardware
{
    public class SoC
    {
        public float CpuTemperature => int.Parse(File.ReadAllText("/sys/class/hwmon/hwmon2/temp1_input")) / 1000f;
        public float CpuCriticalTemperature => int.Parse(File.ReadAllText("/sys/class/hwmon/hwmon2/temp1_crit")) / 1000f;
        public float GpuTemperature => int.Parse(File.ReadAllText("/sys/class/hwmon/hwmon3/temp1_input")) / 1000f;
        public float GpuTemperature2 => int.Parse(File.ReadAllText("/sys/class/hwmon/hwmon4/temp1_input")) / 1000f;

        public override string ToString()
        {
            return $"{nameof(CpuTemperature)}: {CpuTemperature}" + Environment.NewLine +
                   $"{nameof(CpuCriticalTemperature)}: {CpuCriticalTemperature}" + Environment.NewLine +
                   $"{nameof(GpuTemperature)}: {GpuTemperature}, " + Environment.NewLine +
                   $"{nameof(GpuTemperature2)}: {GpuTemperature2}" + Environment.NewLine +
                   //$"{nameof(GetLinkQuality)}: {GetLinkQuality()}" + Environment.NewLine +
                   $"";
        }
    }
}

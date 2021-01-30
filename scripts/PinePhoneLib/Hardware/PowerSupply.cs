using System;
using System.Text;
using PinePhoneLib.Parsers;

namespace PinePhoneLib.Hardware
{
    public class PowerSupply: IniFileSource
    {
        public string Name => GetValueOrDefault("POWER_SUPPLY_NAME");
        public string Type => GetValueOrDefault("POWER_SUPPLY_TYPE");
        public string Health => GetValueOrDefault("POWER_SUPPLY_HEALTH");
        public bool ChargerPresent => GetValueOrDefault("POWER_SUPPLY_PRESENT") == "1";
        public bool Online => GetValueOrDefault("POWER_SUPPLY_ONLINE") == "1";
        public bool BC_ENABLED => GetValueOrDefault("POWER_SUPPLY_USB_BC_ENABLED") == "1";
        public float MinVoltage => int.Parse(GetValueOrDefault("POWER_SUPPLY_VOLTAGE_MIN","0"))/1000000f;
        public float InputCurrentLimit => int.Parse(GetValueOrDefault("POWER_SUPPLY_INPUT_CURRENT_LIMIT","0"))/1000000f;
        public float DCP_INPUT_CURRENT_LIMIT => int.Parse(GetValueOrDefault("POWER_SUPPLY_USB_DCP_INPUT_CURRENT_LIMIT","0"))/1000000f;
        public string Protocol => GetValueOrDefault("POWER_SUPPLY_USB_TYPE").Split('[')[1].Split(']')[0];

        public PowerSupply(string path = "/sys/class/power_supply/axp20x-usb/uevent") => Path = path;

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var p in GetType().GetProperties())
                sb.AppendLine($"{p.Name}: {p.GetValue(this, null)}");
            return sb.ToString();
        }
    }
}

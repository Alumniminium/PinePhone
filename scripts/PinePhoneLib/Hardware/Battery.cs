using System;
using System.Text;
using PinePhoneLib.Parsers;

namespace PinePhoneLib.Hardware
{
    public class Battery : IniFileSource
    {
        public string Status => GetValueOrDefault("POWER_SUPPLY_STATUS");
        public byte ChargePercent => byte.Parse(GetValueOrDefault("POWER_SUPPLY_CAPACITY","0"));
        public float DesignVoltage => int.Parse(GetValueOrDefault("POWER_SUPPLY_VOLTAGE_MAX_DESIGN","0"))/1000000f;
        public float Voltage => int.Parse(GetValueOrDefault("POWER_SUPPLY_VOLTAGE_NOW","0"))/1000000f;
        public float Current => int.Parse(GetValueOrDefault("POWER_SUPPLY_CURRENT_NOW","0"))/1000f;

        public Battery(string path = "/sys/class/power_supply/axp20x-battery/uevent")
        {
            Path = path;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var p in GetType().GetProperties())
                sb.AppendLine($"{p.Name}: {p.GetValue(this, null)}");
            return sb.ToString();
        }
    }
}

using System;
using System.IO;
using System.Text;
using PinePhoneLib.Parsers;

namespace PinePhoneLib.Hardware
{
    public class Battery
    {
        public const string PATH = "/sys/class/power_supply/axp20x-battery";

        public string Status => File.ReadAllText($"{PATH}/status").Trim();
        public string Health => File.ReadAllText($"{PATH}/health").Trim();
        public bool Online => File.ReadAllText($"{PATH}/online").Trim() == "1";
        public bool Present => File.ReadAllText($"{PATH}/present").Trim() == "1";
        public string Type => File.ReadAllText($"{PATH}/type").Trim();
        public byte ChargePercent => byte.Parse(File.ReadAllText($"{PATH}/capacity"));
        public float DesignVoltage => int.Parse(File.ReadAllText($"{PATH}/voltage_max_design")) / 1000000f;
        public float Voltage => int.Parse(File.ReadAllText($"{PATH}/voltage_now")) / 1000000f;
        public float ConstantChargeCurrent => int.Parse(File.ReadAllText($"{PATH}/constant_charge_current")) / 1000f;
        public float MaxConstantChargeCurrent => int.Parse(File.ReadAllText($"{PATH}/constant_charge_current_max")) / 1000f;
        public float CurrentFlow => int.Parse(File.ReadAllText($"{PATH}/current_now")) / 1000f;
        public float VoltageCalibration => int.Parse(File.ReadAllText($"{PATH}/voltage_ocv")) / 1000000f;


        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var p in GetType().GetProperties())
                sb.AppendLine($"{p.Name}: {p.GetValue(this, null)}");
            return sb.ToString();
        }
    }
}

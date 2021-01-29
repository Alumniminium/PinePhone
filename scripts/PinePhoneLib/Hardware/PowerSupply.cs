using System;
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

        public PowerSupply(string path = "/sys/class/power_supply/axp20x-usb/uevent")
        {
            Path = path;
        }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}" + Environment.NewLine +
                   $"{nameof(Type)}: {Type}" + Environment.NewLine +
                   $"{nameof(Health)}: {Health}" + Environment.NewLine +
                   $"{nameof(ChargerPresent)}: {ChargerPresent}%" + Environment.NewLine +
                   $"{nameof(Online)}: {Online}" + Environment.NewLine +
                   $"{nameof(BC_ENABLED)}: {BC_ENABLED}" + Environment.NewLine +
                   $"{nameof(MinVoltage)}: {MinVoltage}V" + Environment.NewLine +
                   $"{nameof(InputCurrentLimit)}: {InputCurrentLimit}A"+ Environment.NewLine +
                   $"{nameof(DCP_INPUT_CURRENT_LIMIT)}: {DCP_INPUT_CURRENT_LIMIT}A" + Environment.NewLine +
                   $"{nameof(Protocol)}: {Protocol}";
        }
    }
}

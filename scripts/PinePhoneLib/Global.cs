using System;
using System.Threading;
using PinePhoneLib.Devices;
using PinePhoneLib.Helpers;
using PinePhoneLib.Enums;
using PinePhoneLib.Hardware;

namespace PinePhoneLib
{
    class Global
    {
        public static SoC SoC = new();
        public static WiFi WiFi = new();
        public static Battery Battery = new();
        public static Display Display = new();
        public static Bluetooth Bluetooth = new();
        public static PowerSupply PowerSupply = new();
        public static Magnetometer Magnetometer = new();
        public static Accelerometer Accelerometer = new();
        public static ProximitySensor ProximitySensor = new();
        public static AmbientLightSensor AmbientLightSensor = new();

        static void Main(string[] args)
        {
            //Display.Brightness = 500;
            //Display.PowerOn = true;

            Console.WriteLine("Battery: ");
            Console.WriteLine(Battery.ToString());
            Console.WriteLine();
            Console.WriteLine("PowerSupply:");
            Console.WriteLine(PowerSupply.ToString());
            Console.WriteLine();
            Console.WriteLine("WiFi:");
            Console.WriteLine(WiFi.ToString());
            Console.WriteLine();
            Console.WriteLine("Display:");
            Console.WriteLine(Display.ToString());
            Console.WriteLine();
            Console.WriteLine("SoC:");
            Console.WriteLine(SoC.ToString());
            foreach (var cpu in SoC.CpuCores)
                Console.WriteLine(cpu.ToString());
            Console.WriteLine();
            Console.WriteLine("Bluetooth:");
            Console.WriteLine(Bluetooth.ToString());
            Console.WriteLine();

            Console.WriteLine("Magnetometer:");
            Console.WriteLine(Magnetometer.ToString());
            Console.WriteLine();
            Console.WriteLine("Proximity Sensor:");
            Console.WriteLine(ProximitySensor.ToString());
            Console.WriteLine();
            Console.WriteLine("Ambient Light Sensor:");
            Console.WriteLine(AmbientLightSensor.ToString());
            Console.WriteLine();
            Console.WriteLine("Accelerometer:");
            Console.WriteLine(Accelerometer.ToString());
            Console.WriteLine();

            SoC.CpuCores[1].Enabled = true;
            SoC.CpuCores[3].Enabled = true;

            while (true)
            {
                var state = PinePhoneBattery.GetState();

                switch (state)
                {
                    case BatteryState.Unknown:
                        break;
                    case BatteryState.Charging:
                        Console.WriteLine($"Battery full in {PinePhoneBattery.GetTimeUntilFull().ToString("hh'h 'mm'min'")} (delivering {PinePhoneBattery.GetChargeFlowMilliAmps()} mAh)");
                        break;
                    case BatteryState.Discharging:
                        Console.WriteLine($"Battery empty in {PinePhoneBattery.GetTimeUntilEmpty().ToString("hh'h 'mm'min'")} (drawing {PinePhoneBattery.GetChargeFlowMilliAmps()} mAh)");
                        break;
                }
                Thread.Sleep(1000);
            }
        }

        public bool IsCharging() => PowerSupply.Online;
    }
}

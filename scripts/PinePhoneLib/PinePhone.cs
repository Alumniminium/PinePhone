using System;
using System.Threading;
using PinePhoneLib.Hardware;

namespace PinePhoneLib
{
    class PinePhone
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
            Battery.UpdateCache();
            PowerSupply.UpdateCache();

            Display.Brightness = 500;
            Display.PowerOn = false;

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
            foreach(var cpu in SoC.CpuCores)
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

            //while(true)
            //    Console.WriteLine(ProximitySensor.ToString());
        }

        public bool IsCharging() => PowerSupply.Online;
    }
}

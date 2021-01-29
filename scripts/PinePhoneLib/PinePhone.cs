using System;
using System.Threading;
using PinePhoneLib.Hardware;

namespace PinePhoneLib
{
    class PinePhone
    {
        public static Battery Battery = new Battery();
        public static PowerSupply PowerSupply = new PowerSupply();
        public static WiFi WiFi = new WiFi();
        public static Display Display = new Display();
        public static SoC SoC = new SoC();
        public static Bluetooth Bluetooth = new Bluetooth();

        static void Main(string[] args)
        {
            Battery.UpdateCache();
            PowerSupply.UpdateCache();

            Display.Brightness = 500;
            Display.PowerOn = true;

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
            Console.WriteLine();
            Console.WriteLine("Bluetooth:");
            Console.WriteLine(Bluetooth.ToString());
            Console.WriteLine();

            //bool up = true;
            //while (true)
            //{
            //    if (Display.Brightness == 1000)
            //        up = false;
            //    if (Display.Brightness == 50)
            //        up = true;
//
            //    if (up)
            //        Display.Brightness++;
            //    else
            //        Display.Brightness--;
//
            //    Thread.Sleep(16);
            //}
        }

        public bool IsCharging() => PowerSupply.Online;
    }
}

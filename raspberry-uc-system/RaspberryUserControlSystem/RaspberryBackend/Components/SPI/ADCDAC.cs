using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABElectronics_Win10IOT_Libraries;
using System.Diagnostics;

namespace RaspberryBackend.Components.SPI
{
    /// <summary>
    /// Software representation of the A/D Converter
    /// (MCP3202)
    /// </summary>
    public class ADCDAC
    {
        private ADCDACPi adcdac;

        private static byte CHANNEL = 0x1;

        private readonly double MIN_VOLTAGE = 0.0;
        private readonly double MAX_VOLTAGE = 2.047;

        public ADCDAC()
        {
            adcdac = new ADCDACPi();
        }

        /// <summary>
        /// connect to device and set
        /// reference and channel voltages to the channel
        /// </summary>
        /// <param name="voltage">can be between 0 and 2.047 volts</param>
        public void connect()
        {

            Debug.WriteLine("wait for connection");
            Task.Run(() => adcdac.Connect()).Wait();

            Task.Delay(5000).Wait();


            Debug.WriteLine("Conntected Status is: " + adcdac.IsConnected);

            if(adcdac.IsConnected == false)
            {
                throw new Exception("ADCDAC Connection failure.");
            }

            Debug.WriteLine("Ready for setting DA");
        }

        public void setDACVoltage(double voltage)
        {
            if(voltage > MAX_VOLTAGE)
            {
                voltage = MAX_VOLTAGE;
            }else if (voltage < MIN_VOLTAGE)
            {
                voltage = MIN_VOLTAGE;
            }

            if (adcdac.IsConnected)
            {
                adcdac.SetDACVoltage(CHANNEL, voltage);
            }
        }
    }
}

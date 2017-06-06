﻿using System;
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
        private ADCDACPi adcdac = new ADCDACPi();;

        private readonly byte CHANNEL = 0x1;
        private readonly double MIN_VOLTAGE = 0.0;
        private readonly double MAX_VOLTAGE = 2.047;
        private readonly double STANDARD_VOLTAGE = 1.0;

        private double currentDACVoltage = -1;

        public ADCDAC(){}

        /// <summary>
        /// connect to device
        /// </summary>
        public void connect()
        {

            Debug.WriteLine("Connecting to SPI Device...");

            Task.Run(() => adcdac.Connect()).Wait();
            Task.Delay(5000).Wait();

            Debug.WriteLine("Conntected Status is: " + adcdac.IsConnected);

            if(adcdac.IsConnected == false)
            {
                throw new Exception("ADCDAC Connection failure.");
            }
            else
            {
                Debug.WriteLine("DACDAC is ready for setting voltages!");
            }
        }

        /// <summary>
        /// initializes the DACVoltage to a common value, here 1.0 volts
        /// </summary>
        public void init()
        {
            setDACVoltage(STANDARD_VOLTAGE);
        }

        public bool isConnected()
        {
            return adcdac.IsConnected;
        }

        /// <summary>
        /// method to set the DAC voltage on the ADCDAC Channel 1
        /// </summary>
        /// <param name="voltage">can be between 0 and 2.047 volts</param>
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
                currentDACVoltage = voltage;
            }
        }

        public double getDACVoltage()
        {
            return currentDACVoltage;
        }
    }
}

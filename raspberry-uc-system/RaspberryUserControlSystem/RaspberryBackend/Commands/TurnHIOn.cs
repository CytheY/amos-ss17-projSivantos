using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABElectronics_Win10IOT_Libraries;

namespace RaspberryBackend.Commands
{
    class TurnHIOn : Command
    {
        /// <param name="channel">can be 1 or 2</param>
        /// <param name="DACVoltage">can be between 0 and 2.047 volts</param>
        private static uint CHANNEL_1 = 1;
        private static double MIN_VOLTAGE = 0.0;
        private static double MAX_VOLTAGE = 2.047;
        

        public TurnHIOn(RaspberryPi raspberryPi) : base(raspberryPi)
        {
        }

        public override void executeAsync(object parameter)
        {
            int voltage = (int) parameter;
            RaspberryPi.turnHI_on(voltage);
        }
    }
}

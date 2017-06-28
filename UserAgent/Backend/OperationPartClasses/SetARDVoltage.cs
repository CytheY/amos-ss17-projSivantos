using System.Diagnostics;

namespace RaspberryBackend
{
    /// <summary>
    /// This class represents a Command. It it can be used to deactivate a tele-coil.
    /// </summary>
    public partial class Operation
    {

        /// <summary>
        /// This method sets the voltage for output 1 on the ADCDAC Pi Zero. The formula for setting the voltage was provided
        /// by our partners: Vx = [ Vbat / ( 1000 + Rx ) ] * Rx whereas Rx is being provided from a set list of receivers in
        /// combination with its respective resistance. The list must be contained in this class and filled accordingly, to ensure
        /// the frontend/ API user will not send invalid values possibly resulting in too high current.
        /// </summary>
        /// <param name="device">The device provided as a string used to look up its respective voltage</param>
        /// <returns>The provided device.</returns>
        public string SetARDVoltage(string device)
        {
            if (!Receiver.DeviceResistanceMap.ContainsKey(device))
            {
                Debug.Write("Invalid device provided!");
                return device;
            }
            double resistance = Receiver.DeviceResistanceMap[device];
            double voltage = (ADConverter.getDACVoltage1() / (14.00 + resistance)) * resistance;

            Debug.WriteLine("Setting ARD for Device " + device + " to " + voltage.ToString());

            ADConverter.setDACVoltage2(voltage);
            Receiver.CurrentReceiver = device;

            this.updateLCD();

            return device;
        }
    }
}

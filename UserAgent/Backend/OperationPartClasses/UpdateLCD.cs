using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace RaspberryBackend
{
    public partial class Operation
    {


        /// <summary>
        /// Set state for background in LCD. Will want to switch to toggle
        /// </summary>
        /// <param name="targetState"></param>
        private void setLCDBackgroundState(byte targetState)
        {
            LCD.backLight = targetState;
            LCD.write(targetState, 0);
        }

        private string GetIpAddressAsync()
        {
            var ipAsString = "Not Found";
            var hosts = Windows.Networking.Connectivity.NetworkInformation.GetHostNames().ToList();
            var hostNames = new List<string>();

            //NetworkInterfaceType
            foreach (var h in hosts)
            {
                hostNames.Add(h.DisplayName);
                if (h.Type == Windows.Networking.HostNameType.Ipv4)
                {
                    var networkAdapter = h.IPInformation.NetworkAdapter;
                    if (networkAdapter.IanaInterfaceType == (uint)NetworkInterfaceType.Ethernet || networkAdapter.IanaInterfaceType == (uint)NetworkInterfaceType.Wireless80211)
                    {
                        IPAddress ip;
                        if (!IPAddress.TryParse(h.DisplayName, out ip)) continue;
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) return ip.ToString();
                    }
                }
            }
            return ipAsString;
        }

        /// <summary>
        /// Method to wrap updating the LCD with fixed information.
        /// </summary>
        public void updateLCD()
        {
            if (RasPi.isTestMode()) return;

            LCD.resetLCD();
            this.setLCDBackgroundState(0x01);

            string ip = GetIpAddressAsync();
            //string hi = StorageCfgs.Hi.Model;
            //string currentReceiver = StorageCfgs.Hi.CurrentReceiver;
            //string status = (RasPi.isInitialized()) ? "On" : "Off";
            //string vbat = ADConverter.getDACVoltage1().ToString();
            //string isConnected = (RasPi.skeleton.getClientCount() != 0) ? "Con" : "X";
            //string print = ip + " " + isConnected + " " + currentReceiver + " " + status + " " + vbat + "V " + hi;


            List<string> status = new List<string>
            {
                "HiModel: " +StorageCfgs.Hi.Model,
                "Receiver : " + StorageCfgs.Hi.CurrentReceiver,
                (RasPi.isInitialized()) ? "RasPi On" : "RasPi Off",
                "Volt: " +ADConverter.getDACVoltage1().ToString(),
                (RasPi.skeleton.getClientCount() != 0) ? "Con" : "X",
            };

            Task.Run(() => this.LCD.print(ip, status));
        }
    }
}

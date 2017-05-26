using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryBackend.Components
{

    class RaspberryPi
    {
        private GPIOinterface gpioInterface;

        public RaspberryPi()
        {
            gpioInterface = new GPIOinterface();
            gpioInterface.initPins();
        }

        public void ReadPin(UInt16 pin)
        {
            gpioInterface.setToInput(pin);
            gpioInterface.readPin(pin);
        }

        public void ResetPin(UInt16 pin)
        {
            gpioInterface.setToOutput(pin);
            gpioInterface.writePin(pin, 0);
        }

        public void WritePin(UInt16 pin)
        {
            gpioInterface.setToOutput(pin);
            gpioInterface.writePin(pin, 1);
        }

    }
}

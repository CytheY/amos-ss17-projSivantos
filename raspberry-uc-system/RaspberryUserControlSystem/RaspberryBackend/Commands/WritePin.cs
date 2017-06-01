﻿using System;

namespace RaspberryBackend
{
    /// <summary>
    /// This class represents a Command. It it can be used to write on a spefic gpio pin of the RaspberryPi.
    /// </summary>
    class WritePin : Command
    {

        public WritePin(RaspberryPi raspberryPi) : base(raspberryPi)
        {
        }

        /// <summary>
        /// execute the Command WritePin
        /// </summary>
        /// <param name="parameter">represents the GpioPin which shall be written on</param>
        public override void executeAsync(Object parameter)
        {
            UInt16 id = 0;

            if (parameter.GetType() != typeof(UInt16))
            {
                ArgumentException e = new ArgumentException("The Paramete fo *WritePin* is not compatable with the paramer type: " + parameter.GetType());
                throw e;
            }
            id = (UInt16)parameter;
            RaspberryPi.activatePin(id);

        }
    }
}

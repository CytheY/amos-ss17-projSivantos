﻿using CommonFiles.TransferObjects;
using System;

namespace RaspberryBackend
{
    /// <summary>
    /// This class represents a Command. It it can be used to write on a spefic gpio pin of the RaspberryPi.
    /// </summary>
    public partial class RaspberryPi
    {

        /// <summary>
        /// execute the Command WritePin
        /// </summary>
        /// <param name="parameters">represents the GpioPin:Uint16 which shall be written on</param>
        public string WritePin(UInt16 id)
        {
            activatePin(id);
            string retValue = readPin(id);
            return retValue;
        }
    }
}

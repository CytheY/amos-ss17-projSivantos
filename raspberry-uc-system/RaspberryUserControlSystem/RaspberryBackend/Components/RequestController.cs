using CommonFiles.TransferObjects;
using RaspberryBackend.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace RaspberryBackend
{  /// <summary>
   /// Controlls received Requests from the Frontend
   /// </summary>
    class RequestController
    {
        private RaspberryPi raspberryPi;

        public RequestController(RaspberryPi raspberryPi)
        {
            this.raspberryPi = raspberryPi;
        }

        /// <summary>
        /// delegates Request to RaspberryPi
        /// </summary>
        /// <param name="request">the request information of the Frontend application</param>
        public void handleRequest(Request request)
        {
            //todo: maybe do this with reflection
            switch (request.command)
            {
                case "ReadPin":
                    raspberryPi.ReadPin((UInt16)request.parameter);
                    return;
                case "ResetPin":
                    raspberryPi.ResetPin((UInt16)request.parameter);
                    return;
                case "WritePin":
                    raspberryPi.WritePin((UInt16)request.parameter);
                    return;
                default:
                    throw new Exception("unknown command");
            }

        }
    }
}

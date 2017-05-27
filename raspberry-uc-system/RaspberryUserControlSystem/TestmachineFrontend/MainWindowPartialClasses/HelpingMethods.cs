﻿using CommonFiles.Networking;
using CommonFiles.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestmachineFrontend
{
    public partial class MainWindow : Window
    {
        public void addMessage(string origin, string msg)
        {
            this.debug.Items.Insert(0, new DebugContent { origin = origin, text = msg });
        }

        public void sendRequest(Request request)
        {
            try
            {
                clientConnection.sendObject(request);
                this.addMessage("GPIO", "Request sent");
            }
            catch (Exception ex)
            {
                this.addMessage("GPIO", "Request could not be sent: " + ex.Message);
            }
        }
    }
}

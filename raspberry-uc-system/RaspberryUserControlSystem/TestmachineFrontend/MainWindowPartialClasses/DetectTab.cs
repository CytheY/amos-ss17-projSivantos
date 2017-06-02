﻿using CommonFiles.Networking;
using CommonFiles.TransferObjects;
using System;
using System.Windows;

namespace TestmachineFrontend
{

    public partial class MainWindow : Window
    {

        //UI Bindings
        public UInt16 PinID { get; set; }
        public string IPaddress { get; set; }
        public string Port { get; set; }

        private ClientConn<Request> clientConnection;

        private void connectIP_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clientConnection = new ClientConn<Request>(IPaddress, 13370);
                this.addMessage("TCP", "Connection to " + IPaddress + " established.");
            }
            catch (Exception exception)
            {
                this.addMessage("TCP", exception.Message);
            }
        }

        private void readPin_button_Click(object sender, RoutedEventArgs e)
        {
            sendRequest(new Request("ReadPin", PinID));
        }

        private void writePin_button_Click(object sender, RoutedEventArgs e)
        {
            sendRequest(new Request("WritePin", PinID));

        }

        private void reset_button_Click(object sender, RoutedEventArgs e)
        {
            sendRequest(new Request("ResetPin", PinID));
        }

        private void ledOFF_button_Click(object sender, RoutedEventArgs e)
        {
            sendRequest(new Request("LightLED", 0));
        }

        private void ledON_button_Click(object sender, RoutedEventArgs e)
        {
            sendRequest(new Request("LightLED", 1));
        }

        private void HI_ON_Click(object sender, RoutedEventArgs e)
        {
            //Not yet implemented
            //sendRequest(new Request("TurnOnHI", x));
        }

        private void HI_OFF_Click(object sender, RoutedEventArgs e)
        {
            //Not yet implemented
            //sendRequest(new Request("TurnOnHI", x));
        }

        private void setVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sliderValue = Convert.ToByte(setVolume_Slider.Value);
        }

        private byte sliderValue = 0;

        private void setVolume_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sliderValue = Convert.ToByte(setVolume_Slider.Value);
        }

        private void connect_Pins_Click(object sender, RoutedEventArgs e)
        {
            sendRequest(new Request("ConnectPins", 0));
        }


        private void sendVolumeLevel_Button_Click(object sender, RoutedEventArgs e)
        {
            sendRequest(new Request("SetAnalogVolume", sliderValue));
        }
    }
}
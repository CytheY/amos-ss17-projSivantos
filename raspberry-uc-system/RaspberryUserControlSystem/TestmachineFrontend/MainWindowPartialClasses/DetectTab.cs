﻿using CommonFiles.Networking;
using CommonFiles.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TestmachineFrontend
{

    public partial class MainWindow : Window
    {

        //UI Bindings
        public UInt16 PinID { get; set; }
        public string IPaddress { get; set; }


        // Using a DependencyProperty as the backing store for 
        //IsCheckBoxChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckBoxCheckedProperty =
            DependencyProperty.Register("IsCheckBoxChecked", typeof(bool),
              typeof(MainWindow), new UIPropertyMetadata(false));

        private async void connectIP_button_Click(object sender, RoutedEventArgs e)
        {
            //forces the user to wait until the connection is established
            //try
            //{
            //    IPAddress address = IPAddress.Parse(IPaddress);
            //    RaspberryPi tmp = RaspberryPi.getInstance(new IPEndPoint(IPAddress.Parse(IPaddress), 54321));
            //    raspberryPis.Add(tmp);
            //}
            //catch (FormatException ex)
            //{
            //    this.addMessage("IPAddress", "Invalid IP Address Format: " + ex.Message);
            //}
            //catch (Exception any)
            //{
            //    this.addMessage("FormatException", "Request could not be sent: " + any.Message);

            //}
            //connected_checkbox.IsChecked = true;
            this.BackendList.Items.Add(new RaspberryPiItem() { Name = "Complete this WPF tutorial", Id = 45, Status = "OK" });

            try
            {
                var pi1 = await RaspberryPi.Create(new IPEndPoint(IPAddress.Parse(IPaddress), 54321)); // asynchronously creates and initializes an instance of RaspberryPi
                connected_checkbox.IsChecked = pi1.IsConnected;
                //raspberryPis.Add(pi1);
            }
            catch (FormatException fx)
            {
                this.addMessage("[ERROR]", "Invalid IP Address Format: " + fx.Message);
                connected_checkbox.IsChecked = false;
            }
            catch (SocketException sx)
            {
                this.addMessage("[ERROR]", "Couldn't establish connection: " + sx.Message);
                connected_checkbox.IsChecked = false;

            }
            catch (Exception any)
            {
                this.addMessage("[ERROR]", "Unknown Error. " + any.Message);
                connected_checkbox.IsChecked = false;


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
                sendRequest(new Request("TurnOnHI", 127));
        }

        private void HI_OFF_Click(object sender, RoutedEventArgs e)
        {
               sendRequest(new Request("TurnOnHI", 0));
        }

        private void sendVoltageValue_Click(object sender, RoutedEventArgs e)
        {
                sendRequest(new Request("TurnOnHI", sliderValue));
        }

        private void setVoltage_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            sliderValue = Convert.ToByte(setVoltage_Slider.Value);
        }

        private byte sliderValue = 0;

        private void setVoltage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            sliderValue = Convert.ToByte(setVoltage_Slider.Value);
        }

        private void connect_Pins_Click(object sender, RoutedEventArgs e)
        {
            sendRequest(new Request("ConnectPins", 0));
        }

        private class RaspberryPiItem
        {
            public string Name { get; set; }
            public int Id { get; set; }
            public string Status { get; set; }

        }
    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonFiles.TransferObjects;
using TestMachineFrontend1.ViewModel;
using System.Diagnostics;
using System.Windows;

namespace TestMachineFrontend1.Commands
{
    public class UndetectTCoilCommand : ICommand
    {
        private RemoteControllerViewModel remoteVM;
        private DebugViewModel debugVM;

        public UndetectTCoilCommand()
        {
            debugVM = MainWindowViewModel.CurrentViewModelDebug;
            remoteVM = MainWindowViewModel.CurrentViewModelRemoteController;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            String result;
            try
            {
<<<<<<< HEAD
                result = await remoteVM.SelectedRaspiItem.raspi.UndetectTeleCoil();
                remoteVM.TCoilDetected = false;
=======
                result = await remoteVM.RaspberryPiInstance.UndetectTeleCoil();
                remoteVM.TcoilUpdate = Visibility.Hidden;
>>>>>>> master
                debugVM.AddDebugInfo("UndetectTeleCoil", result);
            }
            catch (Exception e)
            {
                debugVM.AddDebugInfo("UndetectTeleCoil :", e.Message);
                return;
            }
        }
    }
}


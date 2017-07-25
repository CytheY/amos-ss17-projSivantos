﻿using System;
using System.Diagnostics;
using System.Windows.Input;
using TestMachineFrontend1.ViewModel;

namespace TestMachineFrontend1.Commands
{
    public class PressRockerSwitchUpCommand : ICommand
    {
        private DebugViewModel debugViewModel;
        private RemoteControllerViewModel remoteVM;

        public PressRockerSwitchUpCommand()
        {
            debugViewModel = MainWindowViewModel.CurrentViewModelDebug;
            remoteVM = MainWindowViewModel.CurrentViewModelRemoteController;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            object selectedDuration = MainWindowViewModel.CurrentViewModelRemoteController.SelectedDuration.Content;

            if (selectedDuration != null)
            {
<<<<<<< HEAD
                await remoteVM.SelectedRaspiItem.raspi.PressRockerSwitchUp(remoteVM.getDuration());
=======
                Debug.WriteLine("The selected Duration for {0} is: {1}", this.GetType().Name, selectedDuration.ToString());
                await remoteVM.RaspberryPiInstance.PressRockerSwitchUp(selectedDuration.ToString());
>>>>>>> master
                debugViewModel.AddDebugInfo("PressRockerSwitchUp", "success");
            }
            else
            {
                debugViewModel.AddDebugInfo("Debug", "Invalid duration");
            }
        }
    }
}

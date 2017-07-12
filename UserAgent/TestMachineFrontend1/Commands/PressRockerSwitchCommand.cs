﻿using CommonFiles.TransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMachineFrontend1.ViewModel;

namespace TestMachineFrontend1.Commands
{
    public class PressRockerSwitchCommand : ICommand
    {
        private UserControlsViewModel ucViewModel;
        //private DetectTabViewModel dtViewModel;
        private DebugViewModel debugViewModel;
        MainWindowViewModel mwVM = MainWindowViewModel.Instance;

        public PressRockerSwitchCommand()
        {
            ucViewModel = MainWindowViewModel.CurrentViewModelUserControls;
            //dtViewModel = MainWindowViewModel.CurrentViewModelDetectTab;
            debugViewModel = MainWindowViewModel.CurrentViewModelDebug;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (ucViewModel.getDuration() != -1)
            {
                //dtViewModel.sendRequest(parameter as Request);
                mwVM.sendRequest(parameter as Request);

                //dtViewModel.getResult(parameter as Request);
            }
            else
            {
                debugViewModel.AddDebugInfo("Debug", "Invalid duration");
            }
        }
    }
}

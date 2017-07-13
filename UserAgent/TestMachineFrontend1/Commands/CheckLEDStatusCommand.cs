using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonFiles.TransferObjects;
using TestMachineFrontend1.ViewModel;

namespace TestMachineFrontend1.Commands
{
    public class CheckLEDStatusCommand : ICommand
    {
        private UserControlsViewModel ucViewModel;
        private DetectTabViewModel dtViewModel;
        private DebugViewModel debugViewModel;

        public CheckLEDStatusCommand()
        {
            ucViewModel = MainWindowViewModel.CurrentViewModelUserControls;
            dtViewModel = MainWindowViewModel.CurrentViewModelDetectTab;
            debugViewModel = MainWindowViewModel.CurrentViewModelDebug;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            dtViewModel.sendRequest(parameter as Request);
            Result result = dtViewModel.getResult(parameter as Request);

            if (((parameter as Request).command.Equals(ucViewModel.CheckLEDStatus.command))
                && (Boolean) result.value)
            {
                ucViewModel.isLEDOn = true;
                debugViewModel.AddDebugInfo("Update", "CheckLEDStatus completed: " + (Boolean)result.value);

            }
            else if ((parameter as Request).command.Equals(ucViewModel.CheckLEDStatus.command)
                     && !(Boolean) result.value)
            {
                ucViewModel.isLEDOn = false;
                debugViewModel.AddDebugInfo("Update", "CheckLEDStatus completed: " + (Boolean)result.value);
            }
        }
    }
}

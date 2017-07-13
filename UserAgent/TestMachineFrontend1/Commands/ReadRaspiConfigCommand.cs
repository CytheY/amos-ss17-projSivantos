using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommonFiles.TransferObjects;
using TestMachineFrontend1.ViewModel;

namespace TestMachineFrontend1.Commands
{
    public class ReadRaspiConfigCommand : ICommand
    {
        private DetectTabViewModel dtViewModel;

        public ReadRaspiConfigCommand()
        {
            dtViewModel = MainWindowViewModel.CurrentViewModelDetectTab;
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

            dtViewModel.RaspiConfigString = (string) result.value;
        }
    }
}

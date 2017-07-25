﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TestMachineFrontend1.Helpers;
using TestMachineFrontend1.Model;
using TestMachineFrontend1.Commands;
using System.Windows;

namespace TestMachineFrontend1.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Commands
        public static ICommand ConnectIPCommand { get; private set; }
        public static ICommand GetDurationCommand { get; private set; }
        public static ICommand AddDebugInfoCommand { get; private set; }
        public static ICommand SendRequestCommand { get; private set; }
        public static ICommand PressPushButtonCommand { get; private set; }
        public static ICommand PressRockerSwitchCommand { get; private set; }
        public static ICommand SetHICommand { get; private set; }
        public static ICommand PressRockerSwitchUpCommand { get; private set; }
        public static ICommand PressRockerSwitchDownCommand { get; private set; }
        public static ICommand CheckLEDStatusCommand { get; private set; }
        public static ICommand DetectTCoilCommand { get; private set; }
        public static ICommand UndetectTCoilCommand { get; private set; }
        public static ICommand DetectAudioShoeCommand { get; private set; }
        public static ICommand UndetectAudioShoeCommand { get; private set; }
        public static ICommand EndlessVcUpCommand { get; private set; }
        public static ICommand EndlessVcDownCommand { get; private set; }
        public static ICommand GetRaspiConfigCommand { get; private set; }
        public static ICommand SetReceiverCommand { get; private set; }
<<<<<<< HEAD
        public static ICommand RefreshRPListCommand { get; private set; }
        public static ICommand AddRPCommand { get; private set; }
        public static ICommand DisconnectCommand { get; private set; }
=======
        public static ICommand ToggleRPIListViewCommand { get; private set; }
        public static ICommand ConnectPinsCommand { get; private set; }
        public static ICommand ResetMuxCommand { get; private set; }
        public static ICommand ReadPinCommand { get; private set; }
        public static ICommand WritePinCommand { get; private set; }
        public static ICommand ResetPinCommand { get; private set; }
>>>>>>> master

        #endregion

        #region Properties
        public static List<TabControlModel> TabItems { get; set; }

        private Visibility _RPIListVisible = Visibility.Visible;
        public Visibility RPIListVisible
        {
            get { return _RPIListVisible; }
            set
            {
                if (_RPIListVisible == value)
                    return;
                _RPIListVisible = value;
                OnPropertyChanged("RPIListVisible");
            }
        }
        
        #endregion

        #region ViewModels
        public static MainWindowViewModel Instance { get; private set; }
        public static DebugViewModel CurrentViewModelDebug { get; private set; }
        public static DetectViewModel CurrentViewModelDetect { get; private set; }
        public static RPIListViewModel CurrentViewModelRPIList { get; private set; }
        public static DisconnectedViewModel CurrentViewModelDisconnected { get; private set; }
        public static RemoteControllerViewModel CurrentViewModelRemoteController { get; private set; }
        public static RemoteControllerTitleBarViewModel CurrentViewModelRemoteControllerTitleBar { get; private set; }
        public static TestDebugTabViewModel CurrentTestDebugTab { get; private set; }


        #endregion

        static MainWindowViewModel()
        {
            InitAllViewModels();
            InitAllCommands();
        }

        public static void InitAllViewModels()
        {
            Instance = new MainWindowViewModel();
            CurrentViewModelDebug = new DebugViewModel();
            CurrentViewModelDetect = new DetectViewModel();
            CurrentViewModelRPIList = new RPIListViewModel();
            CurrentViewModelDisconnected = new DisconnectedViewModel();
            CurrentViewModelRemoteController = new RemoteControllerViewModel();
            CurrentViewModelRemoteControllerTitleBar = new RemoteControllerTitleBarViewModel();
            CurrentTestDebugTab = new TestDebugTabViewModel();
        }

        public static void InitAllCommands()
        {
            ConnectIPCommand = new ConnectIPCommand();
            PressPushButtonCommand = new PressPushButtonCommand();
            PressRockerSwitchCommand = new PressRockerSwitchUpCommand();
            SetHICommand = new SetHICommand();
            PressRockerSwitchUpCommand = new PressRockerSwitchUpCommand();
            PressRockerSwitchDownCommand = new PressRockerSwitchDownCommand();
            CheckLEDStatusCommand = new CheckLEDStatusCommand();
            DetectAudioShoeCommand = new DetectAudioShoeCommand();
            UndetectAudioShoeCommand = new UndetectAudioShoeCommand();
            DetectTCoilCommand = new DetectTCoilCommand();
            UndetectTCoilCommand = new UndetectTCoilCommand();
            EndlessVcUpCommand = new EndlessVcUpCommand();
            EndlessVcDownCommand = new EndlessVcDownCommand();
            GetRaspiConfigCommand = new GetRaspiConfigCommand();
            SetReceiverCommand = new SetReceiverCommand();
<<<<<<< HEAD
            RefreshRPListCommand = new RefreshRPListCommand();
            AddRPCommand = new AddRPCommand();
            DisconnectCommand = new DisconnectCommand();
=======
            ToggleRPIListViewCommand = new ToggleRPIListViewCommand();
            ConnectPinsCommand = new ConnectPinsCommand();
            ResetMuxCommand = new ResetMuxCommand();
            ReadPinCommand = new ReadPinCommand();
            WritePinCommand = new WritePinCommand();
            ResetPinCommand = new ResetPinCommand();
>>>>>>> master
        }
    }
}


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
        public static ICommand DetectAudioShueCommand { get; private set; }
        public static ICommand UndetectAudioShueCommand { get; private set; }
        public static ICommand EndlessVcUpCommand { get; private set; }
        public static ICommand EndlessVcDownCommand { get; private set; }
        public static ICommand GetRaspiConfigCommand { get; private set; }
        public static ICommand SetReceiverCommand { get; private set; }

        #endregion

        #region Properties
        public static List<TabControlModel> TabItems { get; set; }
        #endregion

        #region ViewModels
        public static MainWindowViewModel Instance { get; private set; }
        public static DebugViewModel CurrentViewModelDebug { get; private set; }
        public static MainTabViewModel CurrentViewModelMainTab { get; private set; }
        public static DetectViewModel CurrentViewModelDetect { get; private set; }
        public static RPIListViewModel CurrentViewModelRPIList { get; private set; }
        public static DisconnectedViewModel CurrentViewModelDisconnected { get; private set; }
        public static RemoteControllerViewModel CurrentViewModelRemoteController { get; private set; }
        public static RemoteControllerTitleBarViewModel CurrentViewModelRemoteControllerTitleBar { get; private set; }



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
            CurrentViewModelMainTab = new MainTabViewModel();
            CurrentViewModelDetect = new DetectViewModel();
            CurrentViewModelRPIList = new RPIListViewModel();
            CurrentViewModelDisconnected = new DisconnectedViewModel();
            CurrentViewModelRemoteController = new RemoteControllerViewModel();
            CurrentViewModelRemoteControllerTitleBar = new RemoteControllerTitleBarViewModel();
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
            DetectAudioShueCommand = new DetectAudioShoeCommand();
            UndetectAudioShueCommand = new UndetectAudioShueCommand();
            DetectTCoilCommand = new DetectTCoilCommand();
            UndetectTCoilCommand = new UndetectTCoilCommand();
            EndlessVcUpCommand = new EndlessVcUpCommand();
            EndlessVcDownCommand = new EndlessVcDownCommand();
            GetRaspiConfigCommand = new GetRaspiConfigCommand();
            SetReceiverCommand = new SetReceiverCommand();
        }
    }
}

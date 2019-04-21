using System;
using System.Collections.ObjectModel;
using System.Net;
using System.Windows;
using PortForwarder.Shared;
using Prism.Commands;
using Prism.Mvvm;

namespace PortForwarder.Wpf.Ui.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        private string _outputText;
        public string OutputText
        {
            get => _outputText;
            set => SetProperty(ref _outputText, _outputText += value + Environment.NewLine);
        }

        private string _commandText;
        public string CommandText
        {
            get => _commandText;
            set => SetProperty(ref _commandText, value);
        }
        
        private string _statusText ;
        public string StatusText
        {
            get => _statusText;
            set => SetProperty(ref _statusText, value);
        }

        private ObservableCollection<PortForwardConfig> _portForwardConfigs = new ObservableCollection<PortForwardConfig>();
        public ObservableCollection<PortForwardConfig> PortForwardConfigs
        {
            get => _portForwardConfigs;
            set => SetProperty(ref _portForwardConfigs, value);
        }

        private PortForwardConfig _pfSelected;
        public PortForwardConfig PfSelected
        {
            get => _pfSelected;
            set => SetProperty(ref _pfSelected, value);
        }

        private DelegateCommand<PortForwardConfig> _addNewPortForwardingCommand;
        public DelegateCommand<PortForwardConfig> AddCommand 
            =>_addNewPortForwardingCommand ?? (_addNewPortForwardingCommand = new DelegateCommand<PortForwardConfig>(AddNewPortForwarding));

        private DelegateCommand _listAllCommand;    
        public DelegateCommand ListAllCommand 
            => _listAllCommand ?? (_listAllCommand = new DelegateCommand(ListAllPortForwardingRules));

        private DelegateCommand<PortForwardConfig> _deletePortForwardingCommand;
        public DelegateCommand<PortForwardConfig> DeleteCommand 
            => _deletePortForwardingCommand ?? (_deletePortForwardingCommand = new DelegateCommand<PortForwardConfig>(ExecuteDeleteCommand));


        


        public MainWindowViewModel()
        {
            PortForwardConfigs.Add(
                new PortForwardConfig("TEST",
                    new SourceConfig(123, IPAddress.Loopback.ToString()),
                    new DestinationConfig(456, IPAddress.Loopback.ToString())));
            PortForwardConfigs.Add(
                new PortForwardConfig("TEST",
                    new SourceConfig(123, IPAddress.Loopback.ToString()),
                    new DestinationConfig(456, IPAddress.Loopback.ToString())));
            PortForwardConfigs.Add(
                new PortForwardConfig("TEST",
                    new SourceConfig(123, IPAddress.Loopback.ToString()),
                    new DestinationConfig(456, IPAddress.Loopback.ToString())));
            PortForwardConfigs.Add(
                new PortForwardConfig("TEST",
                    new SourceConfig(123, IPAddress.Loopback.ToString()),
                    new DestinationConfig(456, IPAddress.Loopback.ToString())));

            OutputText ="TEST";
            StatusText = "Ready...";
        }



        void ExecuteDeleteCommand(PortForwardConfig parameter)
        {

        }


        void ListAllPortForwardingRules()
        {

        }


        void AddNewPortForwarding(PortForwardConfig parameter)
        {

        }

    }



}
